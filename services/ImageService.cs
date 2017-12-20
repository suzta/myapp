using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using travelapp.models;

namespace travelapp.services
{
    public class ImageService: BaseService
    {
        string sqlConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public int Insert(Image model)
        {
            int Id = 0;
            ItemResponse<int> resp = new ItemResponse<int>();

            string systemFileName = string.Empty;

            if (model.ByteArray != null)
            {
                systemFileName = string.Format("{0}_{1}{2}",
                    model.UserFileName,
                    Guid.NewGuid().ToString(),
                    model.Extension);

                SaveBytesFile(model.SaveLocation, systemFileName, model.ByteArray);
            }

            this.DataProvider.ExecuteNonQuery(
                    "Images_Insert",
                    inputParamMapper: delegate (SqlParameterCollection paramCol)
                    {
                        paramCol.AddWithValue("@Id", model.Id);
                        paramCol.AddWithValue("@ImageTitle", model.ImageTitle);
                        paramCol.AddWithValue("@Description", model.Description);
                        paramCol.AddWithValue("@FileId", model.FileId);
                        paramCol.AddWithValue("@SystemFileName", model.SystemFileName);
                        paramCol.AddWithValue("@CreatedDate", model.CreatedDate);
                        paramCol.AddWithValue("@ModifiedDate", model.ModifiedDate);
                        paramCol.AddWithValue("@ModifiedBy", model.ModifiedBy);
                    },
                    returnParameters: delegate (SqlParameterCollection paramCol)
                    {
                        Id = (int)paramCol["@Id"].Value;
                    });
            return Id;
        }


        private void SaveBytesFile(string location, string systemFileName, byte[] Bytes)
        {
            string fileBase = "~/images";
            var filePath = HttpContext.Current.Server.MapPath(fileBase + "/" + location + "/" + systemFileName);
            File.WriteAllBytes("C:/repos/github/myapp/travelapp/image/" + systemFileName, Bytes);
        }
    }
}