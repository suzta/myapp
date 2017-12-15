using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using travelapp.models;

namespace travelapp.services
{
    public class PeopleService: BaseService
    {
        public int Insert(People model)
        {
            int id = 0;
            this.DataProvider.ExecuteNonQuery(
                "People_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Id", model.Id);
                    paramCol.AddWithValue("@FirstName", model.FirstName);
                    paramCol.AddWithValue("@MiddleInitial", model.MiddleInitial);
                    paramCol.AddWithValue("@LastName", model.LastName);
                    paramCol.AddWithValue("@DateOfBirth", model.DateOfBirth);
                    paramCol.AddWithValue("@ModifiedBy", model.ModifiedBy);
                },
                returnParameters: delegate (SqlParameterCollection paramCol)
                {
                    id = (int)paramCol["@Id"].Value;
                }
            );
            return id;
        }

        public List<People> GetAll()
        {
            List<People> result = new List<People>();
            this.DataProvider.ExecuteCmd(
                "People_SelectAll",
                inputParamMapper: null,
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    People model = new People();
                    int index = 0;

                    model.Id = reader.GetInt32(index++);
                    model.FirstName = reader.GetString(index++);
                    model.MiddleInitial = reader.GetString(index++);
                    model.LastName = reader.GetString(index++);
                    model.DateOfBirth = reader.GetDateTime(index++);
                    model.CreatedDate = reader.GetDateTime(index++);
                    model.ModifiedDate = reader.GetDateTime(index++);
                    model.ModifiedBy = reader.GetString(index++);

                    result.Add(model);
                }
             );
            return result;
        }

    }
}
