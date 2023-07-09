using IS2023Homework.Domain.Domain.Models;
using IS2023Homework.Domain.Identity;
using IS2023Homework.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Linq;

namespace IS2023Homework.Controllers
{
	public class ApplicationUsersController : Controller
	{
		private readonly IApplicationUserService _userService;
		private readonly UserManager<ShopApplicationUser> _userManager;
		public ApplicationUsersController (IApplicationUserService userService, UserManager<ShopApplicationUser> userManager)
		{
			_userService = userService;
			_userManager = userManager;
		}
		public IActionResult Index()
		{
			var currentId = _userManager.GetUserAsync(HttpContext.User).Result.Id;
			var model = _userService.GetAll().ToList();
			model = model.Where(z=>z.Id!=currentId).ToList();
			return View(model);
		}
		public IActionResult RemoveAdmin(string id) {
			_userService.Update(id, "Standard");
			return RedirectToAction("Index");
		}
        public IActionResult MakeAdmin(string id)
        {
            _userService.Update(id, "Admin");
            return RedirectToAction("Index");
        }
        public IActionResult UploadExcel(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                // Handle error: No file uploaded
                return BadRequest();
            }

            // Read the Excel file
            using (var stream = file.OpenReadStream())
            {
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Assuming data is on the first worksheet

                    // Iterate through the rows and insert data
                    for (int row = 2; row <= worksheet.Dimension.Rows; row++) // Assuming the first row is the header
                    {
                        string name = worksheet.Cells[row, 1].Value?.ToString();
                        string surname = worksheet.Cells[row, 2].Value?.ToString();
                        string email = worksheet.Cells[row, 3].Value?.ToString();
                        string password = worksheet.Cells[row, 4].Value?.ToString();
                        string role = worksheet.Cells[row, 5].Value?.ToString();
                        string address = worksheet.Cells[row, 6].Value?.ToString();

                        var user = new ShopApplicationUser { UserName = email, Email = email,NormalizedEmail= email.ToUpper(), NormalizedUserName= email.ToUpper(), Name = name, Surname = surname, Address = address, UserShoppingCart = new ShoppingCart(), Role = role };
                        var passwordHasher = new PasswordHasher<ShopApplicationUser>();
                        user.PasswordHash = passwordHasher.HashPassword(user, password);

                        _userService.Insert(user);
                        // Insert the data into your database or perform any desired operation
                        // Example: db.Insert(new Person { Name = name, Age = age });
                    }
                }
            }

            // Data insertion successful
            return RedirectToAction("Index");
        }
    }
}
