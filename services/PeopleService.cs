using System.Collections.Generic;
using System.Configuration;
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

    }
}
