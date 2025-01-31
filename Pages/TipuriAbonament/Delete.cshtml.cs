using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sala_Fitness_Trif_Samuel.Data;
using Sala_Fitness_Trif_Samuel.Models;

namespace Sala_Fitness_Trif_Samuel.Pages.TipuriAbonament
{
    public class DeleteModel : PageModel
    {
        private readonly Sala_Fitness_Trif_Samuel.Data.Sala_Fitness_Trif_SamuelContext _context;

        public DeleteModel(Sala_Fitness_Trif_Samuel.Data.Sala_Fitness_Trif_SamuelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TipAbonament TipAbonament { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipabonament = await _context.TipAbonament.FirstOrDefaultAsync(m => m.ID == id);

            if (tipabonament == null)
            {
                return NotFound();
            }
            else
            {
                TipAbonament = tipabonament;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipabonament = await _context.TipAbonament.FindAsync(id);
            if (tipabonament != null)
            {
                TipAbonament = tipabonament;
                _context.TipAbonament.Remove(TipAbonament);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
