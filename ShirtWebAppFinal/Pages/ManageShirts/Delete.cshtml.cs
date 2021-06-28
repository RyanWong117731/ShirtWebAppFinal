using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShirtWebAppFinal.Data;
using ShirtWebAppFinal.Models;

namespace ShirtWebAppFinal.Pages.ManageShirts
{
    public class DeleteModel : PageModel
    {
        private readonly ShirtWebAppFinal.Data.ApplicationContext _context;

        public DeleteModel(ShirtWebAppFinal.Data.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShirtModel ShirtModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShirtModel = await _context.ShirtModel.FirstOrDefaultAsync(m => m.ShirtModelId == id);

            if (ShirtModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShirtModel = await _context.ShirtModel.FindAsync(id);

            if (ShirtModel != null)
            {
                _context.ShirtModel.Remove(ShirtModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
