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
        private DeskaSudoku herniDeska;
        private int vybranyRadek;
        private int vybranySloupec;
        public Form1()
        {
            InitializeComponent();
            herniDeska = new DeskaSudoku();
            vybranyRadek = -1;
            vybranySloupec = -1;
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
            platnoHry.MouseClick += PlatnoHry_MouseClick;
            platnoHry.BringToFront();
        }
        private void PlatnoHry_Paint(object sender, PaintEventArgs e)
        {
            Graphics grafika = e.Graphics;
            grafika.Clear(Color.White);

            float velikostBunky = Math.Min(platnoHry.Width, platnoHry.Height) / 9f;

            // 1. Vykreslení podbarvení a čísel 
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    RectangleF vykreslovaciObdelnik = new RectangleF(j * velikostBunky, i * velikostBunky, velikostBunky, velikostBunky);

                    if (i == vybranyRadek && j == vybranySloupec)
                    {
                        grafika.FillRectangle(Brushes.LightBlue, vykreslovaciObdelnik);
                    }

                    if (herniDeska.Mrizka[i, j].Hodnota > 0)
                    {
                        Font pismo = new Font("Arial", velikostBunky * 0.5f, FontStyle.Bold);
                        StringFormat formatZarovnani = new StringFormat();
                        formatZarovnani.Alignment = StringAlignment.Center;
                        formatZarovnani.LineAlignment = StringAlignment.Center;

                        grafika.DrawString(herniDeska.Mrizka[i, j].Hodnota.ToString(), pismo, Brushes.Black, vykreslovaciObdelnik, formatZarovnani);
                    }
                }
            }

            // 2. Vykreslení sítě čar 
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
        private void PlatnoHry_MouseClick(object sender, MouseEventArgs e)
        {
            float velikostBunky = Math.Min(platnoHry.Width, platnoHry.Height) / 9f;
            int radek = (int)(e.Y / velikostBunky);
            int sloupec = (int)(e.X / velikostBunky);

            if (radek >= 0 && radek < 9 && sloupec >= 0 && sloupec < 9)
            {
                vybranyRadek = radek;
                vybranySloupec = sloupec;
                platnoHry.Invalidate();
            }
        }
    }
}
