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
            Cellule[][] cellules    = new Cellule[9][];
            Cellule Vide     = new Cellule(){Valeur = 0, EstTrouve = false, EstValeurInitiale = false};
            Cellule Un       = new Cellule(){Valeur = 1, EstTrouve = false, EstValeurInitiale = true};
            Cellule Deux     = new Cellule(){Valeur = 2, EstTrouve = false, EstValeurInitiale = true };
            Cellule Trois    = new Cellule(){Valeur = 3, EstTrouve = false, EstValeurInitiale = true };
            Cellule Quatre   = new Cellule(){Valeur = 4, EstTrouve = false, EstValeurInitiale = true };
            Cellule Cinq     = new Cellule(){Valeur = 5, EstTrouve = false, EstValeurInitiale = true };
            Cellule Six      = new Cellule(){Valeur = 6, EstTrouve = false, EstValeurInitiale = true };
            Cellule Sept     = new Cellule(){Valeur = 7, EstTrouve = false, EstValeurInitiale = true };
            Cellule Huit     = new Cellule(){Valeur = 8, EstTrouve = false, EstValeurInitiale = true };
            Cellule Neuf     = new Cellule(){Valeur = 9, EstTrouve = false, EstValeurInitiale = true };
            cellules[0] = new Cellule[9] { Vide, Vide, Six, Deux, Vide, Vide, Vide, Huit, Vide };
            cellules[1] = new Cellule[9] { Vide, Vide, Huit, Neuf, Sept, Vide, Vide, Vide, Vide };
            cellules[2] = new Cellule[9] { Vide, Vide, Quatre, Huit, Un, Vide, Cinq, Vide, Vide };
            cellules[3] = new Cellule[9] { Vide, Vide, Vide, Vide, Six, Vide, Vide, Vide, Deux };
            cellules[4] = new Cellule[9] { Vide, Sept, Vide, Vide, Vide, Vide, Vide, Trois, Vide };
            cellules[5] = new Cellule[9] { Six, Vide, Vide, Vide, Cinq, Vide, Vide, Vide, Vide };
            cellules[6] = new Cellule[9] { Vide, Vide, Deux, Vide, Quatre, Sept, Un, Vide, Vide };
            cellules[7] = new Cellule[9] { Vide, Vide, Trois, Vide, Deux, Huit, Quatre, Vide, Vide };
            cellules[8] = new Cellule[9] { Vide, Cinq, Vide, Vide, Vide, Un, Deux, Vide, Vide };
            return View(cellules);
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
                    Cellule cell = new Cellule();
                    cell.Valeur = value[i][j];
                    cell.EstValeurInitiale = true;
                    cell.EstTrouve = false;
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
