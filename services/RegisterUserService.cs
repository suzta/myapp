using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelapp.models;

namespace travelapp.services
{
    public class RegisterUserService: BaseService
    {
        private const int HASH_ITERATION_COUNT = 1;
        private const int RAND_LENGTH = 16;
        CryptographyService svc = new CryptographyService();


        public int Insert(RegisterUser model)
        {
            RegisterUser Model = SelectByEmail(model.Email);
            if (Model.Id == 0)
            {
                int Id = 0;
                string salt;
                string hashPass;
                string password;

                password = model.Password;
                salt = svc.GenerateRandomString(RAND_LENGTH);
                hashPass = svc.Hash(password, salt, HASH_ITERATION_COUNT);
                model.Salt = salt;
                model.HashPassword = hashPass;

                this.DataProvider.ExecuteNonQuery(
                    "RegisterUsers_Insert",
                    inputParamMapper: delegate (SqlParameterCollection paramCol)
                    {
                        paramCol.AddWithValue("@Id", model.Id);
                        paramCol.AddWithValue("@UserName", model.UserName);
                        paramCol.AddWithValue("@Email", model.Email);
                        paramCol.AddWithValue("@Salt", model.Salt);
                        paramCol.AddWithValue("@HashPassword", model.HashPassword);
                        paramCol.AddWithValue("@ModifiedBy", model.ModifiedBy);
                    },
                    returnParameters: delegate (SqlParameterCollection paramCol)
                    {
                        Id = (int)paramCol["@Id"].Value;
                    }
                    );
                return Id;
            }
            else
            {
                Model.Id = -1;
                return Model.Id;
            }
        }

        public RegisterUser SelectByEmail(string Email)
        {
            RegisterUser model = new RegisterUser();
            this.DataProvider.ExecuteCmd(
                "RegisterUsers_SelectByEmail",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Email", Email);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    int index = 0;
                    model.Id = reader.GetInt32(index++);
                    model.UserName = reader.GetString(index++);
                    model.Email = reader.GetString(index++);
                    model.Salt = reader.GetString(index++);
                    model.HashPassword = reader.GetString(index++);
                    model.CreatedDate = reader.GetDateTime(index++);
                    model.ModifiedDate = reader.GetDateTime(index++);
                    model.ModifiedBy = reader.GetString(index++);
                }
            );
            return model;
        }

        public bool Login(string Email, string password)
        {
            bool isSuccessful = false;
            RegisterUser model = SelectByEmail(Email);
            string passwordHash = svc.Hash(password, model.Salt, HASH_ITERATION_COUNT);
            if (Email == model.Email && passwordHash == model.HashPassword)
            {
                isSuccessful = true;
            }
            return isSuccessful;
        }
    }
}
