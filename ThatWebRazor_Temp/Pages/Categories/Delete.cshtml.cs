using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThatWebRazor_Temp.Data;
using ThatWebRazor_Temp.Models;

namespace ThatWebRazor_Temp.Pages.Categories
{
    //BINDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
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
            //Category categoryFromDb = _db.Categories.Find(Category);
            if (Category == null) return NotFound();
            _db.Categories.Remove(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
