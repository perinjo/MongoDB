using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Bson.IO;
using MongoDB.Driver.GridFS;
using MongoDB.DomainModel;
using System.IO;

namespace MongoDriverTest.DomainModel
{
    public partial class FDodavanjeTrenera : Form
    {
        public FDodavanjeTrenera()
        {
            InitializeComponent();
        }

        // ---- Ucitavanje slike -----
        private void BtnUcitajSlikuTrenera_Click(object sender, EventArgs e)
        {
            Image slika;
            FileStream fs;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fs = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                slika = Image.FromStream(fs);
                PbSlikaTrenera.Image = Image.FromStream(fs);

                /*int duzina = Convert.ToInt32(fs.Length);
                byte[] bajtovi = new byte[duzina];
                fs.Seek(0, SeekOrigin.Begin);
                int bytesRead = fs.Read(bajtovi, 0, duzina);*/
            }   
        }

        // ---- Ubacivanje podataka u bazi ----
        private void BtnSubmitData_Click(object sender, EventArgs e)
        {
            // ---- Provera ispravnosti podataka ----
            if (String.IsNullOrWhiteSpace(TbPunoIme.Text))
            {
                MessageBox.Show("Unesi Puno ime trenera!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbMestoRodjenja.Text))
            {
                MessageBox.Show("Unesi mesto rodjenja trenera!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbTrenutniKlub.Text))
            {
                MessageBox.Show("Unesi trenutni klub(reprezentaciju) koju trenira trener!");
                return;
            }
        }
    }
}
