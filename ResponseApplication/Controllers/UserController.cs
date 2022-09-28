using Microsoft.AspNetCore.Mvc;
using ResponseApplication.Repository;

namespace ResponseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserRepository _user = null;
        public UserController(IUserRepository user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser() 
        {
            try
            {
                var data = await _user.GetUserDetails("http://dummy.restapiexample.com/api/v1/employees");
                if (data != null)
                {
                    var empNameList = data.ToList().MaxBy(x => x.EmployeeAge).EmployeeName;
                    return Ok(empNameList);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
    }
}
