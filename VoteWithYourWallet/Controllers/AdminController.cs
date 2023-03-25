using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoteWithYourWallet.Areas.Identity.Data;
using VoteWithYourWallet.Models;


namespace VoteWithYourWallet.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<Register> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private VoteWithYourWalletIdentityDbContext _context;

        public AdminController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<Register> logger, VoteWithYourWalletIdentityDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
            _context = context;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            // we retrieve all causes from the database, including their associated users, using the Include method to eagerly load the related entities
            var causeList = _context.causes.Include(c => c.User).Include(c => c.signatures).ToList();
           
            return View(causeList);
        }


      
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


    
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Login", "Admin");
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int causeId)
        {
            var cause = await _context.causes.FindAsync(causeId);
            //var signature = await _context.signatures.FindAsync(id);
            if (cause == null)
            {
                return NotFound();
            }

            // Delete associated signatures
            var signatures = await _context.signatures.Where(s => s.CauseId == causeId).ToListAsync();
            _context.signatures.RemoveRange(signatures);

            // Delete the cause
            _context.causes.Remove(cause);
            await _context.SaveChangesAsync();
            // Redirect to cause details page
            TempData["SuccessMessage"] = "Cause has been deleted!";
            return Redirect("/Admin/Index");
        }


    }

}

