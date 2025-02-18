﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using E_Hutech.Models;

namespace E_Hutech.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SendEmail(string Fname, string Phonenumber, string Email, string Message)
        {
            string senderID = "luong82345@gmail.com";
            string senderPassword = "0986186349";

            string body = "Bạn " + Fname + " đã gửi một email từ " + Email;
            body += " | Số điện thoại : " + Phonenumber;
            body += " | Chi tiết : " + Message;
            body += " | Chúng tôi đã nhận được phản hồi từ " + Fname;
            body += " | Chúc " + Fname + " ngày mới vui vẻ !";
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(Email);
                mail.From = new MailAddress(senderID);
                mail.Subject = "Phản Hồi từ cổng thông tin sự kiện Hutech";
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Response.Write("Exception in sendEmail:" + ex.Message);
            }
            return Json("User Details are updated");
        }
    }
}
