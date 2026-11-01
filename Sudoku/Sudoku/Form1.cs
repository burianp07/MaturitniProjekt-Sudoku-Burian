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
        private PictureBox platnoHry;
        public Form1()
        {
            InitializeComponent();
            Text = "Sudoku";
            Width = 600;
            Height = 700;
            DoubleBuffered = true;
            //menu
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
            //plocha
            platnoHry = new PictureBox();
            platnoHry.Dock = DockStyle.Fill;
            Controls.Add(platnoHry);
            platnoHry.Paint += PlatnoHry_Paint;
        }
        private void PlatnoHry_Paint(object sender, PaintEventArgs e)
        {
            Graphics grafika = e.Graphics;
            grafika.Clear(Color.White);

            float velikostBunky = Math.Min(platnoHry.Width, platnoHry.Height) / 9f;

            for (int i = 0; i <= 9; i++)
            {
                Pen pero;
                if (i % 3 == 0)
                {
                    pero = new Pen(Color.Black, 3);
                }
                else
                {
                    pero = new Pen(Color.Gray, 1);
                }

                grafika.DrawLine(pero, 0, i * velikostBunky, 9 * velikostBunky, i * velikostBunky);
                grafika.DrawLine(pero, i * velikostBunky, 0, i * velikostBunky, 9 * velikostBunky);
            }
        }
    }
}
