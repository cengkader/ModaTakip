namespace ModaTakip
{
    partial class FrmAnasayfa
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnRaporlama = new System.Windows.Forms.Button();
            this.btnTasarimciYonetimi = new System.Windows.Forms.Button();
            this.btnKumasEnvanter = new System.Windows.Forms.Button();
            this.pnlIcerik = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.MistyRose;
            this.pnlMenu.Controls.Add(this.btnCikis);
            this.pnlMenu.Controls.Add(this.btnRaporlama);
            this.pnlMenu.Controls.Add(this.btnTasarimciYonetimi);
            this.pnlMenu.Controls.Add(this.btnKumasEnvanter);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(213, 450);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.Maroon;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(12, 374);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(176, 47);
            this.btnCikis.TabIndex = 4;
            this.btnCikis.Text = "Oturumu Kapat";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnRaporlama
            // 
            this.btnRaporlama.BackColor = System.Drawing.Color.White;
            this.btnRaporlama.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporlama.ForeColor = System.Drawing.Color.Maroon;
            this.btnRaporlama.Location = new System.Drawing.Point(12, 180);
            this.btnRaporlama.Name = "btnRaporlama";
            this.btnRaporlama.Size = new System.Drawing.Size(176, 47);
            this.btnRaporlama.TabIndex = 2;
            this.btnRaporlama.Text = "Raporlama";
            this.btnRaporlama.UseVisualStyleBackColor = false;
            this.btnRaporlama.Click += new System.EventHandler(this.btnRaporlama_Click);
            // 
            // btnTasarimciYonetimi
            // 
            this.btnTasarimciYonetimi.BackColor = System.Drawing.Color.White;
            this.btnTasarimciYonetimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTasarimciYonetimi.ForeColor = System.Drawing.Color.Maroon;
            this.btnTasarimciYonetimi.Location = new System.Drawing.Point(12, 103);
            this.btnTasarimciYonetimi.Name = "btnTasarimciYonetimi";
            this.btnTasarimciYonetimi.Size = new System.Drawing.Size(179, 47);
            this.btnTasarimciYonetimi.TabIndex = 1;
            this.btnTasarimciYonetimi.Text = "Tasarımcı Yönetimi";
            this.btnTasarimciYonetimi.UseVisualStyleBackColor = false;
            this.btnTasarimciYonetimi.Click += new System.EventHandler(this.btnTasarimciYonetimi_Click);
            // 
            // btnKumasEnvanter
            // 
            this.btnKumasEnvanter.BackColor = System.Drawing.Color.White;
            this.btnKumasEnvanter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKumasEnvanter.ForeColor = System.Drawing.Color.Maroon;
            this.btnKumasEnvanter.Location = new System.Drawing.Point(12, 27);
            this.btnKumasEnvanter.Name = "btnKumasEnvanter";
            this.btnKumasEnvanter.Size = new System.Drawing.Size(179, 47);
            this.btnKumasEnvanter.TabIndex = 0;
            this.btnKumasEnvanter.Text = "Kumaş Envanter (CRUD)";
            this.btnKumasEnvanter.UseVisualStyleBackColor = false;
            this.btnKumasEnvanter.Click += new System.EventHandler(this.btnKumasEnvanter_Click);
            this.btnKumasEnvanter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlIcerik_Paint);
            // 
            // pnlIcerik
            // 
            this.pnlIcerik.BackgroundImage = global::ModaTakip.Properties.Resources.WhatsApp_Image_2025_12_16_at_20_44_03;
            this.pnlIcerik.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlIcerik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIcerik.Location = new System.Drawing.Point(213, 0);
            this.pnlIcerik.Name = "pnlIcerik";
            this.pnlIcerik.Size = new System.Drawing.Size(587, 450);
            this.pnlIcerik.TabIndex = 1;
            this.pnlIcerik.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlIcerik_Paint);
            // 
            // FrmAnasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlIcerik);
            this.Controls.Add(this.pnlMenu);
            this.Name = "FrmAnasayfa";
            this.Text = "Moda Kumaş Takip - Ana Sayfa";
            this.Load += new System.EventHandler(this.FrmAnasayfa_Load);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnRaporlama;
        private System.Windows.Forms.Button btnTasarimciYonetimi;
        private System.Windows.Forms.Button btnKumasEnvanter;
        private System.Windows.Forms.Panel pnlIcerik;
    }
}