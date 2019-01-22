using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        ApplicationDbContext context;
        public UserController()
        {
            context = new ApplicationDbContext();
        }
        // GET: User
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = new ViewModels.UserIndexViewModel();
            using (var db = new Models.ApplicationDbContext())
            {
                model.UserList.AddRange(db.Users.Select(x => new ViewModels.UserIndexViewModel.UserListViewModel
                {
                    UserId = x.Id,
                    UserName = x.UserName,
                    Email = x.Email
                }));
                foreach (var item in model.UserList)
                {
                    item.UserRoles = UserManager.GetRoles(item.UserId).SingleOrDefault();
                }
            }
            return View(model);
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            var editUser = UserManager.FindById(id);
            var model = new ViewModels.UserCreateOrEditViewModel();
           
            model.UserId = editUser.Id;
            model.UserName = editUser.UserName;
            model.Email = editUser.Email;
            model.UserRoles = UserManager.GetRoles(editUser.Id).SingleOrDefault();

            ViewBag.Name = new SelectList(context.Roles, "Name", "Name");

            return View(model);
           
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(ViewModels.UserCreateOrEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = UserManager.FindById(model.UserId);
            user.Id = model.UserId;

            UserManager.RemoveFromRole(user.Id, model.UserRoles);
            model.UserRoles = ViewBag.Name;
            UserManager.AddToRole(user.Id, model.UserDropDownHolder);

            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}