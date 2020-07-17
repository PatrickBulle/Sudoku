using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sudoku;
using SudokuSolver.Models;

namespace SudokuSolver.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISudoku _sudoku;

        public HomeController(ILogger<HomeController> logger, ISudoku sudoku)
        {
            _logger = logger;
            _sudoku = sudoku;
        }

        public IActionResult Index()
        {

            return View(_sudoku.GetGrille());
        }

        [HttpPost]
        public bool Init(int[][] value)
        {
            Cellule[][] cellules = new Cellule[value.Length][];
            for(int i = 0; i < value.Length; i++)
            {
                Cellule[] row = new Cellule[value[i].Length];
                for (int j = 0; j < value[i].Length; j++)
                {
                    Cellule cell = new Cellule(value[i][j]);
                    row[j] = cell;
                }
                cellules[i] = row;
            }

            bool isOk = _sudoku.InitGrille(cellules);
            return isOk;
            
        }
        [HttpPost]
        public bool SetValeurCellule(int posX, int posY, int value)
        {
            bool isOk = _sudoku.SetCellule(posX, posY, value);
            return isOk;
        }

        [HttpPost]
        public Cellule[][] Resoudre()
        {
            Cellule[][] mesCellules = _sudoku.ResoudreGrille();
            return mesCellules;
        }

        [HttpPost]
        public Cellule ResoudreCellule(int posX, int posY)
        {
            Cellule maCellule = _sudoku.ResoudreCellule(posX, posY);
            return maCellule;
        }

        [HttpPost]
        public void Restaurer()
        {
            _sudoku.RestaurerGrille();
        }

        [HttpPost]
        public void Vider()
        {
            _sudoku.ViderGrille();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
