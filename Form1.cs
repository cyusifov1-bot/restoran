using System;
using System.Drawing;
using System.Windows.Forms;

namespace restoran
{
    public partial class Form1 : Form
    {
        Color fon = Color.FromArgb(15, 23, 42);
        Color panelReng = Color.FromArgb(30, 41, 59);
        Color yasil = Color.FromArgb(22, 163, 74);
        Color qirmizi = Color.FromArgb(220, 38, 38);

        FlowLayoutPanel kabinetPanel;

        TextBox txtAd;
        TextBox txtSoyad;
        TextBox txtTelefon;

        ComboBox cmbKabinet;

        DateTimePicker dtpTarix;
        DateTimePicker dtpSaat;

        DataGridView dgv;

        Label lblSecim;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DizaynQur();
        }

        private void DizaynQur()
        {
            this.Text = "restoran";
            this.Size = new Size(1250, 800);
            this.MinimumSize = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = fon;
            this.Font = new Font("Segoe UI", 10);

            // SOL MENU
            Panel solMenu = new Panel();
            solMenu.Dock = DockStyle.Left;
            solMenu.Width = 220;
            solMenu.BackColor = panelReng;
            this.Controls.Add(solMenu);

            Label logo = new Label();
            logo.Text = "restoran";
            logo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            logo.ForeColor = Color.White;
            logo.Location = new Point(25, 30);
            logo.AutoSize = true;
            solMenu.Controls.Add(logo);

            Label altLogo = new Label();
            altLogo.Text = "kabinet rezervasiya";
            altLogo.Font = new Font("Segoe UI", 9);
            altLogo.ForeColor = Color.Silver;
            altLogo.Location = new Point(27, 70);
            altLogo.AutoSize = true;
            solMenu.Controls.Add(altLogo);

            MenyuDugme(solMenu, "Ana səhifə", 130);
            MenyuDugme(solMenu, "Kabinetlər", 190);
            MenyuDugme(solMenu, "Rezervasiyalar", 250);
            MenyuDugme(solMenu, "Parametrlər", 310);

            Button btnCixis = new Button();
            btnCixis.Text = "Çıxış";
            btnCixis.Location = new Point(15, 650);
            btnCixis.Size = new Size(190, 45);
            btnCixis.BackColor = qirmizi;
            btnCixis.ForeColor = Color.White;
            btnCixis.FlatStyle = FlatStyle.Flat;
            btnCixis.FlatAppearance.BorderSize = 0;
            btnCixis.Click += (s, e) => Application.Exit();
            solMenu.Controls.Add(btnCixis);

            // ƏSAS PANEL
            Panel esasPanel = new Panel();
            esasPanel.Dock = DockStyle.Fill;
            esasPanel.AutoScroll = true;
            esasPanel.BackColor = fon;
            this.Controls.Add(esasPanel);

            Label basliq = new Label();
            basliq.Text = "kabinet rezervasiyası";
            basliq.Font = new Font("Segoe UI", 23, FontStyle.Bold);
            basliq.ForeColor = Color.White;
            basliq.Location = new Point(30, 25);
            basliq.AutoSize = true;
            esasPanel.Controls.Add(basliq);

            Label altBasliq = new Label();
            altBasliq.Text = "restoran kabinetlərini idarə et";
            altBasliq.Font = new Font("Segoe UI", 10);
            altBasliq.ForeColor = Color.Silver;
            altBasliq.Location = new Point(33, 68);
            altBasliq.AutoSize = true;
            esasPanel.Controls.Add(altBasliq);

            // KARTLAR
            KartYarat(esasPanel, "bütün kabinetlər", "6", 30, 105);
            KartYarat(esasPanel, "boş kabinetlər", "6", 250, 105);
            KartYarat(esasPanel, "rezerv edilmiş", "0", 470, 105);

            // KABİNETLƏR
            Label kabinetBasliq = new Label();
            kabinetBasliq.Text = "kabinetlər";
            kabinetBasliq.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            kabinetBasliq.ForeColor = Color.White;
            kabinetBasliq.Location = new Point(30, 225);
            kabinetBasliq.AutoSize = true;
            esasPanel.Controls.Add(kabinetBasliq);

            kabinetPanel = new FlowLayoutPanel();
            kabinetPanel.Location = new Point(30, 265);
            kabinetPanel.Size = new Size(670, 190);
            kabinetPanel.BackColor = fon;
            kabinetPanel.WrapContents = true;
            kabinetPanel.AutoScroll = true;
            esasPanel.Controls.Add(kabinetPanel);

            for (int i = 1; i <= 6; i++)
            {
                KabinetYarat(i);
            }

            // REZERV PANELİ
            Panel rezervPanel = new Panel();
            rezervPanel.Location = new Point(720, 105);
            rezervPanel.Size = new Size(390, 350);
            rezervPanel.BackColor = panelReng;
            esasPanel.Controls.Add(rezervPanel);

            Label rezervBasliq = new Label();
            rezervBasliq.Text = "yeni rezervasiya";
            rezervBasliq.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            rezervBasliq.ForeColor = Color.White;
            rezervBasliq.Location = new Point(20, 15);
            rezervBasliq.AutoSize = true;
            rezervPanel.Controls.Add(rezervBasliq);

            txtAd = MetnQutusu(rezervPanel, "ad", 65);
            txtSoyad = MetnQutusu(rezervPanel, "soyad", 110);
            txtTelefon = MetnQutusu(rezervPanel, "telefon", 155);

            Etiket(rezervPanel, "kabinet", 20, 203);

            cmbKabinet = new ComboBox();
            cmbKabinet.Location = new Point(175, 200);
            cmbKabinet.Size = new Size(190, 30);
            cmbKabinet.DropDownStyle = ComboBoxStyle.DropDownList;

            for (int i = 1; i <= 6; i++)
            {
                cmbKabinet.Items.Add("Kabinet " + i);
            }

            rezervPanel.Controls.Add(cmbKabinet);

            Etiket(rezervPanel, "tarix", 20, 243);

            dtpTarix = new DateTimePicker();
            dtpTarix.Location = new Point(175, 240);
            dtpTarix.Size = new Size(190, 30);
            dtpTarix.MinDate = DateTime.Today;
            rezervPanel.Controls.Add(dtpTarix);

            Etiket(rezervPanel, "saat", 20, 283);

            dtpSaat = new DateTimePicker();
            dtpSaat.Location = new Point(175, 280);
            dtpSaat.Size = new Size(190, 30);
            dtpSaat.Format = DateTimePickerFormat.Time;
            dtpSaat.ShowUpDown = true;
            rezervPanel.Controls.Add(dtpSaat);

            lblSecim = new Label();
            lblSecim.Text = "kabinet seçilməyib";
            lblSecim.ForeColor = Color.LightGreen;
            lblSecim.Location = new Point(20, 320);
            lblSecim.AutoSize = true;
            rezervPanel.Controls.Add(lblSecim);

            // SİYAHI BAŞLIĞI
            Label siyahiBasliq = new Label();
            siyahiBasliq.Text = "rezervasiya siyahısı";
            siyahiBasliq.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            siyahiBasliq.ForeColor = Color.White;
            siyahiBasliq.Location = new Point(30, 480);
            siyahiBasliq.AutoSize = true;
            esasPanel.Controls.Add(siyahiBasliq);

            // REZERV ET
            Button btnRezerv = new Button();
            btnRezerv.Text = "REZERV ET";
            btnRezerv.Location = new Point(720, 475);
            btnRezerv.Size = new Size(185, 42);
            btnRezerv.BackColor = yasil;
            btnRezerv.ForeColor = Color.White;
            btnRezerv.FlatStyle = FlatStyle.Flat;
            btnRezerv.FlatAppearance.BorderSize = 0;
            btnRezerv.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRezerv.Click += RezervEt;
            esasPanel.Controls.Add(btnRezerv);

            // SİL
            Button btnSil = new Button();
            btnSil.Text = "SEÇİLƏNİ SİL";
            btnSil.Location = new Point(915, 475);
            btnSil.Size = new Size(195, 42);
            btnSil.BackColor = qirmizi;
            btnSil.ForeColor = Color.White;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSil.Click += RezervSil;
            esasPanel.Controls.Add(btnSil);

            // DATAGRIDVIEW
            dgv = new DataGridView();
            dgv.Location = new Point(30, 525);
            dgv.Size = new Size(1080, 180);
            dgv.BackgroundColor = panelReng;
            dgv.ForeColor = Color.Black;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;

            dgv.Columns.Add("Ad", "ad");
            dgv.Columns.Add("Soyad", "soyad");
            dgv.Columns.Add("Telefon", "telefon");
            dgv.Columns.Add("Kabinet", "kabinet");
            dgv.Columns.Add("Tarix", "tarix");
            dgv.Columns.Add("Saat", "saat");

            esasPanel.Controls.Add(dgv);
        }

        private void MenyuDugme(Panel panel, string text, int y)
        {
            Button btn = new Button();

            btn.Text = text;
            btn.Location = new Point(10, y);
            btn.Size = new Size(200, 50);
            btn.ForeColor = Color.White;
            btn.BackColor = panelReng;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10);

            panel.Controls.Add(btn);
        }

        private void KartYarat(
            Panel panel,
            string basliq,
            string say,
            int x,
            int y)
        {
            Panel kart = new Panel();

            kart.Location = new Point(x, y);
            kart.Size = new Size(200, 95);
            kart.BackColor = panelReng;

            panel.Controls.Add(kart);

            Label lblBasliq = new Label();
            lblBasliq.Text = basliq;
            lblBasliq.ForeColor = Color.Silver;
            lblBasliq.Location = new Point(12, 12);
            lblBasliq.AutoSize = true;

            kart.Controls.Add(lblBasliq);

            Label lblSay = new Label();
            lblSay.Text = say;
            lblSay.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblSay.ForeColor = Color.White;
            lblSay.Location = new Point(12, 38);
            lblSay.AutoSize = true;

            kart.Controls.Add(lblSay);
        }

        private void KabinetYarat(int nomre)
        {
            Button btn = new Button();

            btn.Text = "Kabinet " + nomre + "\nBOŞ";
            btn.Size = new Size(205, 75);
            btn.Margin = new Padding(5);
            btn.BackColor = yasil;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Tag = "Kabinet " + nomre;

            btn.Click += (s, e) =>
            {
                cmbKabinet.SelectedItem = btn.Tag.ToString();
                lblSecim.Text = "Seçilmiş: " + btn.Tag.ToString();
            };

            kabinetPanel.Controls.Add(btn);
        }

        private TextBox MetnQutusu(
            Panel panel,
            string ad,
            int y)
        {
            Etiket(panel, ad, 20, y + 3);

            TextBox txt = new TextBox();

            txt.Location = new Point(175, y);
            txt.Size = new Size(190, 30);

            panel.Controls.Add(txt);

            return txt;
        }

        private void Etiket(
            Panel panel,
            string text,
            int x,
            int y)
        {
            Label lbl = new Label();

            lbl.Text = text;
            lbl.ForeColor = Color.White;
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;

            panel.Controls.Add(lbl);
        }

        private void RezervEt(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                cmbKabinet.SelectedIndex == -1
            )
            {
                MessageBox.Show(
                    "Bütün məlumatları daxil et!",
                    "Xəbərdarlıq",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (
                    row.Cells["Kabinet"].Value.ToString() == cmbKabinet.Text &&
                    row.Cells["Tarix"].Value.ToString() == dtpTarix.Value.ToShortDateString() &&
                    row.Cells["Saat"].Value.ToString() == dtpSaat.Value.ToShortTimeString()
                )
                {
                    MessageBox.Show(
                        "Bu kabinet həmin tarix və saatda artıq rezerv edilib!",
                        "Kabinet doludur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }
            }

            dgv.Rows.Add(
                txtAd.Text,
                txtSoyad.Text,
                txtTelefon.Text,
                cmbKabinet.Text,
                dtpTarix.Value.ToShortDateString(),
                dtpSaat.Value.ToShortTimeString()
            );

            MessageBox.Show(
                "Rezervasiya uğurla edildi!",
                "restoran",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();

            cmbKabinet.SelectedIndex = -1;

            lblSecim.Text = "kabinet seçilməyib";
        }

        private void RezervSil(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Silmək üçün rezervasiya seç!"
                );

                return;
            }

            DialogResult cavab = MessageBox.Show(
                "Bu rezervasiyanı silmək istəyirsən?",
                "restoran",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (cavab == DialogResult.Yes)
            {
                dgv.Rows.RemoveAt(
                    dgv.SelectedRows[0].Index
                );
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}