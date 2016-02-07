using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MongoDriverTest
{
    public partial class FFudbalskaIgra : Form
    {
        public FFudbalskaIgra()
        {
            InitializeComponent();
        }

        Thread simulacijaUtakmice;

        public void updateMinut(string minut)
        {
            Minuti.Text = minut;
        }

        public void updateDomacinRez(string brojGolova)
        {
            RezultatDomacin.Text = brojGolova;
        }

        public void updateGostRez(string brojGolova)
        {
            RezultatGost.Text = brojGolova;
        }

        public void updateTeamDomacin(string skillPostave)
        {
            string[] skilovi = skillPostave.Split(',');
            string textOutput = "";
            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    textOutput += "GK";
                }
                else if (i < 5)
                {
                    textOutput += "DF";
                }
                else if (i < 9)
                {
                    textOutput += "MF";
                }
                else if (i < 11)
                {
                    textOutput += "CF";
                }

                textOutput += "   " + skilovi[i] ;
            }
             
        }

        public void updateTeamGost(string skillPostave)
        {
            string[] skilovi = skillPostave.Split(',');
            string textOutput = "";
            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    textOutput += "GK";
                }
                else if (i < 5)
                {
                    textOutput += "DF";
                }
                else if (i < 9)
                {
                    textOutput += "MF";
                }
                else if (i < 11)
                {
                    textOutput += "CF";
                }

                textOutput += "   " + skilovi[i];
            }
        }

        public void updateDogadjaji(string dogadjaj)
        {
            string outputText = dogadjaj + Environment.NewLine;
            outputText += Environment.NewLine + RtbDogadjaji.Text;
            RtbDogadjaji.Text = outputText;
        }

        private void BtnSimulacijaUtakmice_Click(object sender, EventArgs e)
        {
            ScoreBoard.Visible = true;
            /*RtbDogadjaji.Enabled = true;
            RtbSastavDomacin.Enabled = true;
            RtbSastavGost.Enabled = true;*/
            if (!simulacijaUtakmice.IsAlive)
            {
                AlgoritamSimulacije algo = new AlgoritamSimulacije(this);
                simulacijaUtakmice = new Thread(new ThreadStart(algo.simulirajUtakmicu));
                simulacijaUtakmice.Start();
            }
        }

        private void FFudbalskaIgra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (simulacijaUtakmice.IsAlive)
            {
                simulacijaUtakmice.Abort();
            }
        }
    }
}
