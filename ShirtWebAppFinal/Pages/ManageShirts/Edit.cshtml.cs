using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShirtWebAppFinal.Data;
using ShirtWebAppFinal.Models;

namespace ShirtWebAppFinal.Pages.ManageShirts
{
    public class EditModel : PageModel
    {
        private readonly ShirtWebAppFinal.Data.ApplicationContext _context;

        public EditModel(ShirtWebAppFinal.Data.ApplicationContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ShirtModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShirtModelExists(ShirtModel.ShirtModelId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShirtModelExists(int id)
        {
            return _context.ShirtModel.Any(e => e.ShirtModelId == id);
        }
    }
}
