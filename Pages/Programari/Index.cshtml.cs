using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sala_Fitness_Trif_Samuel.Data;
using Sala_Fitness_Trif_Samuel.Models;

namespace Sala_Fitness_Trif_Samuel.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly Sala_Fitness_Trif_Samuel.Data.Sala_Fitness_Trif_SamuelContext _context;

        public IndexModel(Sala_Fitness_Trif_Samuel.Data.Sala_Fitness_Trif_SamuelContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; } = default!;

        public string? DataSort { get; set; } // variabila pentru starea de sortare

        /*Search*/
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } = string.Empty; // Camp pentru cautare
        /*--*/
        public async Task OnGetAsync(string? sortOrder)
        {
            // Determinam ordinea de sortare
            DataSort = sortOrder == "date_desc" ? "date_asc" : "date_desc";

            Programare = await _context.Programare
                .Include(p => p.Antrenor)
                .Include(p => p.Utilizator).ToListAsync();

           /* Search begin */
            var programariQuery = _context.Programare
                .Include(p => p.Antrenor)
                .Include(p => p.Utilizator)
                .AsQueryable();

            // Aplica filtrul dacă SearchString nu este gol
            if (!string.IsNullOrEmpty(SearchString))
            {
                programariQuery = programariQuery.Where(p =>
                    p.Utilizator.Nume.Contains(SearchString) ||
                    p.Utilizator.Prenume.Contains(SearchString) ||
                    p.Antrenor.Nume.Contains(SearchString) ||
                    p.Antrenor.Prenume.Contains(SearchString));
            }


            // Aplicam sortarea în functie de sortOrder
            switch (sortOrder)
            {
                case "date_asc":
                    programariQuery = programariQuery.OrderBy(p => p.DataProgramare);
                    break;
                case "date_desc":
                    programariQuery = programariQuery.OrderByDescending(p => p.DataProgramare);
                    break;

            }
                    Programare = await programariQuery.ToListAsync();
           /* */
        }
    }
}
