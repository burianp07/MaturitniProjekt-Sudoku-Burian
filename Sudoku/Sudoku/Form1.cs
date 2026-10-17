using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private MenuStrip hlavniMenu;
        public Form1()
        {
            InitializeComponent();
            Text = "Sudoku";
            Width = 600;
            Height = 700;
            DoubleBuffered = true;

            hlavniMenu = new MenuStrip();
            ToolStripMenuItem polozkaNovaHra = new ToolStripMenuItem("Nová hra");
            ToolStripMenuItem polozkaUlozit = new ToolStripMenuItem("Uložit");
            ToolStripMenuItem polozkaNacist = new ToolStripMenuItem("Načíst");
            ToolStripMenuItem polozkaSkore = new ToolStripMenuItem("Skóre");
            ToolStripMenuItem polozkaObtiznost = new ToolStripMenuItem("Obtížnost");

            polozkaObtiznost.DropDownItems.Add("Lehká");
            polozkaObtiznost.DropDownItems.Add("Střední");
            polozkaObtiznost.DropDownItems.Add("Těžká");

            ToolStripMenuItem polozkaNapoveda = new ToolStripMenuItem("Nápověda");

            hlavniMenu.Items.Add(polozkaNovaHra);
            hlavniMenu.Items.Add(polozkaUlozit);
            hlavniMenu.Items.Add(polozkaNacist);
            hlavniMenu.Items.Add(polozkaSkore);
            hlavniMenu.Items.Add(polozkaObtiznost);
            hlavniMenu.Items.Add(polozkaNapoveda);

            Controls.Add(hlavniMenu);
            MainMenuStrip = hlavniMenu;
        }
     
    }
}
