﻿using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.DomainModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace MongoDriverTest
{
    public partial class FReprezentacija : Form
    {
        private Igrac elKapetano;
        private bool testData;
        public FReprezentacija()
        {
            InitializeComponent();
            elKapetano = null;
            testData = false;
        }

       

        //update liste igraca
        private async void UpdateListView()
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<BsonDocument>("igraci");
            var filter = new BsonDocument();

            var result = await collection.Find(filter).ToListAsync();

            foreach (BsonDocument doc in result)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                var json = doc.ToJson(jsonWriterSettings);
                Igrac r = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(json);

                ListViewItem lv1 = new ListViewItem(r.id.ToString());
                lv1.SubItems.Add(r.PunoIme);
                lv1.SubItems.Add(r.DatumRodjenja.ToString());
                lv1.SubItems.Add(r.Pozicija);
                lv1.SubItems.Add(r.TrenutniKlub);

                LVSviIgrac.Items.Add(lv1);
            }
        }
        private void FReprezentacija_Load(object sender, EventArgs e)
        {

            UpdateListView();
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // PROVERAVA PO IMENU AKO IME NIJE UNIQUE NECE MOCI DVA SA ISTIM IMENOM U SASTAV
            if(this.LVSviIgrac.SelectedItems.Count != 0)
            {
                if(this.LVSastav.Items.Count == 30)
                {
                    MessageBox.Show("Sastav popunjen.");
                    return;
                }
                bool postoji = false;
                var test = this.LVSviIgrac.SelectedItems[0];
                foreach(ListViewItem item in LVSastav.Items)
                {
                    if(item.Text == test.Text)
                    {
                        postoji = true;
                    }
                }
                if(!postoji)
                {
                    var klon = test.Clone();
                    this.LVSastav.Items.Add((ListViewItem)klon);
                }
            }
            

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.LVSastav.SelectedItems.Count != 0)
            {
                for (int i = 0; i < this.LVSastav.Items.Count; i++)
                {
                    if (this.LVSastav.Items[i].Text == this.LVSastav.SelectedItems[0].Text)
                    {
                        this.LVSastav.Items.RemoveAt(i);
                    }
                }
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.LVSastav.SelectedItems.Count != 0)
            {
                //long id = Convert.ToInt64(this.LVSastav.SelectedItems[0].Text);
                string id = this.LVSastav.SelectedItems[0].Text;
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");
                var collection = _database.GetCollection<BsonDocument>("igraci");
                var filter = new BsonDocument() 
                {
                    {"id",id}
                };
                //var count = 0;
                var cursor = collection.Find(filter);
                var lista = cursor.ToList();

                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                //JObject json = JObject.Parse(prvi.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings));

                var prvi = lista.First().ToJson(jsonWriterSettings);
                Igrac r = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(prvi);

                elKapetano = r;


                MessageBox.Show("Pronadjen  " + r.PunoIme);
                //upit u bazu sa filterom
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.tbIme.Text == "")
            {
                MessageBox.Show("Ime reprezentacije je obavezno!");
                return;
            }
            if (this.tbSkracenica.Text == "")
            {
                MessageBox.Show("Skracenica je obavezna!(3 slova)");
                return;
            }
            if (this.tbSelektor.Text == "")
            {
                MessageBox.Show("Selektor je obavezan!");
                return;
            }
            if (this.LVSastav.Items.Count < 11)
            {
                MessageBox.Show("Sastav je nepotpun!");
                return;
            }
            if(elKapetano == null)
            {
                MessageBox.Show("Morate izabrati kapitena!");
                return;
            }
            //database access
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            var collection = _database.GetCollection<BsonDocument>("reprezentacija");
            //filters
            var filterAllCount = new BsonDocument();
            var filterForUniqueCheck = Builders<BsonDocument>.Filter.Eq("Ime", this.tbIme.Text); 
            

            //test if reprezentacija exists
            var test = collection.Find(filterForUniqueCheck).Count();
            if(test != 0)
            {
                var reprez = collection.Find(filterForUniqueCheck).First();
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

                Reprezentacija rep = Newtonsoft.Json.JsonConvert.DeserializeObject<Reprezentacija>(reprez.ToJson(jsonWriterSettings));
                
            }
            var countForID = collection.Count(filterAllCount);

            // model creating
            Reprezentacija forSave = new Reprezentacija();
            forSave.FifaRang = Convert.ToInt32(numFifaRang.Value);
            if(test == 0)
            {
                forSave.id = countForID;
            }
            
            forSave.IgracSaNajviseNastupa = StringCleaner.checkString(this.tbIgracSaNajviseNastupa.Text);
            forSave.Ime = StringCleaner.checkString(this.tbIme.Text);
            forSave.Kapiten = StringCleaner.checkString(elKapetano.PunoIme);
            forSave.Nadimak = StringCleaner.checkString(tbNadimak.Text);
            forSave.NajboljiStrelac = StringCleaner.checkString(this.tbNadimak.Text);
            forSave.NajvecaPobedaPoraz = StringCleaner.checkString(this.tbNajvecaPobedaPoraz.Text);
            forSave.OsvojeneMedalje = StringCleaner.checkString(this.rtbOsvojeneMedalje.Text);
            foreach (ListViewItem item in this.LVSastav.Items)
            {
                forSave.Sastav += item.SubItems[1].Text;
                forSave.Sastav += ",";
            }
            forSave.Sastav = forSave.Sastav.TrimEnd(',');
            forSave.Selektor = StringCleaner.checkString(tbSelektor.Text);
            forSave.Skracenica = StringCleaner.checkString(tbSkracenica.Text);
            forSave.SportskaBiografija = StringCleaner.checkString(rtbSportskaBiografija.Text);

            
            //Serialization and BsonDocument creation
            var document = BsonDocument.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(forSave));
            
            // insert or update check.
            if (test == 0) 
            {
                collection.InsertOne(document);
                MessageBox.Show("Reprezentacija :" + forSave.Ime + " uspesno dodata.");
            }
            else
            {
                //var filter = Builders<BsonDocument>.Filter.Eq("name", "Juni");
                //var update = Builders<BsonDocument>.Update
                //    .Set("Ime", "American (New)")
                //    .CurrentDate("lastModified")
                //    .Set("","");
                //var result = await collection.UpdateOneAsync(filter, update);

                //collection.UpdateOne(filterForUniqueCheck, document);
                collection.ReplaceOne(filterForUniqueCheck, document);
                MessageBox.Show("Reprezentacija :" + forSave.Ime + " uspesno azurirana.");
            }
            //reset kapetana na null
            elKapetano = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!testData)
            {
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");
                var collection = _database.GetCollection<BsonDocument>("igraci");
                var filter = new BsonDocument();

               

                for(int i = 0 ; i < 11 ; i++)
                {
                    var test = collection.Count(filter);
                    var document = new BsonDocument
                    {
                   
                        {"id",test.ToString()},
                        {"PunoIme","Test"+test.ToString()},
                        {"Pozicija","Sve"},
                        {"TrenutniKlub","Real MadZid"}
                    

                    };
                collection.InsertOne(document);
                }
                
                //collection.UpdateOne(filter,document);
                testData = true;
                this.UpdateListView();
                MessageBox.Show("Done" + "Count:" + collection.Count(filter).ToString());
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(testData)
            {
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");

                var collection = _database.GetCollection<BsonDocument>("igraci");
                var filter = new BsonDocument()
                {
                    {"Pozicija","Sve"}
                };
                collection.DeleteMany(filter);
                testData = false;
                this.LVSviIgrac.Items.Clear();
                this.UpdateListView();
                MessageBox.Show("Obrisano.");
            }
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}