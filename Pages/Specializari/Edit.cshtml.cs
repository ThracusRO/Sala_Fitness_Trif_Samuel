﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sala_Fitness_Trif_Samuel.Data;
using Sala_Fitness_Trif_Samuel.Models;

namespace Sala_Fitness_Trif_Samuel.Pages.Specializari
{
    public class EditModel : PageModel
    {
        private readonly Sala_Fitness_Trif_Samuel.Data.Sala_Fitness_Trif_SamuelContext _context;

        public EditModel(Sala_Fitness_Trif_Samuel.Data.Sala_Fitness_Trif_SamuelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Specializare Specializare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specializare =  await _context.Specializare.FirstOrDefaultAsync(m => m.ID == id);
            if (specializare == null)
            {
                return NotFound();
            }
            Specializare = specializare;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Specializare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializareExists(Specializare.ID))
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

        private bool SpecializareExists(int id)
        {
            return _context.Specializare.Any(e => e.ID == id);
        }
    }
}
