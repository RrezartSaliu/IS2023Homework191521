using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using IS2023Homework.Service.Interface;
using IS2023Homework.Domain.DTO;
using IS2023Homework.Domain.Domain.Models;
using IS2023Homework.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OfficeOpenXml;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IS2023Homework.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly UserManager<ShopApplicationUser> _userManager;
        public TicketsController(ITicketService ticketService, UserManager<ShopApplicationUser> userManager)
        {
            _ticketService = ticketService;
            _userManager = userManager;

        }

        // GET: Tickets
        public async Task<IActionResult> Index(bool? ascending, bool? descending)
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentRole = _userManager.GetUserAsync(HttpContext.User).Result.Role;
                ViewBag.UserRole = currentRole;
            }
            var model = _ticketService.GetAllTickets();
            if (ascending == true)
            {
                model.Sort((x,y)=>x.Time.CompareTo(y.Time));
            }
            if (descending == true)
            {
                model.Sort((x,y) => y.Time.CompareTo(x.Time));
            }
            return View(model);
        }

        public async Task<IActionResult> AddToCart(int TicketId)
        {
            var ticket = _ticketService.GetDetailsForTicket(TicketId);
            var model = new AddToShoppingCartDto();
            model.SelectedTicket = ticket;
            model.TicketId = ticket.Id;
            model.Quantity = 0;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddToShoppingCart(AddToShoppingCartDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = this._ticketService.AddToShoppingCart(model, userId);
            if (result)
            {
                return RedirectToAction("Index", "Tickets");
            }
            return RedirectToAction("Index"); 
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var currentRole = _userManager.GetUserAsync(HttpContext.User).Result.Role;
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id??0);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewBag.UserRole= currentRole;

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _ticketService.CreateNewTicket(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id ?? 0);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ticketService.UpdateExistingTicket(ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id ?? 0);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _ticketService.DeleteTicket(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _ticketService.GetDetailsForTicket(id)!=null;    
        }
        public IActionResult ExportToExcel(string? category)
        {
           
                // Retrieve the data from your data source
                List<Ticket> data = _ticketService.GetAllTickets();
            if (category != null)
            {
                data = data.Where(z=>z.MovieCategory.ToString().Equals(category)).ToList();
            }

            // Create the Excel package
            using (var package = new ExcelPackage())
            {
                // Create a worksheet
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Write the header row
                worksheet.Cells[1, 1].Value = "Title";
                worksheet.Cells[1, 2].Value = "MovieCategory";
                worksheet.Cells[1, 3].Value = "Price";
                worksheet.Cells[1, 4].Value = "Time";

                // Populate the worksheet with data
                for (int row = 0; row < data.Count; row++)
                {
                    // Get the data for the current row
                    var rowData = new object[]
                    {
                data[row].Title,
                data[row].MovieCategory,
                data[row].Price,
                data[row].Time.ToString("yyyy-MM-dd HH:mm:ss") // Format DateTime attribute as normal date
                    };

                    // Write the row data to the worksheet
                    worksheet.Cells[row + 2, 1].LoadFromArrays(new[] { rowData });
                }

                // Prepare the response
                var content = package.GetAsByteArray();
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "export.xlsx";

                // Return the Excel file as the response
                return File(content, contentType, fileName);
            }
        }
    }
}
