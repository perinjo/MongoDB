using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.DomainModel;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Bson.IO;
using MongoDB.Driver.GridFS;

namespace MongoDriverTest
{
    public partial class FDodavanjeStadiona : Form
    {
        public FDodavanjeStadiona()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnUbaciSliku_Click(object sender, EventArgs e)
        {
            Image slika;
            FileStream fs;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fs = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                slika = Image.FromStream(fs);
                PbSlikaStadiona.Image = Image.FromStream(fs);

                /*int duzina = Convert.ToInt32(fs.Length);
                byte[] bajtovi = new byte[duzina];
                fs.Seek(0, SeekOrigin.Begin);
                int bytesRead = fs.Read(bajtovi, 0, duzina);*/
            }   
        }

        private void BtnSubmitData_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TbIme.Text))
            {
                MessageBox.Show("Ubacite ime stadiona!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbDrzava.Text) || String.IsNullOrWhiteSpace(TbGrad.Text))
            {
                MessageBox.Show("Unesite lokaciju stadiona (Drzavu i grad)!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbKapacitet.Text))
            {
                MessageBox.Show("Unesite kapacitet stadiona!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbVlasnik.Text))
            {
                MessageBox.Show("Unesite vlasnika stadiona!");
                return;
            }


        }
    }
}
