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
    public class IndexModel : PageModel
    {
        private readonly ShirtWebAppFinal.Data.ApplicationContext _context;

        public IndexModel(ShirtWebAppFinal.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IList<ShirtModel> ShirtModel { get;set; }

        public async Task OnGetAsync()
        {
            ShirtModel = await _context.ShirtModel.ToListAsync();
        }
    }
}
