﻿using System;
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
using MongoDriverTest.DomainModel;

namespace MongoDriverTest
{
    public partial class FDodavanjeStadiona : Form
    {
        private Image slikaStadiona;
        private string format;
        private string imeSlike;
        public FDodavanjeStadiona()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnUbaciSliku_Click(object sender, EventArgs e)
        {
            //Image slika;
            FileStream fs;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var forSpliting = ofd.SafeFileName.Split('.');
                imeSlike = forSpliting[0];
                format = forSpliting[1];

                fs = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                slikaStadiona = Image.FromStream(fs);
                PbSlikaStadiona.Image = Image.FromStream(fs);

                /*int duzina = Convert.ToInt32(fs.Length);
                byte[] bajtovi = new byte[duzina];
                fs.Seek(0, SeekOrigin.Begin);
                int bytesRead = fs.Read(bajtovi, 0, duzina);*/
            }   
        }

        private void BtnSubmitData_Click(object sender, EventArgs e)
        {
            try
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
                Stadion forSave = new Stadion();
                forSave.Ime = StringCleaner.checkString(TbIme.Text);
                forSave.Istorija = StringCleaner.checkString(RtbIstorija.Text);
                forSave.Kapacitet = StringCleaner.checkString(TbKapacitet.Text);
                forSave.Lokacija = StringCleaner.checkString(TbDrzava.Text) + "," + StringCleaner.checkString(TbGrad.Text);
                forSave.Vlasnik = StringCleaner.checkString(TbVlasnik.Text);


                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");

                var collection = _database.GetCollection<BsonDocument>("stadioni");
                var filter = new BsonDocument()
                {
                    {"Ime",TbIme.Text}
                };
                var document = forSave.ToBsonDocument();

                var filterForUniqueCheck = Builders<BsonDocument>.Filter.Eq("Ime", TbIme.Text);


                //test if  exists
                var test = collection.Find(filterForUniqueCheck).Count();
                if (test == 0)
                {
                    AuxLib.AddImageToGridFS(slikaStadiona, this.TbIme.Text + "stadion", format);
                    collection.InsertOne(document);
                    MessageBox.Show("Uspesno dodat novi stadion!");
                }
                else
                {
                    //TO DO : Napraviti u AuxLib remove image i remove song za brisanje i ovde implementirati brisanje te slike i dodavanje nove. ( kao update )
                    collection.ReplaceOne(filter, document);
                    MessageBox.Show("Uspesno azuriran stadion!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
