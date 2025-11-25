using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Interfaces;
using ProjectAPI.ViewModel;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRegController : ControllerBase
    {
        IUserReg _IUserReg;
        public UserRegController(IUserReg iUserReg)
        {
            _IUserReg = iUserReg;
        }

        [HttpPost]
        [Route("SaveUser")]
        public async Task<IActionResult> SaveUser([FromBody] VMUserReg vMUserReg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                long res = await _IUserReg.SaveUser(vMUserReg);

                return res switch
                {
                    1 => Ok(new { Res = res, Message = "User registered successfully." }),
                    2 => Ok(new { Res = res, Message = "User updated successfully." }),
                    3 => Ok(new { Res = res, Message = "User with this email already exists." }),
                    4 => Ok(new { Res = res, Message = "User not found for update." }),
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
