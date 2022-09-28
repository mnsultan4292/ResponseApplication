using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseApplication.Modal;
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
        public async IActionResult GetUser() 
        {
            List<UserModal> lst =await _user.GetUserDetails("http://dummy.restapiexample.com/api/v1/employees");
            var empNameList = lst.ToList().MaxBy(x => x.EmployeeAge).EmployeeName;
            return Ok();
        }
    }
}
