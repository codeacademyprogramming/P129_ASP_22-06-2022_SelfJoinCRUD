using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using P129Allup.DAL;
using P129Allup.Models;
using P129Allup.ViewModels.BasketViewModels;
using P129Allup.ViewModels.HeaderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129Allup.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(IDictionary<string, string> settings)
        {
            //IDictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(x => x.Key, x => x.Value);

            List<BasketVM> basketVMs = null;

            string basket = HttpContext.Request.Cookies["basket"];

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

                foreach (BasketVM basketVM in basketVMs)
                {
                    Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);

                    basketVM.Image = product.MainImage;
                    basketVM.Name = product.Name;
                    basketVM.ExTax = product.ExTax;
                    basketVM.Price = product.DiscoutnPrice > 0 ? product.DiscoutnPrice : product.Price;
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            HeaderViewModel headerViewModel = new HeaderViewModel
            {
                Settings = settings,
                BasketVMs = basketVMs
            };
            return View(await Task.FromResult(headerViewModel));
        }
    }
}
