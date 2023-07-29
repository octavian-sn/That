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
            Category categoryFromDb = _db.Categories.Find(id);
            Category = categoryFromDb;
        }
        public IActionResult OnPost() 
        {
            _db.Categories.Update(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
