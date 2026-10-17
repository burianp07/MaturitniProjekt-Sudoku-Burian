using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class BunkaSudoku
    {
        public int Hodnota { get; set; }
        public bool JePevna { get; set; }
        public bool[] Poznamky { get; set; }

        public BunkaSudoku()
        {
            Hodnota = 0;
            JePevna = false;
            Poznamky = new bool[10];
        }
    }
}
