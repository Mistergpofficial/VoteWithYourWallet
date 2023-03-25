using System;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoteWithYourWallet.Areas.Identity.Data;
using VoteWithYourWallet.Models;

namespace VoteWithYourWallet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private VoteWithYourWalletIdentityDbContext _context;


    public HomeController(ILogger<HomeController> logger, VoteWithYourWalletIdentityDbContext context)
    {
        _logger = logger;
        _context = context;
    }

   
    public IActionResult Index()
    {
        // we retrieve all causes from the database, including their associated users, using the Include method to eagerly load the related entities
        //IEnumerable<Cause> causes = _context.causes.ToList();
       var causeList = _context.causes.Include(c => c.User).Include(c => c.signatures).ToList();
       // ViewBag.Causes = causeList;
        return View(causeList);
        // var causeList = _context.causes.Include(c => c.signatures);



       // return View();
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

