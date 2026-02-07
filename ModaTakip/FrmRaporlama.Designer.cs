namespace ModaTakip
{
    partial class FrmRaporlama
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelTasarimci = new System.Windows.Forms.Panel();
            this.chartAlt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlSagKutu = new System.Windows.Forms.Panel();
            this.chartSag = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlOrtFiyat = new System.Windows.Forms.Panel();
            this.lblOrtalamaFiyat = new System.Windows.Forms.Label();
            this.ortFiyat = new System.Windows.Forms.Label();
            this.pnlToplamKumas = new System.Windows.Forms.Panel();
            this.lblToplamKumas = new System.Windows.Forms.Label();
            this.toplamKumas = new System.Windows.Forms.Label();
            this.chartSol = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlSolKutu = new System.Windows.Forms.Panel();
            this.panelTasarimci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAlt)).BeginInit();
            this.pnlSagKutu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSag)).BeginInit();
            this.pnlOrtFiyat.SuspendLayout();
            this.pnlToplamKumas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSol)).BeginInit();
            this.pnlSolKutu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTasarimci
            // 
            this.panelTasarimci.BackColor = System.Drawing.Color.Maroon;
            this.panelTasarimci.Controls.Add(this.chartAlt);
            this.panelTasarimci.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTasarimci.Location = new System.Drawing.Point(0, 387);
            this.panelTasarimci.Name = "panelTasarimci";
            this.panelTasarimci.Size = new System.Drawing.Size(970, 203);
            this.panelTasarimci.TabIndex = 0;
            // 
            // chartAlt
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAlt.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartAlt.Legends.Add(legend1);
            this.chartAlt.Location = new System.Drawing.Point(22, 24);
            this.chartAlt.Name = "chartAlt";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartAlt.Series.Add(series1);
            this.chartAlt.Size = new System.Drawing.Size(926, 158);
            this.chartAlt.TabIndex = 0;
            this.chartAlt.Text = "chart3";
            // 
            // pnlSagKutu
            // 
            this.pnlSagKutu.Controls.Add(this.chartSag);
            this.pnlSagKutu.Controls.Add(this.pnlOrtFiyat);
            this.pnlSagKutu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSagKutu.Location = new System.Drawing.Point(488, 0);
            this.pnlSagKutu.Name = "pnlSagKutu";
            this.pnlSagKutu.Size = new System.Drawing.Size(488, 387);
            this.pnlSagKutu.TabIndex = 2;
            // 
            // chartSag
            // 
            this.chartSag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            chartArea2.Name = "ChartArea1";
            this.chartSag.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSag.Legends.Add(legend2);
            this.chartSag.Location = new System.Drawing.Point(18, 96);
            this.chartSag.Name = "chartSag";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSag.Series.Add(series2);
            this.chartSag.Size = new System.Drawing.Size(452, 278);
            this.chartSag.TabIndex = 1;
            this.chartSag.Text = "chart1";
            // 
            // pnlOrtFiyat
            // 
            this.pnlOrtFiyat.BackColor = System.Drawing.Color.Maroon;
            this.pnlOrtFiyat.Controls.Add(this.lblOrtalamaFiyat);
            this.pnlOrtFiyat.Controls.Add(this.ortFiyat);
            this.pnlOrtFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pnlOrtFiyat.ForeColor = System.Drawing.Color.White;
            this.pnlOrtFiyat.Location = new System.Drawing.Point(53, 12);
            this.pnlOrtFiyat.Name = "pnlOrtFiyat";
            this.pnlOrtFiyat.Size = new System.Drawing.Size(366, 66);
            this.pnlOrtFiyat.TabIndex = 1;
            // 
            // lblOrtalamaFiyat
            // 
            this.lblOrtalamaFiyat.AutoSize = true;
            this.lblOrtalamaFiyat.Location = new System.Drawing.Point(224, 24);
            this.lblOrtalamaFiyat.Name = "lblOrtalamaFiyat";
            this.lblOrtalamaFiyat.Size = new System.Drawing.Size(60, 20);
            this.lblOrtalamaFiyat.TabIndex = 1;
            this.lblOrtalamaFiyat.Text = "0,00 ₺";
            // 
            // ortFiyat
            // 
            this.ortFiyat.AutoSize = true;
            this.ortFiyat.Location = new System.Drawing.Point(47, 24);
            this.ortFiyat.Name = "ortFiyat";
            this.ortFiyat.Size = new System.Drawing.Size(171, 20);
            this.ortFiyat.TabIndex = 0;
            this.ortFiyat.Text = "ORTALAMA FİYAT:";
            // 
            // pnlToplamKumas
            // 
            this.pnlToplamKumas.BackColor = System.Drawing.Color.Maroon;
            this.pnlToplamKumas.Controls.Add(this.lblToplamKumas);
            this.pnlToplamKumas.Controls.Add(this.toplamKumas);
            this.pnlToplamKumas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pnlToplamKumas.ForeColor = System.Drawing.Color.White;
            this.pnlToplamKumas.Location = new System.Drawing.Point(32, 12);
            this.pnlToplamKumas.Name = "pnlToplamKumas";
            this.pnlToplamKumas.Size = new System.Drawing.Size(331, 66);
            this.pnlToplamKumas.TabIndex = 0;
            // 
            // lblToplamKumas
            // 
            this.lblToplamKumas.AutoSize = true;
            this.lblToplamKumas.Location = new System.Drawing.Point(244, 19);
            this.lblToplamKumas.Name = "lblToplamKumas";
            this.lblToplamKumas.Size = new System.Drawing.Size(19, 20);
            this.lblToplamKumas.TabIndex = 1;
            this.lblToplamKumas.Text = "0";
            // 
            // toplamKumas
            // 
            this.toplamKumas.AutoSize = true;
            this.toplamKumas.Location = new System.Drawing.Point(45, 19);
            this.toplamKumas.Name = "toplamKumas";
            this.toplamKumas.Size = new System.Drawing.Size(160, 20);
            this.toplamKumas.TabIndex = 0;
            this.toplamKumas.Text = "TOPLAM KUMAŞ:";
            // 
            // chartSol
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSol.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSol.Legends.Add(legend3);
            this.chartSol.Location = new System.Drawing.Point(12, 96);
            this.chartSol.Name = "chartSol";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartSol.Series.Add(series3);
            this.chartSol.Size = new System.Drawing.Size(452, 278);
            this.chartSol.TabIndex = 2;
            this.chartSol.Text = "chart2";
            // 
            // pnlSolKutu
            // 
            this.pnlSolKutu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlSolKutu.Controls.Add(this.chartSol);
            this.pnlSolKutu.Controls.Add(this.pnlToplamKumas);
            this.pnlSolKutu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSolKutu.Location = new System.Drawing.Point(0, 0);
            this.pnlSolKutu.Name = "pnlSolKutu";
            this.pnlSolKutu.Size = new System.Drawing.Size(488, 387);
            this.pnlSolKutu.TabIndex = 1;
            // 
            // FrmRaporlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ModaTakip.Properties.Resources.WhatsApp_Image_2025_12_16_at_20_441;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 590);
            this.Controls.Add(this.pnlSagKutu);
            this.Controls.Add(this.pnlSolKutu);
            this.Controls.Add(this.panelTasarimci);
            this.Name = "FrmRaporlama";
            this.Text = "FrmRaporlama";
            this.Load += new System.EventHandler(this.FrmRaporlama_Load);
            this.Click += new System.EventHandler(this.FrmRaporlama_Load);
            this.panelTasarimci.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAlt)).EndInit();
            this.pnlSagKutu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSag)).EndInit();
            this.pnlOrtFiyat.ResumeLayout(false);
            this.pnlOrtFiyat.PerformLayout();
            this.pnlToplamKumas.ResumeLayout(false);
            this.pnlToplamKumas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSol)).EndInit();
            this.pnlSolKutu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTasarimci;
        private System.Windows.Forms.Panel pnlSagKutu;
        private System.Windows.Forms.Panel pnlOrtFiyat;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAlt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSag;
        private System.Windows.Forms.Label ortFiyat;
        private System.Windows.Forms.Label lblOrtalamaFiyat;
        private System.Windows.Forms.Panel pnlToplamKumas;
        private System.Windows.Forms.Label lblToplamKumas;
        private System.Windows.Forms.Label toplamKumas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSol;
        private System.Windows.Forms.Panel pnlSolKutu;
    }
}