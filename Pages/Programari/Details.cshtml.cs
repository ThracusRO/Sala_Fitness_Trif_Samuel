﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sala_Fitness_Trif_Samuel.Data;
using Sala_Fitness_Trif_Samuel.Models;

namespace Sala_Fitness_Trif_Samuel.Pages.Programari
{
    public class DetailsModel : PageModel
    {
        private readonly Sala_Fitness_Trif_Samuel.Data.Sala_Fitness_Trif_SamuelContext _context;

        public DetailsModel(Sala_Fitness_Trif_Samuel.Data.Sala_Fitness_Trif_SamuelContext context)
        {
            _context = context;
        }

        public Programare Programare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programare = await _context.Programare.FirstOrDefaultAsync(m => m.ID == id);
            if (programare == null)
            {
                return NotFound();
            }
            else
            {
                Programare = programare;
            }
            return Page();
        }
    }
}
