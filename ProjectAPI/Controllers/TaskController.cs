using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.ServiceInterfaces;
using ProjectAPI.ViewModel;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("GetWorkSpaceDropdown")]
        public async Task<ActionResult> GetWorkSpaceDropdown(int userId)
        {
            VMTaskDropdown vMTaskDropdown = new VMTaskDropdown();
            try
            {
                vMTaskDropdown = await _taskService.GetTaskDropdowns(userId);
            }
            catch (Exception)
            {

            }
            return Ok(vMTaskDropdown);
        }
    }
}
