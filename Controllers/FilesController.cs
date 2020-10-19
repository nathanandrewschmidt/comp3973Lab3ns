using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVClab2.Models;
using Microsoft.AspNetCore.Hosting;

namespace MVClab2.Controllers
{
    public class FilesController : Controller
    {
        private readonly ILogger<FilesController> _logger;
        private readonly IWebHostEnvironment _env;

        public FilesController(ILogger<FilesController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            String[] files = Directory.GetFiles(".\\TextFiles");
            ViewBag.files = files;
            return View();
        }

        public new IActionResult Content(String id)
        {
            String textPath = _env.ContentRootPath + "/TextFiles/" + id + ".txt";
            String text = System.IO.File.ReadAllText(textPath);
            return View("Views/Files/Content.cshtml", text);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
