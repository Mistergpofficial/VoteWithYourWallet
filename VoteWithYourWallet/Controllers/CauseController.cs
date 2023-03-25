using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoteWithYourWallet.Models;
using VoteWithYourWallet.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace VoteWithYourWallet.Controllers
{
    [Authorize(Roles = "User")]
    public class CauseController : Controller
	{

        private VoteWithYourWalletIdentityDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CauseController(VoteWithYourWalletIdentityDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }



        // GET: Causes/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Category,Image,SignatureCount,UserId,Creator,Goal")] Cause cause, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null && Image.Length > 0)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "causes", "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }
                    cause.Image = $"/images/{fileName}";
                    cause.Goal = 10;
                }

                _context.causes.Add(cause);
                _context.SaveChanges();

                return Redirect("/Home/Index");
            }
            return View(cause);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            var causeById =  _context.causes.Include(c => c.User).Include(c => c.signatures).FirstOrDefault(c => c.Id == id);

            if (causeById == null )
            {
                return NotFound();
            }

            return View(causeById);
        }



        [HttpPost]
        public IActionResult Sign(int CauseId, string FullName, DateTime SignedDate, string UserId, string Reason)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Check if the user has already signed the cause
            Signature signature = _context.signatures.SingleOrDefault(s => s.CauseId == CauseId && s.UserId == userId);
            if (signature != null)
            {
                // User has already signed the cause, redirect to cause details page
                TempData["ErrorMessage"] = "You have already signed this cause.";
                return RedirectToAction("Details", "Cause", new { id = CauseId });
            }

            // User has not signed the cause yet, add signature to the database
            signature = new Signature
            {
                CauseId = CauseId,
                UserId = userId,
                Signer = FullName,
                SignedDate = DateTime.Now,
                Reason = Reason
            };
            _context.signatures.Add(signature);
            _context.SaveChanges();

            // Increment signature counts
            Cause cause = _context.causes.SingleOrDefault(c => c.Id == CauseId);
            if (cause != null)
            {
                cause.SignatureCount++;
                _context.SaveChanges();
            }

            // Redirect to cause details page
            TempData["SuccessMessage"] = "Thanks for signing!";
            return RedirectToAction("Details", "Cause", new { id = CauseId });
        }




    }
}

