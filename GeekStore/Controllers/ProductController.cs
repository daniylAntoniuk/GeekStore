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

    public class ProductController : Controller
    {
        private readonly DBContext _context;
        private readonly ISubcategory _subcategory;
        private readonly IProduct _product;
        private readonly IProductImages _productImages;
        private readonly IComment _comment;
        private readonly ICategory _category;
        private readonly ICart _cart;
        private readonly IHostingEnvironment _environment;
        public ProductController(IHostingEnvironment environment,ISubcategory subcategory, IProduct product, IProductImages productImages, IComment comment, DBContext context, ICategory category, ICart cart)
        {
            _product = product;
            _productImages = productImages;
            _comment = comment;
            _context = context;
            _category = category;
            _cart = cart;
            _subcategory = subcategory;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [Route("Product/AddLike/{prodId}")]
        public IActionResult AddLike(int prodId)
        {
            var info = HttpContext.Session.GetString("SessionUserData");

            var res = JsonConvert.DeserializeObject<UserInfo>(info);
            _context.Likes.Add(new Like()
            {
                ProductId = prodId,
                UserId = res.UserId
            });
            _context.SaveChanges();
            return RedirectToAction("SeeProduct", "Product", new { id = prodId });

        }
        [Authorize]
        [Route("Product/AddDislike/{prodId}")]
        public IActionResult AddDislike(int prodId)
        {
            var info = HttpContext.Session.GetString("SessionUserData");
            if (info != null)
            {

            var res = JsonConvert.DeserializeObject<UserInfo>(info);
            _context.Dislikes.Add(new Dislike()
            {
                ProductId = prodId,
                UserId = res.UserId
            });
            _context.SaveChanges();
            return RedirectToAction("SeeProduct", "Product", new { id = prodId });
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpGet]
        [Route("Product/SeeProduct/{id}")]
        public ViewResult SeeProduct(int id)
        {
            OrderViewModel model = new OrderViewModel();
            var info = HttpContext.Session.GetString("SessionUserData");
            var product = _product.GetProductById(id);
            product.Image = Path.Combine("/Image", product.Image);
            var productImages = _productImages.GetImagesById(id);
            foreach (var el in productImages)
            {
                el.ImgName = Path.Combine("/Image", el.ImgName);
            }
            if (info != null)
            {
                var res = JsonConvert.DeserializeObject<UserInfo>(info);
                bool like = false;
                bool dislike = false;
                if (_context.Likes.FirstOrDefault(x => x.ProductId == id && x.UserId == res.UserId) != null)
                {
                    like = true;
                }
                if (_context.Dislikes.FirstOrDefault(x => x.ProductId == id && x.UserId == res.UserId) != null)
                {                   
                    dislike = true;
                }
                
                model = new OrderViewModel()
                {
                    Product = product,
                    ProductImages =productImages,
                    Comments = _comment.GetCommentsById(id),
                    Likes = _context.Likes.Where(x => x.ProductId == id).Count(),
                    Dislikes = _context.Dislikes.Where(x => x.ProductId == id).Count(),
                    IsLikeSelected = like,
                    IsDislikeSelected = dislike
                };
            }
            else
            {
                model = new OrderViewModel()
                {
                    Product = product,
                    ProductImages = productImages,
                    Comments = _comment.GetCommentsById(id),
                    Likes = _context.Likes.Where(x => x.ProductId == id).Count(),
                    Dislikes = _context.Dislikes.Where(x => x.ProductId == id).Count(),
                    IsLikeSelected = false,
                    IsDislikeSelected = false
                };
            }

            return View(model);
        }

        [HttpPost]
        [Route("Product/SeeProduct/{id}")]
        public IActionResult SeeProduct(OrderViewModel model)
        {
            var info = HttpContext.Session.GetString("SessionUserData");
            if (info != null)
            {
                var res = JsonConvert.DeserializeObject<UserInfo>(info);
                var up = _context.UserProfiles.FirstOrDefault(x => x.Id == res.UserId);
                var user = _context.Users.FirstOrDefault(x => x.Id == res.UserId);
                if (up.FirstName == null || up.LastName == null || up.Sity == null || up.PostDepartament == 0 || user.PhoneNumber == null)
                {
                    return RedirectToAction("Profile", "Account");
                }
                var order = new Order()
                {
                    Count = model.Count,
                    FirstName = up.FirstName,
                    SecondName = up.LastName,
                    PostDepartament = up.PostDepartament,
                    ProductId = model.ProductId,
                    Phone = user.PhoneNumber,
                    Sent = false,
                    Sity = up.Sity,
                    OrderDate = DateTime.Now
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
                _context.UserOrders.Add(new UserOrder()
                {
                    UserId = res.UserId,
                    OrderId = order.Id
                });
                _context.SaveChanges();
                return RedirectToAction("AllDone", "Home");
            }

            _context.Orders.Add(new Order()
            {
                Count = model.Count,
                FirstName = model.FirstName,
                SecondName = model.LastName,
                PostDepartament = model.PostDepartament,
                ProductId = model.ProductId,
                Phone = model.Phone,
                Sent = false,
                Sity = model.Sity,
                OrderDate = DateTime.Now
            });
            _context.SaveChanges();

            return RedirectToAction("AllDone", "Home");
        }
        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {
            
            var res = model.Name.Split(' ');
            foreach(var el in _context.Categories)
            {
                if(el.Name.ToLower().Contains(model.Name.ToLower()))
                {
                    return RedirectToAction("Category", "Product", new { id = el.Id });
                }
                if (el.Name.ToLower().Contains(res[0].ToLower()))
                {
                    var sub = _subcategory.GetSubcategoriesByCategoryId(el.Id);
                    var sid=sub.FirstOrDefault(x => x.Name.ToLower() == res[1].ToLower()).Id;
                    if(sub != null)
                    {
                        return RedirectToAction("CategoryProducts", "Product", new { id = sid });
                    }
                }
            }
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (var item in _category.Categories)
            {
                categories.Add(new CategoryViewModel()
                {
                    Category = item,
                    Subcategories = _subcategory.Subcategories.Where(x => x.CategoryId == item.Id)
                });
            }
            return View(new SearchViewModel() {
                Products = _context.Products.Where(x => x.Name.Contains(model.Name)),
                Categories = categories
            });
        }
        [Route("Product/CategoryProducts/{id}")]
        public ViewResult CategoryProducts(int id)
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (var item in _category.Categories)
            {
                categories.Add(new CategoryViewModel()
                {
                    Category = item,
                    Subcategories = _subcategory.Subcategories.Where(x => x.CategoryId == item.Id)
                });

            }
            var pr = _product.GetProductsBySubcategory(id);
            foreach (var el in pr)
            {
                el.Image = Path.Combine("/Image", el.Image);
            }
            return View(
                new SearchViewModel()
                {
                    Products = pr,
                    Categories = categories
                });
        }
        [Route("Product/Category/{id}")]
        public ViewResult Category(int id)
        {

            List<Product> products = new List<Product>();
            var subc = _context.Subcategories.Where(x => x.CategoryId == id);
            foreach (var el in subc)
            {
                products.AddRange(_product.GetProductsBySubcategory(el.Id));
            }

            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (var item in _category.Categories)
            {
                categories.Add(new CategoryViewModel()
                {
                    Category = item,
                    Subcategories = _subcategory.Subcategories.Where(x => x.CategoryId == item.Id)
                });

            }
            foreach (var el in products)
            {
                el.Image=Path.Combine("/Image", el.Image);
            }
            return View(new SearchViewModel()
            {
                Products = products,
                Categories = categories
            });
        }
        [HttpPost]
        public IActionResult AddComment(OrderViewModel model)
        {
            _context.Comments.Add(new Comment()
            {
                CommentText = model.CommentText,
                ProductId = model.ProductId
            });
            _context.SaveChanges();

            return RedirectToAction("AllDone", "Home");
        }
        [Route("Product/AddToCart/{id}")]
        [Authorize]
        public IActionResult AddToCart(int id)
        {
            var info = HttpContext.Session.GetString("SessionUserData");
            if (info != null)
            {
                var res = JsonConvert.DeserializeObject<UserInfo>(info);
                var cart = _cart.Carts.FirstOrDefault(x => x.UserId == res.UserId);
                if (cart == null)
                {
                    _cart.AddCart(res.UserId);
                    cart = _cart.Carts.FirstOrDefault(x => x.UserId == res.UserId);
                }
                _cart.AddProductToCart(cart.Id, id);
                return RedirectToAction("AllDone", "Home");
            }
            return RedirectToAction("Login", "Account");

        }
        [Authorize]
        [Route("Product/CartCheckout/{id}")]
        public IActionResult CartCheckout(string id)
        {
            var up = _context.UserProfiles.FirstOrDefault(x => x.Id == id);
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (up.FirstName == null || up.LastName == null || up.Sity == null || up.PostDepartament == 0 || user.PhoneNumber == null)
            {
                return RedirectToAction("Profile", "Account");
            }
            var cart = _cart.Carts.FirstOrDefault(x => x.UserId == id).Id;
            var pc = _cart.ProductCarts.Where(x => x.CartId == cart);
            List<Order> orders = new List<Order>();
            Order ord = new Order();
            foreach (var el in pc)
            {
                ord = new Order()
                {
                    OrderDate = DateTime.Now,
                    PostDepartament = up.PostDepartament,
                    FirstName = up.FirstName,
                    SecondName = up.LastName,
                    Sent = false,
                    Sity = up.Sity,
                    //Count=el.Count,
                    Count = 1,
                    Phone = user.PhoneNumber,
                    ProductId = el.ProductId
                };
                _context.Orders.Add(ord);
                orders.Add(ord);
                _context.UserOrders.Add(new UserOrder()
                {
                    UserId = user.Id,
                    OrderId = ord.Id
                });
                _context.ProductCarts.Remove(el);
            }
            //_context.Orders.AddRange(orders);
            _context.SaveChanges();
            return RedirectToAction("AllDone", "Home");
        }
        [Authorize]
        [Route("Product/DeleteCartItem/{id}")]
        public IActionResult DeleteCartItem(int id)
        {
            _context.ProductCarts.Remove(_context.ProductCarts.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("SeeCart", "Product");
        }
        [Authorize]
        [Route("Product/SeeCart")]
        public IActionResult SeeCart()
        {
            var info = HttpContext.Session.GetString("SessionUserData");
            if (info != null)
            {
                var res = JsonConvert.DeserializeObject<UserInfo>(info);

                var cart = _cart.Carts.FirstOrDefault(x => x.UserId == res.UserId);
                List<Product> products = new List<Product>();
                var pc = _cart.ProductCarts.Where(x => x.CartId == cart.Id);
                foreach (var el in pc)
                {
                    
                    products.Add(_product.Products.FirstOrDefault(x => x.Id == el.ProductId));
                }
                foreach (var el in products)
                {
                    el.Image = Path.Combine("/Image", el.Image);
                }

                return View(new CartViewModel()
                {
                    UserId = res.UserId,
                    Cart = cart,
                    Products = products,
                    ProductCarts = pc.ToList()
                });
            }
            return RedirectToAction("Index", "Home");
        }
    }
}