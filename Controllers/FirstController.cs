using System;
using System.IO;
using System.Linq;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers{

    public class FirstController : Controller{


        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService){
            _logger = logger;
            _productService = productService;
        }
        public string Index(){

            _logger.LogInformation("Index action");
            return "First index Page";
        }

        public void Nothing(){

            _logger.LogInformation("Nothing action");
            Response.Headers.Add("test-header", "test");
        }

        public Object Anything() => DateTime.Now;

        public IActionResult Readme(){
            var content = @"
            test
            xuong
            dong
            <img src=x onerror=alert(origin)>
            ";
            return Content(content);
        }

        public IActionResult Bird(){
            string filePath = Path.Combine(Startup.ContentRootPath,"Files","test.png");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes,"image/png");
        }

        public IActionResult JsonTest(){
            
            return Json(
                new {
                    product = "Iphone",
                    price = 10000
                }
            );
        }

        public IActionResult Privacy(){
            var url = Url.Action("Privacy", "Home");
            return LocalRedirect(url);
        }

        public IActionResult HelloView(string username){
            return View("hello",username);
        }

        public IActionResult ViewProduct(int? id){
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if(product ==null)
                return NotFound();
            
            return View(product);
            // return Content($"Product ID = {id}");
        }
    }
}