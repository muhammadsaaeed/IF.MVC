using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iForce.Core.Models;
using iForce.Core.Services;

namespace iForce.MVC.Controllers
{
    public class UserController : Controller
    {
        private UserService userService = new UserService();

        // GET: User
        public ActionResult Index()
        {
            var userList = userService.GetUserListingModel(1);
            if (TempData["Message"] != null)
            {
                userList.Notification = (Message)TempData["Message"];
            }
            return View(userList);
        }

        [HttpPost]
        public ActionResult Index(int currentPageIndex, string sortBy = "ID", string sortOrder = "ASC")
        {
            return View(userService.GetUserListingModel(currentPageIndex, sortBy, sortOrder));
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userViewModel = getUserById((int)id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        private UserViewModel getUserById(int id)
        {
            try
            {
                return userService.GetUserById(id);
            }
            catch (Exception)
            {
                var message = new Message() { Error = "An error occurred while processing operation. Please try again." };
                TempData["Message"] = message;
                throw new Exception(message.Error);
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View(new UserViewModel());
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,UserRoleId,UserStatusId")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                addUser(userViewModel);
                return RedirectToAction("Index");
            }

            return View(userViewModel);
        }

        private void addUser(UserViewModel user)
        {
            try
            {
                userService.AddUser(user);
                var message = new Message() { Success = "New user has been successfully added." };
                TempData["Message"] = message;
            }
            catch (Exception ex)
            {
                var message = new Message() { Error = "An error occurred while adding the user. Please try again." };
                TempData["Message"] = message;
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userViewModel = getUserById((int)id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,UserRoleId,UserStatusId")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                updateUser(userViewModel);
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        private void updateUser(UserViewModel user)
        {
            try
            {
                userService.UpdateUser(user);
                var message = new Message() { Success = "User has been successfully updated." };
                TempData["Message"] = message;
            }
            catch (Exception ex)
            {
                var message = new Message() { Error = "An error occurred while updating the user. Please try again." };
                TempData["Message"] = message;
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userViewModel = getUserById((int)id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            deleteUser(id);
            return RedirectToAction("Index");
        }

        private void deleteUser(int id)
        {
            try
            {
                userService.DeleteUser(id);
                var message = new Message() { Success = "User has been successfully deleted." };
                TempData["Message"] = message;
            }
            catch (Exception)
            {
                var message = new Message() { Success = "An error occurred while deleting the user. Please try again." };
                TempData["Message"] = message;
            }
        }
    }
}
