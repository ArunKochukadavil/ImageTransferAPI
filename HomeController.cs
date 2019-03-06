using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonResponseTestWebAPI.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}
		
		public ActionResult JsonResponse(string id,string val1,string val2 )
		{
			var path = @"E:\Receiver\"+val1+".jpg";
			var data = new { Status = "true", Received=Request.QueryString["val1"] , IName=Request.QueryString["val2"]};
			//if (!System.IO.File.Exists(path))
			//{
			//	System.IO.File.Create(path);
			//	System.IO.File.WriteAllBytes(path, Convert.FromBase64String(val2));
			//}

			return Json(data, JsonRequestBehavior.AllowGet);
		}
		public ActionResult SayHello()
		{
			Stream req = Request.InputStream;
			req.Seek(0, System.IO.SeekOrigin.Begin);
			string json = new StreamReader(req).ReadToEnd();
			JObject jsonObj = JObject.Parse(json);
			var content=(string)jsonObj["base64"];
			byte[] imageBytes = Convert.FromBase64String(content);
			MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
			var name = (string)jsonObj["name"];
			var path = @"E:\Receiver\" + name + ".jpg";
			ms.Write(imageBytes, 0, imageBytes.Length);
			System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
			image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
			
			//if (!System.IO.File.Exists(path))
			//{
			//	System.IO.File.Create(path);
			//	System.IO.File.WriteAllBytes(path, Convert.FromBase64String(content));
			//}
			return View();
		}
	}
}
