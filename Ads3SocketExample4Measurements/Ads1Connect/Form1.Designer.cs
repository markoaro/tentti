namespace Ads1Connect
{
    partial class AdsForm
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSetSR1 = new System.Windows.Forms.Button();
            this.buttonResetSR1 = new System.Windows.Forms.Button();
            this.textBoxStructData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(118, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSetSR1
            // 
            this.buttonSetSR1.Location = new System.Drawing.Point(14, 47);
            this.buttonSetSR1.Name = "buttonSetSR1";
            this.buttonSetSR1.Size = new System.Drawing.Size(117, 23);
            this.buttonSetSR1.TabIndex = 7;
            this.buttonSetSR1.Text = "Start";
            this.buttonSetSR1.UseVisualStyleBackColor = true;
            this.buttonSetSR1.Click += new System.EventHandler(this.buttonSetSR1_Click);
            // 
            // buttonResetSR1
            // 
            this.buttonResetSR1.Location = new System.Drawing.Point(137, 47);
            this.buttonResetSR1.Name = "buttonResetSR1";
            this.buttonResetSR1.Size = new System.Drawing.Size(117, 23);
            this.buttonResetSR1.TabIndex = 8;
            this.buttonResetSR1.Text = "Stop";
            this.buttonResetSR1.UseVisualStyleBackColor = true;
            this.buttonResetSR1.Click += new System.EventHandler(this.buttonResetSR1_Click);
            // 
            // textBoxStructData
            // 
            this.textBoxStructData.Location = new System.Drawing.Point(107, 113);
            this.textBoxStructData.Name = "textBoxStructData";
            this.textBoxStructData.Size = new System.Drawing.Size(654, 20);
            this.textBoxStructData.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Struct data";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(22, 160);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(739, 300);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            // 
            // AdsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 472);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStructData);
            this.Controls.Add(this.buttonResetSR1);
            this.Controls.Add(this.buttonSetSR1);
            this.Controls.Add(this.buttonConnect);
            this.Name = "AdsForm";
            this.Text = "Ads test 2";
            this.Load += new System.EventHandler(this.AdsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSetSR1;
        private System.Windows.Forms.Button buttonResetSR1;
        private System.Windows.Forms.TextBox textBoxStructData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

