using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class DeskaSudoku
    {
        public BunkaSudoku[,] Mrizka { get; set; }

        public DeskaSudoku()
        {
            Mrizka = new BunkaSudoku[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Mrizka[i, j] = new BunkaSudoku();
                }
            }
        }
    }
}
