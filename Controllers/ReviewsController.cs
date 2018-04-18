using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using restaurant.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace restaurant.Controllers
{
    public class ReviewsController : Controller{
        private ReviewContext _context;
        public ReviewsController(ReviewContext context){
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View();
        }
        [HttpGet]
        [Route("dash")]
        public IActionResult Dash(){
            List<Review> AllReviews = _context.Reviews.ToList();
            ViewBag.Reviews = AllReviews;
            return View("Dash");
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(Review model){
            if(ModelState.IsValid && model.OnTime){
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Dash");
            }
            ViewBag.Count = 1;
            ViewBag.Errors = ModelState.Values;
            return View("Index", model);
        }    
    }
}
