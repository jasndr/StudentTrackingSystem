﻿using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using StudentTrackingSystem3.Models;
using System.Text;
using System.Web.Security;

namespace StudentTrackingSystem3.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

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

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    //return RedirectToLocal(returnUrl);

                    //Added verification that user has confirmed their email.
                    var user = await UserManager.FindByNameAsync(model.UserName);
                    if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                    {
                        ModelState.AddModelError("", "Please wait for admin to confirm your email.");
                        return View(model);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Student");
                    }
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
                user.Email = model.Email;
                user.EmailConfirmed = false;
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    // await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    //-------------------------------------------------------------------------------------------\\
                    //// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    //// Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, 
                    //                                                                protocol: Request.Url.Scheme);

                    //string sendTo = user.Email;//ConfigurationManager.AppSettings["trackingEmail"];

                    //string subject = String.Format("Email Confirmation - JABSOM CTR "
                    //                                 + "Graduate Program Database");

                    //string body = string.Format("Dear {0}," +
                    //                            "<br /><br />Thank you for your registration on the " +
                    //                            "<strong>JABSOM Clinical & Translational Research (CTR) Graduate Program Database</strong>. " +
                    //                            "Please <a href=\"{1}\" title=\"Confirm Email\">click here</a> " +
                    //                            "to completete your registration. " +
                    //                            "<br /><br/ >Mahalo!",
                    //                user.UserName, callbackUrl);

                    //IdentityMessage im = new IdentityMessage()
                    //{
                    //    Subject = subject,
                    //    Destination = sendTo,
                    //    Body = body.ToString()
                    //};

                    //EmailService emailService = new EmailService();

                    //emailService.Send(im);

                    //return RedirectToAction("DisplayEmail");
                    ////return RedirectToAction("Index", "Home");
                    ////return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                    //-------------------------------------------------------------------------------------------\\

                    // https://stackoverflow.com/questions/21734345/how-to-create-roles-and-add-users-to-roles-in-asp-net-mvc-web-api

                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code },
                    //                                                               protocol: Request.Url.Scheme);

                    var assignRoleUrl = Url.Action("AssignRole", "Account", new { userName = user.UserName },
                                                                                    protocol: Request.Url.Scheme );

                    string sendTo = ConfigurationManager.AppSettings["superAdminEmail"];
                    string subject = String.Format("Please approve new user account ({0}) - JABSOM CTR "
                                                     + "Graduate Program Database", user.UserName);

                    string body = string.Format("Dear QHS Admin," +
                                                "<br /><br />New user, <strong>{0}</strong>, has created an account on the " +
                                                "<em>JABSOM Clinical & Translational Research Graduate Program Database</em>. " +
                                                "<br /><br />To <u>approve</u> access for {0}, please go to <a href=\"{1}\">this link</a> " +
                                                "and select a role below for the new user. <br/><ul>" +
                                                "<li>Super User (View, write, edit, and delete)</li>" +
                                                "<li>Admin (View, write, and edit)</li>" +
                                                "<li>Faculty/Staff (View and write, no edit)</li>" +
                                                "<li>Guest (View only)</li></ul>" +
                                                "<br />To <u>deny</u> access for {0}, you may simply ignore this email." +  
                                                "<br /><br/ >Mahalo!",
                                    user.UserName, assignRoleUrl);

                    IdentityMessage im = new IdentityMessage()
                    {
                        Subject = subject,
                        Destination = sendTo,
                        Body = body.ToString()
                    };

                    EmailService emailService = new EmailService();

                    emailService.Send(im);

                    return RedirectToAction("DisplayEmail");


                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/DisplayEmail
        [AllowAnonymous]
        public ActionResult DisplayEmail()
        {
            return View();
        }


        //
        // GET: /Account/AssignRole
        [HttpGet]
        [Authorize(Roles = "Admin, Super")]
        public ActionResult AssignRole(string userName)
        {
            //ViewBag.User = user;
            //ViewBag.Email = user.Email;

            //var user = UserManager.FindByName(userName);

            ViewBag.UserName = userName;
            ViewBag.ListOfRoles = new SelectList(db.Roles.OrderBy(x=>x.Name == "Super" ? "1" : x.Name), "Name", "Name");// db.Roles;


            return View();

            // var result = await UserManager.ConfirmEmailAsync(userId, code);
            // return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // POST: /Account/AssignRole
        [HttpPost]
        [Authorize(Roles = "Admin, Super")]
        public async Task<ActionResult> AssignRole(AssignRoleViewModel model)
        {

            ViewBag.UserName = model.Username;
            ViewBag.ListOfRoles = new SelectList(db.Roles.OrderBy(x => x.Name == "Super" ? "1" : x.Name), "Name", "Name");// db.Roles;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Assign role to user
            var user = await UserManager.FindByNameAsync(model.Username);
            var userId = user.Id;
            var result = await UserManager.AddToRoleAsync(userId, model.RoleName);
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userId);
            var result2 = await UserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded && result2.Succeeded)
            {
                //.........................................................................................//
                //var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());                   //
                //if (user != null)                                                                        //
                //{                                                                                        //
                //    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);  //
                //}                                                                                        //
                //.........................................................................................//

                // Confirm user account.
                user.EmailConfirmed = true;
                

                // Email user that they are able to login to their account.
                var homePageUrl = Url.Action("Student", "Index");

                string sendTo = user.Email;
                string subject = String.Format("Account approved; {0}, you have been assigned: {1} - JABSOM CTR "
                                                 + "Graduate Program Database", model.Username, model.RoleName);

                string privileges = "";

                switch (model.RoleName)
                {
                    case "Super":
                        privileges = "view, create, edit, and delete";
                        break;
                    case "Admin":
                        privileges = "view, create, and edit";
                        break;
                    case "Biostat":
                        privileges = "view and create";
                        break;
                    case "Guest":
                        privileges = "view only";
                        break;
                    default:
                        privileges = "no";
                        break;
                }


                string body = string.Format("Aloha {0}," +
                                            "<br /><br />Your account on the <em>JABSOM Clinical & Translational Research Graduate Program Database</em> " +
                                            "has been approved and you have been given <u><strong>{1} (<em>{2}</em>)</u> privileges on the database.   You may now <a href=\"{3}\">log in</a> to your account." +
                                            "<br /><br />For questions about your account access, please email qhs@hawaii.edu." +
                                            "<br /><br/ >Mahalo,<br />QHS Admin",
                                user.UserName, model.RoleName, privileges,  homePageUrl);

                IdentityMessage im = new IdentityMessage()
                {
                    Subject = subject,
                    Destination = sendTo,
                    Body = body.ToString()
                };

                EmailService emailService = new EmailService();

                emailService.Send(im);


                // Redirect admin to "Assign Role to User Success" page.
                return RedirectToAction("AssignRoleConfirmation", new { userName = model.Username, roleName = model.RoleName } );//View(model);
                //return RedirectToAction("Index"/*, new { Message = ManageMessageId.ChangePasswordSuccess }*/);
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/AssignRoleConfirmation
        [Authorize(Roles = "Admin, Super")]
        public ActionResult AssignRoleConfirmation(string userName, string roleName)
        {
            ViewBag.Username = userName;
            ViewBag.Rolename = roleName;
            return View();
        }


        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");

                var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", 
                    new { UserId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset CTR Graduate Program Database Password",
                    "Aloha " + user.UserName + ",<br /><br />Please reset your <strong>CTR Graduate Program Database</strong> password by clicking here: <a href=\"" + callbackUrl + "\">link</a><br /><br />Mahalo!");
                return View("ForgotPasswordConfirmation");

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        //
        // GET: /Account/AccessDenied
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}