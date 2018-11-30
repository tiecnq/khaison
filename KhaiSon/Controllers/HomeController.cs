using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace KhaiSon.Controllers
{
    public class HomeController : Controller
    {
        private readonly string FromEmail = ConfigurationManager.AppSettings["FromEmail"].ToString();
        private readonly string pass = ConfigurationManager.AppSettings["pass"].ToString();
        private readonly int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
        private readonly string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
        private readonly string displayName = ConfigurationManager.AppSettings["displayName"].ToString();
        private readonly string title = ConfigurationManager.AppSettings["title"].ToString();
        private readonly string userName = ConfigurationManager.AppSettings["UserName"].ToString();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public class Entity
        {
            public string FullName { set; get; }
            public string Phone { set; get; }
            public string Email { set; get; }
            public string Content { set; get; }
        }
        /// <summary>
        /// Gửi Email
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public object SendEmail(Entity data)
        {
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Host = smtp;
                    smtpClient.Port = smtpPort;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.TargetName = displayName;
                    smtpClient.Credentials = new NetworkCredential(userName, pass);
                    var msg = new MailMessage
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress(FromEmail, displayName + "Khai Sơn City " + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy HH:mm:ss")),
                        Subject = "Đăng ký dự án Khai Sơn City " + Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy HH:mm:ss"),
                        Body = "Họ tên: " + data.FullName + " </br>" +
                        "Phone: " + data.Phone + " </br>" +
                        "Email: " + data.Email + " </br>" +
                        "Yêu cầu: " + data.Content + " </br>",
                        Priority = MailPriority.Normal,

                    };
                    var folder = Convert.ToDateTime(DateTime.Now).ToString("ddMMyyyyHHmmss");
                    var templateDocument = Path.Combine(Server.MapPath("/Template/" + folder + ".txt"));
                    string text = msg.Body;
                    System.IO.File.WriteAllText(templateDocument, text);
                    msg.To.Add("cskh.khaisoncitylongbien@gmail.com");
                    smtpClient.Send(msg);
                }
                return Json(new JMessage { Title = "Gửi Email thành công", Error = false });
            }
            catch (Exception ex)
            {
                return Json(new JMessage { Title = "Gửi Email không thành công", Error = true, Object = ex.Message });
            }
        }
        public class JMessage
        {
            /// <summary>
            /// ID của bản ghi được thêm, sửa, xóa
            /// </summary>
            public int ID { get; set; }
            /// <summary>
            /// Thông báo
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// Có lỗi hay không có lỗi
            /// </summary>
            public bool Error { get; set; }
            /// <summary>
            /// Đối tượng attach kèm theo thông báo
            /// </summary>
            public object Object { get; set; }
            public JMessage(int id, string title, int? workFlowsOrder, bool error, object obj)
            {
                ID = id; Title = title; Error = error; Object = obj;
            }
            public JMessage()
            {

            }
        }
    }
}