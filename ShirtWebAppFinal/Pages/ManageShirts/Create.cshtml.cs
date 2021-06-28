using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShirtWebAppFinal.Data;
using ShirtWebAppFinal.Models;

namespace ShirtWebAppFinal.Pages.ManageShirts
{
    public class CreateModel : PageModel
    {
        private readonly ShirtWebAppFinal.Data.ApplicationContext _context;

        public CreateModel(ShirtWebAppFinal.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ShirtModel ShirtModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ShirtModel.Add(ShirtModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
