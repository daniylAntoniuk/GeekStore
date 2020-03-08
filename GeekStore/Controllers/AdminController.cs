using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GeekStore.Data.EFContext;
using GeekStore.Data.Interfaces;
using GeekStore.Data.Tables;
using GeekStore.Data.ViewModels;
using GeekStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeekStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IOrder _order;
        private readonly IProduct _product;
        private readonly IUserProfile _userProfile;
        private readonly IHostingEnvironment _environment;
        private readonly DBContext _context;
        public AdminController(IHostingEnvironment environment,DBContext context,IOrder order, IProduct product, IUserProfile userProfile)
        {
            _order = order;
            _product = product;
            _userProfile = userProfile;
            _context = context;
            _environment = environment;
        }
        public ViewResult Login()
        {
            return View();
        }

        public IActionResult Home()
        {
            double money = 0;
            List<int> counts=new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                int count = 0;
                foreach (var el in _order.Orders)
                {
                    if (el.OrderDate.Month == i)
                    {
                        count += 1;
                    }
                }
                counts.Add(count);
            }
            List<int> counts2 = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                int count = 0;
                foreach (var el in _userProfile.UserProfiles)
                {
                    if (el.RegisterDate.Month == i)
                    {
                        count += 1;
                    }
                }
                counts2.Add(count);
            }
            foreach(var el in _order.Orders)
            {
                money+=_product.GetProductById(el.ProductId).Price;
                
            }
            var info = HttpContext.Session.GetString("SessionUserData");
            if (info != null)
            {
                var res = JsonConvert.DeserializeObject<UserInfo>(info);
                ViewBag.Name = "Welcome back, "+_context.UserProfiles.FirstOrDefault(x => x.Id == res.UserId).FirstName;
            }
            return View(new AdminViewModel()
            {
                CountOrders=counts,
                CountUserProfiles=counts2,
                Orders=_order.Orders.Count(),
                Users=_context.Users.Count(),
                Money=money
            }
            );
        }
        [HttpPost]
        public IActionResult ChangeProduct(AddProductViewModel model)
        {
            var pr = _context.Products.FirstOrDefault(x => x.Id == model.ProductId);
            pr.Price = double.Parse(model.Price);
            pr.Discount = model.Discount;
            _context.SaveChanges();
            return RedirectToAction("Products", "Admin");
        }
        public ViewResult Products()
        {
            List<ProductAdminModel> products = new List<ProductAdminModel>();
            foreach(var el in _product.ProductsAdm)
            {
                products.Add(new ProductAdminModel()
                {
                    Id = el.Id,
                    Description = el.Description,
                    Dislikes = _context.Dislikes.Where(x => x.ProductId == el.Id).Count(),
                    Likes = _context.Likes.Where(x => x.ProductId == el.Id).Count(),
                    IsEnabled = el.IsDisabled,
                    Name=el.Name,
                    Price=el.Price,
                    Discount=el.Discount
                });
            }
            return View(new AddProductViewModel()
            {
                Products=products
            });
        }
       
        public ViewResult Orders()
        {
            return View(_order.OrdersAdm);
        }

        [Route("Admin/OrderSent/{id}")]
        public IActionResult OrderSent(int id)
        {
            _order.Sent(id);
            return RedirectToAction("Orders", "Admin");
        }
        [Route("Admin/ProductDisable/{id}")]
        public IActionResult ProductDisable(int id)
        {
            _product.Disable(id);
            return RedirectToAction("Products", "Admin");
        }
        [Route("Admin/ProductEnable/{id}")]
        public IActionResult ProductEnable(int id)
        {
            _product.Enable(id);
            return RedirectToAction("Products", "Admin");
        }
       
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel model,IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null&& uploadedFile.Length > 0)
                {
                    var file = uploadedFile;
                    var folderServaerPath = _environment.ContentRootPath;
                    var folderName = "Uploaded";
                    var fileName = Guid.NewGuid().ToString() + ".jpg";
                    var saveFile = Path.Combine(folderServaerPath, folderName, fileName);
                    using(var stream = System.IO.File.Create(saveFile))
                    {
                        await uploadedFile.CopyToAsync(stream);
                        
                    }
                    
                    _context.Products.Add(new Product()
                    {
                        Name = model.Name,
                        Price = double.Parse(model.Price),
                        Description = model.Description,
                        Discount = model.Discount,
                        Image = fileName,
                        IsDisabled = false,
                        SubcategoryId = 1
                    });
                    _context.SaveChanges();
                    return RedirectToAction("Products", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Upload file");
                    return View();
                }
            }
            ModelState.AddModelError("", "Input tags");
            return RedirectToAction("Products", "Admin");
        }
    }
}