using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProbeTool {
    partial class ProbeWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.populateDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(12, 49);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Nutrient Content";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(375, 260);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // populateDataButton
            // 
            this.populateDataButton.Location = new System.Drawing.Point(12, 315);
            this.populateDataButton.Name = "populateDataButton";
            this.populateDataButton.Size = new System.Drawing.Size(75, 23);
            this.populateDataButton.TabIndex = 1;
            this.populateDataButton.Text = "populateDataButton";
            this.populateDataButton.UseVisualStyleBackColor = true;
            this.populateDataButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProbeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 450);
            this.Controls.Add(this.populateDataButton);
            this.Controls.Add(this.chart);
            this.Name = "ProbeWindow";
            this.Text = "ProbeWindow";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Chart chart;
        
        public void populateChart() {
            chart = new Chart();
        }

        private System.Windows.Forms.Button populateDataButton;
    }
}

