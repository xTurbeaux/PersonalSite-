using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.MVC.UI.Models;
using System.Net;
using System.Net.Mail;

namespace Site.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
            
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                return View(cvm);
            }

                string body = $"{cvm.Name} has sent you the following message: <br />" +
                    $"{cvm.Message} <strong>from the email address: </strong> {cvm.Email}";

                MailMessage m = new MailMessage("no-reply@standingbytocopy@gmail.com", "Standingbytocopy@gmail.com", cvm.Subject, body);

                m.IsBodyHtml = true;

                m.Priority = MailPriority.High;

                m.ReplyToList.Add(cvm.Email);

                SmtpClient client = new SmtpClient("mail.standingbytocopy@gmail.com");

                client.Credentials = new NetworkCredential("no - reply@standingbytocopy@gmail.com", "P@ssw0rd");

                try
                {
                    client.Send(m);
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Sorry, unable to send your message";
                return View(cvm);
                }
                return View("EmailConfirmation");
            
        }
    }
}
