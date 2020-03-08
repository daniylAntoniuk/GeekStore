using GeekStore.Data.EFContext;
using GeekStore.Data.ViewModels;
using GeekStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeekStore.Components
{
    public class UserPhoto: ViewComponent
    {
        private readonly DBContext _context;
        public UserPhoto(DBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {

            var info = HttpContext.Session.GetString("SessionUserData");
            if (info != null)
            {
                var img= _context.UserProfiles.FirstOrDefault(x => x.Id == JsonConvert.DeserializeObject<UserInfo>(info).UserId).Image;
                if(img == null)
                {
                    img = "no_img.png";
                }
                img= Path.Combine("/Image",img);
                return View(new UserPhotoViewModel() {
                    Image=img
                });
            }
            return View(new UserPhotoViewModel()
            {
                Image = Path.Combine("/Image", "no_img.png")
            });
        }
    }
}
