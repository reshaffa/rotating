using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using rotating.Models;

namespace rotating.Controllers
{
    public class UserController : Controller {
        /* Injection DB Reference */
        private readonly UserContext _db;
        public UserController(UserContext db)
        {
            _db = db;
        }
        /* End Of injection DB Reference */
        public ActionResult Index(){
            return View();
        }

        /* API REQUEST DATA */
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            return Json(new { data = await _db.users.ToListAsync()});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<User>> Create(User User)
        {
            User = new User();
            if (ModelState.IsValid)
            {
                 _db.users.Add(User);
                var status = await _db.SaveChangesAsync();
                return Json(new
                {
                    success = true,
                    message = "Success added new user account..!"
                });
            }
            return Json(new
            {
                success = false,
                message = "Failed added new user account..!"
            });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id){
            var upload_exists = await _db.users.FirstOrDefaultAsync(e => e.id == id);
            if(upload_exists == null){
                return Json( new {
                    status = false,
                    message = "Error Deleted Users !"
                });
            }

            _db.Remove(upload_exists);
            await _db.SaveChangesAsync();
            return Json( new {
                success = true,
                message = "Success Deleted Users !"
            });
        }
    }
}
