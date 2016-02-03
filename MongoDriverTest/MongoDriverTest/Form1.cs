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
using System.IO;
using MongoDB.DomainModel;

namespace MongoDriverTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            var document = new BsonDocument
            {
                { "address" , new BsonDocument
                    {
                        { "street", "2 Avenue" },
                        { "zipcode", "10075" },
                        { "building", "1480" },
                        { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                    }
                },
                { "borough", "Manhattan" },
                { "cuisine", "Italian" },
                { "grades", new BsonArray
                {
                new BsonDocument
                {
                    { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                    { "grade", "A" },
                    { "score", 11 }
                },
                new BsonDocument
                {
                    { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
                    { "grade", "B" },
                    { "score", 17 }
                }
            }
        },
        { "name", "Vella" },
        { "restaurant_id", "41704620" }
    };

            var collection = _database.GetCollection<BsonDocument>("restaurants");
            collection.InsertOne(document);
            MessageBox.Show("Done");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            
            var collection = _database.GetCollection<BsonDocument>("radnici");
            var filter = new BsonDocument();
            //var count = 0;
            var cursor = collection.Find(filter);
            var lista = cursor.ToList();
                if (cursor.Count() > 0)
                {
                    var batch = cursor.ToJson();
                    MessageBox.Show(batch);
                }
                else { MessageBox.Show("Nema nista"); }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("preduzece");

            var collection = _database.GetCollection<BsonDocument>("radnici");
            var filter = new BsonDocument();
            var document = new BsonDocument
            {
                {"ime","Dule"},
                {"broj",1},
                {"lud",true}
            };
            collection.InsertOne(document);
            MessageBox.Show("Done");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("preduzece");
            
            var collection = _database.GetCollection<BsonDocument>("radnici");
            var filter = new BsonDocument();
            //var count = 0;
            var cursor = collection.Find(filter);
            var lista = cursor.ToList();
            
             var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            //JObject json = JObject.Parse(prvi.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings));

            var prvi = lista.First().ToJson(jsonWriterSettings);
            Radnik r = Newtonsoft.Json.JsonConvert.DeserializeObject<Radnik>(prvi);
            MessageBox.Show(r.ime);

            // --- TESTING ----
            /*var vracenIgrac = lista.Last().ToJson(jsonWriterSettings);
            Igrac igrac = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(vracenIgrac);*/
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Book book = new Book(){
            Name = "Tom Sawyer",
            Content = "Content of the book goes here",
            Data = File.ReadAllBytes(@"E:\Sky.png\VII semestar\Grafika\PAT39.BMP")
        };

             MongoClient client = new MongoClient("mongodb://localhost");
            // MongoServer server = client.GetServer();
             MongoDatabase database = (MongoDatabase)client.GetDatabase("test");
             MongoCollection collection = database.GetCollection("docs");
 
            Stream memoryStream = new MemoryStream(book.Data);
            MongoGridFSFileInfo gfsi = database.GridFS.Upload(memoryStream, book.Name);
            BsonDocument photoMetadata = new BsonDocument
                                         { { "FileName", "PAT39.BMT" },
                                         { "Type", "image/bmp"},
                                         { "Width", 128 },
                                         { "Height", 128 }};
            database.GridFS.SetMetadata(gfsi, photoMetadata);
            book.ImageId = gfsi.Id.AsObjectId;
            collection.Insert(book);
            MessageBox.Show("Added book with picture.");
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");

            var collection = _database.GetCollection<BsonDocument>("docs");
            var filter = new BsonDocument();
            //var count = 0;
            var cursor = collection.Find(filter);
            var lista = cursor.ToList();

            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            //JObject json = JObject.Parse(prvi.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings));

            var prvi = lista.First().ToJson(jsonWriterSettings);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*FDodavanjeIgraca fdi = new FDodavanjeIgraca();
            fdi.ShowDialog();

            FBrisanjeIzmenaPodataka fbp = new FBrisanjeIzmenaPodataka();
            fbp.ShowDialog();*/

            FDodavanjeStadiona fds = new FDodavanjeStadiona();
            fds.ShowDialog();

        }
    }
}
