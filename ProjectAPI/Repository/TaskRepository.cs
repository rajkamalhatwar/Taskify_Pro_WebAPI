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
        private readonly IWebHostEnvironment _env;
        public TaskRepository(IWebHostEnvironment env)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            Console.WriteLine("WebRootPath: " + _env.WebRootPath);
        }
        public async Task<TaskDropdownEntity> GetTaskDropdowns(int userId)
        {
            TaskDropdownEntity taskDropdownEntity = new TaskDropdownEntity();
            try
            {
                SqlParameter[] par = new SqlParameter[2]; 
                par[0] = new SqlParameter("@P_UserID", userId);
                par[1] = new SqlParameter("@P_CommandType", "WORKPLACE");

                DataSet ds = objSqlHelper.ExecuteDataSetSP("GET_ALL_DROPDOWN_TASK", par);

                if (ds.Tables[0] != null)
                {
                    taskDropdownEntity.GetWorkspacesDropdown = Dal.Service_Providers.TableToList.ConvertDataTable<WorkspaceEntity>(ds.Tables[0]); 
                }
                if (ds.Tables[1] != null)
                {
                    taskDropdownEntity.GetUserDropdown = Dal.Service_Providers.TableToList.ConvertDataTable<UsersListEntity>(ds.Tables[1]);
                }
            }
            catch (Exception ex)
            {
                 
            }
            return taskDropdownEntity;
        }

        public async Task<TaskUserDetailEntity> GetUserDetailById(int userId)
        {
            TaskUserDetailEntity taskUserDetailEntity = new TaskUserDetailEntity();
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@P_UserID", userId); 

                DataSet ds = objSqlHelper.ExecuteDataSetSP("GET_USER_BY_ID", par);

                if (ds.Tables[0] != null)
                {
                    taskUserDetailEntity.GetUserDetailById = Dal.Service_Providers.TableToList.ConvertDataTable<UserDetailByIdEntity>(ds.Tables[0]);
                }
         
            }
            catch (Exception ex)
            {

            }
            return taskUserDetailEntity;
        }

        public async Task<long> SaveTask(TaskEntity taskEntity)
        {
            try
            {
                 
                if (taskEntity.File != null && taskEntity.File.Length > 0)
                {
                    taskEntity.Attachment = await SaveFileAsync(taskEntity.File);
                } 

                SqlParameter[] objParams = new SqlParameter[10]; 
                objParams[0] = new SqlParameter("@TaskId", taskEntity.TaskId);
                objParams[1] = new SqlParameter("@Title", taskEntity.Title);
                objParams[2] = new SqlParameter("@Description", taskEntity.Description);
                objParams[3] = new SqlParameter("@AssigneeId", taskEntity.AssigneeId);
                objParams[4] = new SqlParameter("@StatusId", taskEntity.StatusId);
                objParams[5] = new SqlParameter("@StoryPoints", taskEntity.StoryPoints);
                objParams[6] = new SqlParameter("@Attachment", taskEntity.Attachment);
                objParams[7] = new SqlParameter("@CreatedBy", taskEntity.CreatedBy);
                objParams[8] = new SqlParameter("@IsActive", taskEntity.IsActive); 
                objParams[9] = new SqlParameter("@Res", SqlDbType.Int); 
                objParams[9].Direction = ParameterDirection.Output;
                

                var ret = objSqlHelper.ExecuteNonQuerySP("[dbo].[sp_InsertOrUpdateTask]", objParams, true);

                if (ret == null)
                    return -99;

                return Convert.ToInt64(ret);
            }
            catch
            {
                return -99;
            }
        }

        public async Task<string> SaveFileAsync(IFormFile file, string subFolder = "uploads")
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file.");

            // Ensure folder exists
           // string webRoot = _env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot");
            string solutionFolder = Path.Combine(_env.ContentRootPath, "..", "uploadFiles");
            string uploadFolder = Path.Combine(solutionFolder, subFolder);
            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            // Unique file name
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Full path
            string filePath = Path.Combine(uploadFolder, uniqueFileName);

            // Save file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return relative path (for DB)
            return $"/{subFolder}/{uniqueFileName}";
        }

        public async Task<TaskDetailByUserEntity> GetTaskDetailByUser(int userId)
        {
            TaskDetailByUserEntity taskDetailByUserEntity = new TaskDetailByUserEntity();
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@AssigneeId", userId);

                DataSet ds = objSqlHelper.ExecuteDataSetSP("SP_GetTasksByAssignee", par);

                if (ds.Tables[0] != null)
                {
                    taskDetailByUserEntity.GetTaskDetailByUser = Dal.Service_Providers.TableToList.ConvertDataTable<TaskEntity>(ds.Tables[0]);
                }

            }
            catch (Exception ex)
            {

            }
            return taskDetailByUserEntity;
        }

        public async Task<TaskDetailByIdEntity> GetTaskDetailById(int taskId)
        {
            TaskDetailByIdEntity taskDetailByIdEntity = new TaskDetailByIdEntity();
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@TaskId", taskId);

                DataSet ds = objSqlHelper.ExecuteDataSetSP("SP_GetTasksById", par);

                if (ds.Tables[0] != null)
                {
                    taskDetailByIdEntity.GetTaskDetailById = Dal.Service_Providers.TableToList.ConvertDataTable<TaskEntity>(ds.Tables[0]);
                }

            }
            catch (Exception ex)
            {

            }
            return taskDetailByIdEntity;
        }

        public async Task<long> UpdateTaskStatus(TaskEntity taskEntity)
        {
            try
            { 

                SqlParameter[] objParams = new SqlParameter[3];
                objParams[0] = new SqlParameter("@TaskId", taskEntity.TaskId);
                objParams[1] = new SqlParameter("@StatusId", taskEntity.StatusId); 
                objParams[2] = new SqlParameter("@Res", SqlDbType.Int);
                objParams[2].Direction = ParameterDirection.Output;

                var ret = objSqlHelper.ExecuteNonQuerySP("SP_UpdateTaskStatus", objParams, true);

                if (ret == null)
                    return -99;

                return Convert.ToInt64(ret);
            }
            catch
            {
                return -99;
            }
        }
    }
}
