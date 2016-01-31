using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDriverTest
{
    public partial class FBrisanjeIzmenaPodataka : Form
    {
        public FBrisanjeIzmenaPodataka()
        {
            InitializeComponent();
        }

        private void BtnIzbrisiIgraca_Click(object sender, EventArgs e)
        {
            if (LvIgraci.SelectedItems.Count != 0)
            {

                // ---- Izbaci igraca iz listView ----
                LvIgraci.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izbrises!");
            }
        }

        private void BtnIzmeniIgraca_Click(object sender, EventArgs e)
        {
            if (LvIgraci.SelectedItems.Count != 0)
            {

            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izmenis!");
            }
        }

        private void BtnIzbrisiReprezentaciju_Click(object sender, EventArgs e)
        {
            if (LvReprezentacije.SelectedItems.Count != 0)
            {

                // ---- Izbaci igraca iz listView ----
                LvReprezentacije.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izbrises!");
            }
        }

        private void BtnIzmeniReprezentaciju_Click(object sender, EventArgs e)
        {
            if (LvReprezentacije.SelectedItems.Count != 0)
            {

            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izmenis!");
            }
        }

        private void BtnIzbrisiTakmicenje_Click(object sender, EventArgs e)
        {
            if (LvTakmicanja.SelectedItems.Count != 0)
            {

                // ---- Izbaci igraca iz listView ----
                LvTakmicanja.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izbrises!");
            }
        }

        private void BtnIzmeniTakmicenje_Click(object sender, EventArgs e)
        {
            if (LvTakmicanja.SelectedItems.Count != 0)
            {

            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izmenis!");
            }
        }
    }
}
