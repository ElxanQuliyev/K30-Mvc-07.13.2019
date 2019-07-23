
using _07._13_2019_mvc_k30.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace _07._13_2019_mvc_k30.Controllers
{
    public class UserAccountController : Controller
    {
            K30FinanceDBEntities db = new K30FinanceDBEntities();
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                ViewBag.userInfo = db.Users.FirstOrDefault(us => us.Id == id);
            }
            else
            {
                return HttpNotFound();
            }
            return View();



        }
        // GET: UserAccount
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(string Username,string Password)
        {
            if(Username!="" && Password != ""){
                User activeUser = db.Users.FirstOrDefault(u => u.Username == Username);
                if (activeUser != null)
                {
                    if (Crypto.VerifyHashedPassword(activeUser.Password, Password))
                    {
                        Session["loggedUser"] = activeUser;
                        return RedirectToAction("Index", "Home");

                    }
                    else {
                        ViewBag.Error = "Password is not Correct";

                    }

                }
                else
                {
                    ViewBag.Error = "Email is not correct";
                }
            }
            else
            {
                ViewBag.Error = "Please all the fill!!";
            }
            return View();

        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User us,string ConfirmPassword,HttpPostedFileBase Photo)

        {
            if (Photo != null) {
                   
                    WebImage image = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    image.Save("~/Uploads/UserImage/" + newPhoto);
                    us.Image = "/Uploads/UserImage/" + newPhoto;
                }
            if (us.Username!=String.Empty && us.Email!=String.Empty && us.Password!=String.Empty && ConfirmPassword!=string.Empty)
            {
                if (!(db.Users.Any(u=>u.Email==us.Email || u.Username==us.Username)))
                {
                    if (us.Password.Length > 5)
                    {
                        if (us.Password == ConfirmPassword)
                        {
                            us.Password = Crypto.HashPassword(us.Password);
                            db.Users.Add(us);
                            db.SaveChanges();
                            return RedirectToAction("Index","Home");
                        }
                        else
                        {
                            ViewBag.Error = "Password and Confirm password  valid";

                        }
                    }
                    else
                    {
                        ViewBag.Error = "Password length should be consist of 5 Charachters";

                    }

                }
                else
                {
                    ViewBag.Error = "Email or Username already exsist";

                }
            }
            else
            {
                ViewBag.Error = "Please all the fill!!";
            }
                return View();

        }
        public ActionResult Logout()
        {
            Session["loggedUser"] = null;
            return RedirectToAction("Index","Home");
        }

    }
}