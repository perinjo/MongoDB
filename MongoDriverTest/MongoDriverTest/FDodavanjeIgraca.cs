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
using System.Text.RegularExpressions;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Bson.IO;
using MongoDB.Driver.GridFS;
using System.IO;
using System.Drawing;

namespace MongoDriverTest
{
    public partial class FDodavanjeIgraca : Form
    {
        public FDodavanjeIgraca()
        {
            InitializeComponent();
        }

        // --- Brisanje pozicije iz listView-a
        private void BtnIzbrisiPoziciju_Click(object sender, EventArgs e)
        {
            if (LvPozicijeIgraca.SelectedItems.Count != 0)
            {
                LvPozicijeIgraca.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Selektuj poziciju koju hoces da izbrises!");
            }
        }

        private void BtnDodajPoziciju_Click(object sender, EventArgs e)
        {
            // --- Provera da li je nesto selektovano u ComboBoxu ---
            if (Convert.ToInt32(CbPosition.SelectedIndex) != -1)
            {
                bool postoji = false;
                string pozicija = CbPosition.SelectedItem.ToString();
                // --- Proveravamo da li ta pozicija vec postoji u listi ---
                foreach (ListViewItem Item in LvPozicijeIgraca.Items)
                {
                    if (Item.Text == pozicija)
                    {
                        postoji = true;
                    }
                }
                // --- Ako ne postoji, ubacujemo poziciju ---
                if (!postoji)
                {
                    ListViewItem lv1 = new ListViewItem(pozicija);
                    LvPozicijeIgraca.Items.Add(lv1);

                    CbPosition.SelectedItem = null;
                    CbPosition.Text = "Izaberi poziciju";
                }
                else
                {
                    MessageBox.Show("Pozicija '" + pozicija + "' je vec dodata.");
                }
            }
            else
            {
                MessageBox.Show("Izaberite poziciju!");
            }
        }

        private void TbVisina_KeyPress(object sender, KeyPressEventArgs e)
        {
            // --- Omogucavanje backspace-a tj. brisanje jednog karaktera ---
            if (e.KeyChar == '\b')
            {
                if (TbVisina.Text.Length > 0)
                    TbVisina.Text = TbVisina.Text.Remove(TbVisina.Text.Length - 1);             
            }

            // --- Ako je duzina texta 1 onda dozvoli samo tacku ---
            if (TbVisina.Text.Length == 1)
            {
                if (e.KeyChar != '.')
                {
                    e.Handled = true;                   
                }
            }
            else // --- dozvoli unos bilo kog broja ---
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }

        private void BtnDodajIgraca_Click(object sender, EventArgs e)
        {
            // ---- Provera ispravnosti licnih podataka ----
            if (String.IsNullOrWhiteSpace(TbPunoIme.Text))
            {
                MessageBox.Show("Unesite puno ime igraca!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbMestoRodjenja.Text))
            {
                MessageBox.Show("Unesite mesto rodjenja igraca!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbTrenutniKlub.Text))
            {
                MessageBox.Show("Unesite trenutni (ili poslednji) klub igraca!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbVisina.Text) || TbVisina.Text.Length != 4)
            {   
                MessageBox.Show("Unesite ispravno vrednost visine igraca! Na primer '1.92' ");
                return; /*AKO JE OBAVEZNO POLJE*/
            }
            else if (LvPozicijeIgraca.Items.Count == 0)
            {
                MessageBox.Show("Ubacite poziciju/je na kojoj igrac igra!");
                return;
            }

            // ---- Izvlacimo pozicije igraca ----
            string pozicije = "";
            foreach (ListViewItem lvi in LvPozicijeIgraca.Items)
            {
                pozicije += lvi.Text + ", ";
            }
            pozicije = pozicije.TrimEnd(',');

            // ---- Ubacujemo podatke u objekat ----
            Igrac noviIgrac = new Igrac();
            // ---- Licni podaci ----
            noviIgrac.PunoIme = checkString(TbPunoIme.Text);
            noviIgrac.MestoRodjenja = checkString(TbMestoRodjenja.Text);
            noviIgrac.DatumRodjenja = DpDatumRodjenja.Text; /*Treba se ispravi*/
            noviIgrac.Visina = TbVisina.Text;
            noviIgrac.TrenutniKlub = checkString(TbTrenutniKlub.Text);
            noviIgrac.Pozicija = pozicije;
            // ---- Ostali podaci ----
            noviIgrac.SportskaBiografija = checkString(RtbSportksaBiografija.Text);
            noviIgrac.ReprezentativnaKarijera = checkString(RtbReprezentativnaKarijera.Text);
            noviIgrac.Statistika = checkString(RtbStatistika.Text);
            noviIgrac.Trofeji = checkString(RtbTrofeji.Text);

            // ------------------ID------------------------
            noviIgrac.Id = "1";
            //----------------------------------------------

            // ---- Rad sa bazom ----
            try
            {
                var _client = new MongoClient();
                var _database = _client.GetDatabase("preduzece");

                var collection = _database.GetCollection<BsonDocument>("radnici");
                var filter = new BsonDocument();
                var document = noviIgrac.ToBsonDocument();
                collection.InsertOne(document);
                MessageBox.Show("Uspesno dodat novi igrac!");

                // ---- Zatvaranje forme ----
                this.Dispose();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
            
        }

        public string checkString(string stringToCheck)
        {
            stringToCheck = Regex.Replace(stringToCheck, @"\t|\r", " ");
            stringToCheck = Regex.Replace(stringToCheck, @"( \n){2,}", "\n");
            stringToCheck = Regex.Replace(stringToCheck, " {2,}", " ");

            stringToCheck = stringToCheck.Trim();

            return stringToCheck;
        }

        private void BtnUcitajSliku_Click(object sender, EventArgs e)
        {
            Image slika;
            FileStream fs;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fs = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                slika = Image.FromStream(fs);
                PbSlikaIgraca.Image = Image.FromStream(fs);

                int duzina = Convert.ToInt32(fs.Length);
                byte[] bajtovi = new byte[duzina];
                fs.Seek(0, SeekOrigin.Begin);
                int bytesRead = fs.Read(bajtovi, 0, duzina);
            }   
        }

    }
}
