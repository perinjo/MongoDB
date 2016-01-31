namespace MongoDriverTest
{
    partial class FBrisanjeIzmenaPodataka
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TbPanel = new System.Windows.Forms.TabControl();
            this.TpIgrac = new System.Windows.Forms.TabPage();
            this.BtnIzbrisiIgraca = new System.Windows.Forms.Button();
            this.LvIgraci = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TpReprezentacije = new System.Windows.Forms.TabPage();
            this.BtnIzbrisiReprezentaciju = new System.Windows.Forms.Button();
            this.LvReprezentacije = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TpTakmicenja = new System.Windows.Forms.TabPage();
            this.BtnIzbrisiTakmicenje = new System.Windows.Forms.Button();
            this.LvTakmicanja = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnIzmeniIgraca = new System.Windows.Forms.Button();
            this.BtnIzmeniReprezentaciju = new System.Windows.Forms.Button();
            this.BtnIzmeniTakmicenje = new System.Windows.Forms.Button();
            this.TbPanel.SuspendLayout();
            this.TpIgrac.SuspendLayout();
            this.TpReprezentacije.SuspendLayout();
            this.TpTakmicenja.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbPanel
            // 
            this.TbPanel.Controls.Add(this.TpIgrac);
            this.TbPanel.Controls.Add(this.TpReprezentacije);
            this.TbPanel.Controls.Add(this.TpTakmicenja);
            this.TbPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPanel.Location = new System.Drawing.Point(12, 12);
            this.TbPanel.Name = "TbPanel";
            this.TbPanel.SelectedIndex = 0;
            this.TbPanel.Size = new System.Drawing.Size(911, 437);
            this.TbPanel.TabIndex = 0;
            // 
            // TpIgrac
            // 
            this.TpIgrac.Controls.Add(this.BtnIzmeniIgraca);
            this.TpIgrac.Controls.Add(this.BtnIzbrisiIgraca);
            this.TpIgrac.Controls.Add(this.LvIgraci);
            this.TpIgrac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TpIgrac.Location = new System.Drawing.Point(4, 25);
            this.TpIgrac.Name = "TpIgrac";
            this.TpIgrac.Padding = new System.Windows.Forms.Padding(3);
            this.TpIgrac.Size = new System.Drawing.Size(903, 408);
            this.TpIgrac.TabIndex = 0;
            this.TpIgrac.Text = "Igraci";
            this.TpIgrac.UseVisualStyleBackColor = true;
            // 
            // BtnIzbrisiIgraca
            // 
            this.BtnIzbrisiIgraca.Location = new System.Drawing.Point(694, 369);
            this.BtnIzbrisiIgraca.Name = "BtnIzbrisiIgraca";
            this.BtnIzbrisiIgraca.Size = new System.Drawing.Size(203, 33);
            this.BtnIzbrisiIgraca.TabIndex = 1;
            this.BtnIzbrisiIgraca.Text = "Izbrisi igraca";
            this.BtnIzbrisiIgraca.UseVisualStyleBackColor = true;
            this.BtnIzbrisiIgraca.Click += new System.EventHandler(this.BtnIzbrisiIgraca_Click);
            // 
            // LvIgraci
            // 
            this.LvIgraci.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.LvIgraci.FullRowSelect = true;
            this.LvIgraci.GridLines = true;
            this.LvIgraci.Location = new System.Drawing.Point(6, 6);
            this.LvIgraci.MultiSelect = false;
            this.LvIgraci.Name = "LvIgraci";
            this.LvIgraci.Size = new System.Drawing.Size(891, 357);
            this.LvIgraci.TabIndex = 0;
            this.LvIgraci.UseCompatibleStateImageBehavior = false;
            this.LvIgraci.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Puno ime";
            this.columnHeader2.Width = 197;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mesto rodjenja";
            this.columnHeader3.Width = 173;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Datum rodjenja";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Trenutni klub";
            this.columnHeader5.Width = 176;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Visina";
            this.columnHeader6.Width = 66;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Pozicija";
            this.columnHeader7.Width = 105;
            // 
            // TpReprezentacije
            // 
            this.TpReprezentacije.Controls.Add(this.BtnIzmeniReprezentaciju);
            this.TpReprezentacije.Controls.Add(this.BtnIzbrisiReprezentaciju);
            this.TpReprezentacije.Controls.Add(this.LvReprezentacije);
            this.TpReprezentacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TpReprezentacije.Location = new System.Drawing.Point(4, 25);
            this.TpReprezentacije.Name = "TpReprezentacije";
            this.TpReprezentacije.Padding = new System.Windows.Forms.Padding(3);
            this.TpReprezentacije.Size = new System.Drawing.Size(903, 408);
            this.TpReprezentacije.TabIndex = 1;
            this.TpReprezentacije.Text = "Reprezentacije";
            this.TpReprezentacije.UseVisualStyleBackColor = true;
            // 
            // BtnIzbrisiReprezentaciju
            // 
            this.BtnIzbrisiReprezentaciju.Location = new System.Drawing.Point(716, 369);
            this.BtnIzbrisiReprezentaciju.Name = "BtnIzbrisiReprezentaciju";
            this.BtnIzbrisiReprezentaciju.Size = new System.Drawing.Size(181, 33);
            this.BtnIzbrisiReprezentaciju.TabIndex = 1;
            this.BtnIzbrisiReprezentaciju.Text = "Izbrisi reprezentaciju";
            this.BtnIzbrisiReprezentaciju.UseVisualStyleBackColor = true;
            this.BtnIzbrisiReprezentaciju.Click += new System.EventHandler(this.BtnIzbrisiReprezentaciju_Click);
            // 
            // LvReprezentacije
            // 
            this.LvReprezentacije.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.LvReprezentacije.FullRowSelect = true;
            this.LvReprezentacije.GridLines = true;
            this.LvReprezentacije.Location = new System.Drawing.Point(6, 6);
            this.LvReprezentacije.MultiSelect = false;
            this.LvReprezentacije.Name = "LvReprezentacije";
            this.LvReprezentacije.Size = new System.Drawing.Size(891, 357);
            this.LvReprezentacije.TabIndex = 0;
            this.LvReprezentacije.UseCompatibleStateImageBehavior = false;
            this.LvReprezentacije.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ime";
            this.columnHeader8.Width = 210;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Skracenica";
            this.columnHeader9.Width = 87;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Selektor";
            this.columnHeader10.Width = 167;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Kapiten";
            this.columnHeader11.Width = 146;
            // 
            // TpTakmicenja
            // 
            this.TpTakmicenja.Controls.Add(this.BtnIzmeniTakmicenje);
            this.TpTakmicenja.Controls.Add(this.BtnIzbrisiTakmicenje);
            this.TpTakmicenja.Controls.Add(this.LvTakmicanja);
            this.TpTakmicenja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TpTakmicenja.Location = new System.Drawing.Point(4, 25);
            this.TpTakmicenja.Name = "TpTakmicenja";
            this.TpTakmicenja.Padding = new System.Windows.Forms.Padding(3);
            this.TpTakmicenja.Size = new System.Drawing.Size(903, 408);
            this.TpTakmicenja.TabIndex = 2;
            this.TpTakmicenja.Text = "Takmicenja";
            this.TpTakmicenja.UseVisualStyleBackColor = true;
            // 
            // BtnIzbrisiTakmicenje
            // 
            this.BtnIzbrisiTakmicenje.Location = new System.Drawing.Point(706, 369);
            this.BtnIzbrisiTakmicenje.Name = "BtnIzbrisiTakmicenje";
            this.BtnIzbrisiTakmicenje.Size = new System.Drawing.Size(191, 33);
            this.BtnIzbrisiTakmicenje.TabIndex = 1;
            this.BtnIzbrisiTakmicenje.Text = "Izbrisi takmicenje";
            this.BtnIzbrisiTakmicenje.UseVisualStyleBackColor = true;
            this.BtnIzbrisiTakmicenje.Click += new System.EventHandler(this.BtnIzbrisiTakmicenje_Click);
            // 
            // LvTakmicanja
            // 
            this.LvTakmicanja.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.LvTakmicanja.FullRowSelect = true;
            this.LvTakmicanja.GridLines = true;
            this.LvTakmicanja.Location = new System.Drawing.Point(3, 6);
            this.LvTakmicanja.MultiSelect = false;
            this.LvTakmicanja.Name = "LvTakmicanja";
            this.LvTakmicanja.Size = new System.Drawing.Size(894, 357);
            this.LvTakmicanja.TabIndex = 0;
            this.LvTakmicanja.UseCompatibleStateImageBehavior = false;
            this.LvTakmicanja.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Ime";
            this.columnHeader12.Width = 183;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Width = 160;
            // 
            // BtnIzmeniIgraca
            // 
            this.BtnIzmeniIgraca.Location = new System.Drawing.Point(6, 369);
            this.BtnIzmeniIgraca.Name = "BtnIzmeniIgraca";
            this.BtnIzmeniIgraca.Size = new System.Drawing.Size(202, 33);
            this.BtnIzmeniIgraca.TabIndex = 2;
            this.BtnIzmeniIgraca.Text = "Izmeni igraca";
            this.BtnIzmeniIgraca.UseVisualStyleBackColor = true;
            this.BtnIzmeniIgraca.Click += new System.EventHandler(this.BtnIzmeniIgraca_Click);
            // 
            // BtnIzmeniReprezentaciju
            // 
            this.BtnIzmeniReprezentaciju.Location = new System.Drawing.Point(6, 370);
            this.BtnIzmeniReprezentaciju.Name = "BtnIzmeniReprezentaciju";
            this.BtnIzmeniReprezentaciju.Size = new System.Drawing.Size(188, 32);
            this.BtnIzmeniReprezentaciju.TabIndex = 2;
            this.BtnIzmeniReprezentaciju.Text = "Izmeni reprezentaciju";
            this.BtnIzmeniReprezentaciju.UseVisualStyleBackColor = true;
            this.BtnIzmeniReprezentaciju.Click += new System.EventHandler(this.BtnIzmeniReprezentaciju_Click);
            // 
            // BtnIzmeniTakmicenje
            // 
            this.BtnIzmeniTakmicenje.Location = new System.Drawing.Point(3, 369);
            this.BtnIzmeniTakmicenje.Name = "BtnIzmeniTakmicenje";
            this.BtnIzmeniTakmicenje.Size = new System.Drawing.Size(225, 33);
            this.BtnIzmeniTakmicenje.TabIndex = 2;
            this.BtnIzmeniTakmicenje.Text = "Izmeni takmicenje";
            this.BtnIzmeniTakmicenje.UseVisualStyleBackColor = true;
            this.BtnIzmeniTakmicenje.Click += new System.EventHandler(this.BtnIzmeniTakmicenje_Click);
            // 
            // FBrisanjeIzmenaPodataka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 461);
            this.Controls.Add(this.TbPanel);
            this.Name = "FBrisanjeIzmenaPodataka";
            this.Text = "FBrisanjePodataka";
            this.TbPanel.ResumeLayout(false);
            this.TpIgrac.ResumeLayout(false);
            this.TpReprezentacije.ResumeLayout(false);
            this.TpTakmicenja.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbPanel;
        private System.Windows.Forms.TabPage TpIgrac;
        private System.Windows.Forms.TabPage TpReprezentacije;
        private System.Windows.Forms.TabPage TpTakmicenja;
        private System.Windows.Forms.Button BtnIzbrisiIgraca;
        private System.Windows.Forms.ListView LvIgraci;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button BtnIzbrisiReprezentaciju;
        private System.Windows.Forms.ListView LvReprezentacije;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button BtnIzbrisiTakmicenje;
        private System.Windows.Forms.ListView LvTakmicanja;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Button BtnIzmeniIgraca;
        private System.Windows.Forms.Button BtnIzmeniReprezentaciju;
        private System.Windows.Forms.Button BtnIzmeniTakmicenje;
    }
}