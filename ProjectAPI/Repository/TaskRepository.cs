using DataAccess;
using System.Data.SqlClient;
using System.Data;
using ProjectAPI.Interfaces;
using ProjectAPI.Entity;

namespace ProjectAPI.Repository
{
    public class TaskRepository : ITask
    {
        SqlHelper objSqlHelper = new SqlHelper(); 
        public async Task<TaskDropdownEntity> GetTaskDropdowns(int userId)
        {
            TaskDropdownEntity taskDropdownEntity = new TaskDropdownEntity();
            try
            {
                SqlParameter[] par = new SqlParameter[2]; 
                par[0] = new SqlParameter("@P_UserID", userId);
                par[1] = new SqlParameter("@P_CommandType", "WORKPLACE");

                DataSet ds = objSqlHelper.ExecuteDataSetSP("GET_ALL_DROPDOWN_TASK", par);

                if (ds.Tables[0] != null)//ds.Tables[0].Rows.Count > 0)
                {
                    taskDropdownEntity.GetWorkspacesDropdown = Dal.Service_Providers.TableToList.ConvertDataTable<WorkspaceEntity>(ds.Tables[0]);
 
                }
            }
            catch (Exception ex)
            {
                 
            }
            return taskDropdownEntity;
        }
    }
}
