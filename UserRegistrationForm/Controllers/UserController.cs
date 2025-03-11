using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistrationForm.Models;
using UserRegistrationForm.Repository;

namespace UserRegistrationForm.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepository = new UserRepository();

        //Get the All UserDetails
        public ActionResult Index()
        {
            return View(userRepository.GetUsers());
        }

        
        public ActionResult Create()
        {
            return View();
        }

        //Create user detail
        [HttpPost]
        public ActionResult Create(UserModel userModel)
        {
            bool addUser = false;

            try
            {
                if (ModelState.IsValid)
                {
                    addUser = userRepository.CreateUser(userModel);

                    if (addUser)
                    {
                        TempData["SuccessMessage"] = "User detail added successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Cant add the user detail";
                    }
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }

        //Get user by ID
        public ActionResult Details(int id)
        {
            try
            {
                var user = userRepository.GetUserById(id).FirstOrDefault();

                if (user == null)
                {
                    TempData["ErrorMessage"] = "User details not available with the employee Id : " + id;
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost,ActionName("Details")]
        public ActionResult Edit(UserModel userModel)
        {
            bool isUpdate = false;

            try
            {
                isUpdate = userRepository.UpdateUser(userModel);

                if(isUpdate)
                {
                    TempData["SuccessMessage"] = "User detail successfully updated";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Cant update the user details";
                }
            }
            catch(Exception ex)
            {
                TempData["ErroeMessage"] = ex.Message;
            }
            return View();
        }

        // GET: User for Delete
        public ActionResult Delete(int id)
        {
            try
            {
                var user = userRepository.GetUserById(id).FirstOrDefault();

                if (user == null)
                {
                    TempData["ErrorMessage"] = "User details not available with the employee Id : " + id;
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        //Delete user
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            bool isDelete = false;

            try
            {
                isDelete = userRepository.DeleteUser(id);

                if (isDelete)
                {
                    TempData["SuccessMessage"] = "User detail successfully Deleted";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "user detail cant be deleted";
                }
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
