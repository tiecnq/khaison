using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhaiSon.Controllers
{
    public class ContentsController : Controller
    {
        // GET: Contents
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QuyHoach()
        {
            return View();
        }
        public ActionResult TienDo()
        {
            return View();
        }
        public ActionResult ChinhSach()
        {
            return View();
        }
    }
}