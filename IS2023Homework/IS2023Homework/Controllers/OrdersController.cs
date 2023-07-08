using IS2023Homework.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GemBox.Document;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using IS2023Homework.Domain.Domain.Models;
using Spire.Doc;
using Spire.Pdf;
using System.IO;
using System.Linq;

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
       
        public IActionResult SavePDF(int orderId) {
            var wordFilePath = "OrderWord.docx";
            var pdfFileName = "Order.pdf";

            var document = new Document();
            document.LoadFromFile(wordFilePath);
            var usernameNameAndSurname = _orderService.GetOrdersForUser(User.FindFirstValue(ClaimTypes.NameIdentifier)).Orders.Where(z=>z.Id==orderId).FirstOrDefault();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var ticket in usernameNameAndSurname.Tickets)
            {
                stringBuilder.Append(ticket.Ticket.Title);
                stringBuilder.Append(", ");
            }
            stringBuilder.Remove(stringBuilder.Length - 2, 1);

			document.Replace("{{OrderNumber}}", usernameNameAndSurname.Id.ToString(), false, true);
            document.Replace("{{UserName}}", usernameNameAndSurname.OrderedBy.Name + " " + usernameNameAndSurname.OrderedBy.Surname, false, true);
            document.Replace("{{TicketList}}", stringBuilder.ToString(), false, true);

			var pdfStream = new System.IO.MemoryStream();
			document.SaveToStream(pdfStream, Spire.Doc.FileFormat.PDF);

			// Set the position to the beginning of the stream
			pdfStream.Position = 0;

			// Set the content type to application/pdf
			var contentType = "application/pdf";

			// Return the file as a FileStreamResult
			return File(pdfStream, contentType, pdfFileName);
		}
    }
}
