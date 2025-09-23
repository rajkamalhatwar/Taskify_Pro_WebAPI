using ProjectAPI.Entity;
using ProjectAPI.ServiceInterfaces;
using System.Data.SqlClient;
using System.Data;
using DataAccess;

namespace ProjectAPI.Repository
{
    public class UserRegRepo : IUserRegService
    {
        SqlHelper objSqlHelper = new SqlHelper();
        public async Task<long> SaveUser(UserRegEntity userRegEntity)
        {
            object ret; 
 
            try
            {
                SqlParameter[] objParams = null;
                objParams = new SqlParameter[8];

                objParams[0] = new SqlParameter("@UserId", userRegEntity.UserId); 
                objParams[1] = new SqlParameter("@FullName ", userRegEntity.FullName);
                objParams[2] = new SqlParameter("@Email", userRegEntity.Email);
                objParams[3] = new SqlParameter("@Password", userRegEntity.Password); 
                objParams[4] = new SqlParameter("@MobileNumber", userRegEntity.MobileNumber);
                objParams[5] = new SqlParameter("@Gender", userRegEntity.Gender);
                objParams[6] = new SqlParameter("@IsActive", userRegEntity.IsActive);
                objParams[7] = new SqlParameter("@Res", SqlDbType.Int);
                objParams[7].Direction = ParameterDirection.Output;
                ret = objSqlHelper.ExecuteNonQuerySP("[dbo].[sp_InsertOrUpdateUserRegistration]", objParams, true);

                if (ret == null)
                {
                    return -99;
                }
                else
                {
                    return (int)ret;
                }
            }
            catch (Exception ex)
            { 
                return -99;
            }
        }
    }
}
