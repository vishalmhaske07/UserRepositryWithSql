using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRepositryWithSql.Models;
using UserRepositryWithSql.Repositry.InterFace;

namespace UserRepositryWithSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("Index")]

        public IActionResult Index()
        {
            var GetAll = _user.GetAllUsers();
            if (GetAll == null)
            {
                return NotFound();
            }
            return Ok(GetAll);
        }
        [HttpGet]
        [Route("GetById")]

        public IActionResult GetById(int Id)
        {
            User GetId = _user.GetUserById(Id);
            if (GetId == null)

            {
                return NotFound();
            }
            return Ok(GetId);
        }
        [HttpPost]
        [Route("Creates")]
        public IActionResult Creates(User model)
        {
            int Create = _user.CreateUser(model);

            if (Create <= 0)
            {
                return BadRequest("FAiled");
            }
            else
            {
                return Ok("Added" + Create);
            }


        }
        [HttpPut]
        [Route("Edit")]
        public IActionResult Updates(User model)
        {


            int Update = _user.UpdateUser(model);

            if (Update <= 0)
            {
                return BadRequest("FAiled");
            }
            else
            {
                return Ok("Updated" + Update);
            }


        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {

            int Delete = _user.DeleteUser(id);

            if (Delete <= 0)
            {
                return BadRequest("FAiled");
            }
            else
            {
                return Ok("Deleted" + Delete);
            }


        }



    }
}
