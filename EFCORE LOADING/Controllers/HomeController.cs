using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFCORE_LOADING.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCORE_LOADING.Controllers;

public class HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        //load villa
        var villas = dbContext.Villas;// lazy loading - default behaviour child elements not loaded
      //if we load child - n+1 problem
        
       var total = villas.Count(); //query executed here
     // Console.WriteLine(total);
     
     
     //eager loading - load child elements too

     var eager_villas = dbContext.Villas.Include(x => x.VillaAmeneties).ToList();  //it will take
                                                                             //villa and left join with include table i.e villa amenities
                                                                             
     
     //eager loading - load all data in one request 
     
     
     // explicit load loads explicitly loads navigation property 
     var viola = dbContext.Villas.FirstOrDefault(x => x.ID == 1);
     dbContext.Entry(viola).Collection(x => x.VillaAmeneties).Load();

     var amenity = dbContext.VillaAmeneties.FirstOrDefault(x => x.Id == 2);
     dbContext.Entry(amenity).Reference(x => x.Villa).Load();
     
     
        return View();

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}