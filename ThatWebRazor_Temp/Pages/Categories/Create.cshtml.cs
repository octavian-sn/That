using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThatWebRazor_Temp.Data;
using ThatWebRazor_Temp.Models;

namespace ThatWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["succes"] = "The category has been created successfully.";
            return RedirectToPage("Index");
        }
    }
}
