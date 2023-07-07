using IS2023Homework.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GemBox.Document;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using IS2023Homework.Domain.Domain.Models;
using System.IO;

namespace IS2023Homework.Controllers
{
    public class OrdersController : Controller
    {
        public readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            ComponentInfo.SetLicense("FREE-LIMITED_KEY");
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var model = _orderService.GetOrdersForUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            return View(model);
        }
       
        public IActionResult SavePDF(int id) {
            /*
            HttpClient client = new HttpClient();
            string URL = "https://localhost:44315/Orders";

			var model = new
            {
                id = id
            };
			HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = client.PostAsync(URL, content).Result;
            var result = httpResponseMessage.Content.ReadAAsync().Result;
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "OrderWord.docx");
            var document = DocumentModel.Load(templatePath);
            document.Content.Replace("{{OrderNumber}}"),result.Id.
            */
            return null;
		}
    }
}
