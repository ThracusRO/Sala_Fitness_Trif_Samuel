﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sala_Fitness_Trif_Samuel.Data;
using Sala_Fitness_Trif_Samuel.Models;

namespace Sala_Fitness_Trif_Samuel.Pages.Specializari
{
    public class IndexModel : PageModel
    {
        private readonly Sala_Fitness_Trif_Samuel.Data.Sala_Fitness_Trif_SamuelContext _context;

        public IndexModel(Sala_Fitness_Trif_Samuel.Data.Sala_Fitness_Trif_SamuelContext context)
        {
            _context = context;
        }

        public IList<Specializare> Specializare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Specializare = await _context.Specializare.ToListAsync();
        }
    }
}
