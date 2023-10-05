using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QwikThrift.Models;
using QwikThrift.Models.DAL;
using System.Reflection;

namespace QwikThrift.Pages.MyListings
{
    public class AddImagesModel : PageModel
    {
        private QwikThriftDbContext _dbContext;

        [BindProperty]
        public IFormFileCollection ImageFiles { get; set; } = new FormFileCollection();

        [BindProperty]
        public int ListingId {  get; set; }

        public PageMode Mode { get; set; } = PageMode.Create;

        public AddImagesModel(QwikThriftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet(int id)
        {
            //check for user logged in
            var userMan = new UserManager(HttpContext.Session, _dbContext);
            if (!userMan.UserLoggedIn) return RedirectToPage("/Users/Login");

            var user = userMan.User;
            if (user == null) return RedirectToPage("/Users/Login");

            //lookup listing Id
            var listing = _dbContext.Listings.FirstOrDefault(l => l.ListingId == id); 
            ListingId = id;

            //verfy valid listing
            if (listing == null) return NotFound();

            //verify logged in user owns listing
            if (listing.OwnerId != user.UserId) return RedirectToPage("/AccessDenied");

            return Page();
        }

        public IActionResult OnPost()
        {
            //check for user logged in
            var userMan = new UserManager(HttpContext.Session, _dbContext);
            if (!userMan.UserLoggedIn) return RedirectToPage("/AccessDenied");

            //get user object
            var user = userMan.User;
            if (user == null) return RedirectToPage("/AccessDenied");

            //get listing
            var listing = _dbContext.Listings.FirstOrDefault(l => l.ListingId == ListingId);

            //verfy valid listing
            if (listing == null) return NotFound();

            //create ImageReferences in database and upload images to server
            foreach (var image in ImageFiles)
            {
                string filename = listing.Owner.Username.Replace(' ', '_') + '_' + listing.Title.Replace(' ', '_') + '_' +
                    DateTime.Now.ToString("yymmssfff") + Path.GetExtension(image.FileName);
                string path = "\\images\\listingsInDev\\" + listing.ListingId.ToString() + "\\";

                var imageRef = new ImageReference
                {
                    ListingId = listing.ListingId,
                    Filename = filename,
                    Name = image.FileName,
                    Path = path,
                    Description = $"Image from listing titled \"{listing.Title}\"",
                    ImageFile = image,
                };

                if (!imageRef.SaveImageToFile())
                    throw new Exception("Image file failed to save to the server");

                _dbContext.ImageReferences.Add(imageRef);
            }

            _dbContext.SaveChanges();

            //send user back add/edit images page.
            return RedirectToPagePermanent("/MyListings/AddImages", new { id = listing.ListingId});
        }

        public IActionResult OnPostRemoveImage(int imageId)
        {
            //check for user logged in
            var userMan = new UserManager(HttpContext.Session, _dbContext);
            if (!userMan.UserLoggedIn) return RedirectToPage("/AccessDenied");

            //get user object
            var user = userMan.User;
            if (user == null) return RedirectToPage("/AccessDenied");

            //get listing
            var listing = _dbContext.Listings.FirstOrDefault(l => l.ListingId == ListingId);

            //verfy valid listing
            if (listing == null) return NotFound();

            //get ImageReference
            var imageRef = _dbContext.ImageReferences.FirstOrDefault(ir => ir.ImageReferenceId == imageId);
            if (imageRef == null) return NotFound();

            imageRef.DeleteImageFromFile();
            _dbContext.ImageReferences.Remove(imageRef);
            _dbContext.SaveChanges();

            //send user back add/edit images page.
            return RedirectToPagePermanent("/MyListings/AddImages", new { id = listing.ListingId });
        }

        public IActionResult OnPostDone()
        {
            //get listing
            var listing = _dbContext.Listings.FirstOrDefault(l => l.ListingId == ListingId);

            //verfy valid listing
            if (listing == null) return NotFound();

            var mode = Mode == PageMode.Create ? "posted" : "edited"; 

            NotificationBanner.SetBanner($"Your listing titled \"{listing.Title}\" has been {mode} successfully!",
                "bg-success text-center text-white");

            return RedirectToPagePermanent("/MyListings/Index");
        }
    }
}
