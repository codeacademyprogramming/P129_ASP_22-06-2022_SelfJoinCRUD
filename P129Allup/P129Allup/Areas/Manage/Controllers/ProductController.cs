using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P129Allup.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P129Allup.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        //public async Task<IActionResult> Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Student student)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    return Content($"{student.Name} {student.SurName} {student.Age} {student.Email}");
        //}
    }

    //public class Student
    //{
    //    [Required(ErrorMessage ="Mecburidi qaqa")]
    //    [StringLength(maximumLength:255,ErrorMessage = "Maksimum 255 Simvol Ola Biler")]
    //    public string Name { get; set; }
    //    public string SurName { get; set; }
    //    [Display(Name ="Yas")]
    //    public int Age { get; set; }
    //    [EmailAddress]
    //    public string Email { get; set; }
    //}
}
