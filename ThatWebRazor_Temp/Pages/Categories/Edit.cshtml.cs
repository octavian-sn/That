using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThatWebRazor_Temp.Data;
using ThatWebRazor_Temp.Models;

namespace ThatWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            if (id != 0 && id != null)
            {
            Category categoryFromDb = _db.Categories.Find(id);
            Category = categoryFromDb;
            }
        }
        public IActionResult OnPost() 
        {
            if(ModelState.IsValid) 
            {
            _db.Categories.Update(Category);
            _db.SaveChanges();
                TempData["success"] = "The category has been edited succesfully.";
            return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
