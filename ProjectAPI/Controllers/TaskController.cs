using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.ServiceInterfaces;
using ProjectAPI.Services;
using ProjectAPI.ViewModel;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _iTaskService;

        public TaskController(ITaskService taskService)
        {
            _iTaskService = taskService;
        }

        [HttpGet]
        [Route("GetWorkSpaceDropdown")]
        public async Task<ActionResult> GetWorkSpaceDropdown(int userId)
        {
            VMTaskDropdown vMTaskDropdown = new VMTaskDropdown();
            try
            {
                vMTaskDropdown = await _iTaskService.GetTaskDropdowns(userId);
            }
            catch (Exception)
            {

            }
            return Ok(vMTaskDropdown);
        }

        [HttpGet]
        [Route("GetUserDetailById")]
        public async Task<ActionResult> GetUserDetailById(int userId)
        {
            VMTaskUserDetail vMTaskUserDetail = new VMTaskUserDetail();
            try
            {
                vMTaskUserDetail = await _iTaskService.GetUserDetailById(userId);
            }
            catch (Exception)
            {

            }
            return Ok(vMTaskUserDetail);
        }

        [HttpPost]
        [Route("SaveTask")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> SaveTask([FromForm] VMTask vMTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                long res = await _iTaskService.SaveTask(vMTask);

                return res switch
                {
                    1 => Ok(new { Res = res, Message = "Task created successfully." }),
                    2 => Ok(new { Res = res, Message = "Task updated successfully." }),
                    4 => Ok(new { Res = res, Message = "Task not found for update." }),
                    -99 => StatusCode(500, new { Res = res, Message = "An unexpected error occurred." }),
                    _ => StatusCode(500, new { Res = res, Message = "Unknown response from server." })
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Server error", Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetTaskDetailByUser")]
        public async Task<ActionResult> GetTaskDetailByUser(int userId)
        {
            VMTaskDetailByUser vMTaskDetailByUser = new VMTaskDetailByUser();
            try
            {
                vMTaskDetailByUser = await _iTaskService.GetTaskDetailByUser(userId);
            }
            catch (Exception)
            {

            }
            return Ok(vMTaskDetailByUser);
        }

        [HttpGet]
        [Route("GetTaskDetailById")]
        public async Task<ActionResult> GetTaskDetailById(int taskId)
        {
            VMTaskDetailById vMTaskDetailById = new VMTaskDetailById();
            try
            {
                vMTaskDetailById = await _iTaskService.GetTaskDetailById(taskId);
            }
            catch (Exception)
            {

            }
            return Ok(vMTaskDetailById);
        }

        [HttpPost]
        [Route("UpdateTaskStatus")] 
        public async Task<IActionResult> UpdateTaskStatus([FromForm] VMUpdateTaskStatus vMUpdateTaskStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                long res = await _iTaskService.UpdateTaskStatus(vMUpdateTaskStatus);

                return res switch
                { 
                    2 => Ok(new { Res = res, Message = "Task Status Updated successfully." }),
                    -2 => Ok(new { Res = res, Message = "Task not found for update." }),
                    -99 => StatusCode(500, new { Res = res, Message = "An unexpected error occurred." }),
                    _ => StatusCode(500, new { Res = res, Message = "Unknown response from server." })
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Server error", Error = ex.Message });
            }
        }

    }
}
