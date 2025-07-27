using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Repository;
using ProjectAPI.ViewModel;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser _IUser;
        public UserController(IUser iUser)
        {
            _IUser = iUser;
        }


        
        [HttpGet]
        [Route("GetAllUsers")] 
        public async Task<ActionResult> GetAllUsers()
        {
            VMUser vMUser = new VMUser();
            try
            {
                vMUser = await _IUser.GetAllUsers();
            }
            catch (Exception)
            {

            }
            return Ok(vMUser);
        }
    }
}
