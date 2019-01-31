using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1;

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
            //initialize simulation Related variables
            //---------------------------------
            this.ledger = new Ledger();
            this.worldMap = new WorldMap();
            //---------------------------------

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.showMinerals = new System.Windows.Forms.Button();
            this.showBiota = new System.Windows.Forms.Button();
            this.showPorosity = new System.Windows.Forms.Button();
            this.showWater = new System.Windows.Forms.Button();
            this.showAeration = new System.Windows.Forms.Button();
            this.showErosionFactor = new System.Windows.Forms.Button();
            this.showNutrientVolatility = new System.Windows.Forms.Button();
            this.showHumus = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.showOrganicMatter = new System.Windows.Forms.Button();
            this.showAggregateStability = new System.Windows.Forms.Button();
            this.addOrganicMatter = new System.Windows.Forms.Button();
            this.addHumus = new System.Windows.Forms.Button();
            this.addNutrientVolatility = new System.Windows.Forms.Button();
            this.addErosionFactor = new System.Windows.Forms.Button();
            this.addAeration = new System.Windows.Forms.Button();
            this.addWater = new System.Windows.Forms.Button();
            this.addPorosity = new System.Windows.Forms.Button();
            this.addBiota = new System.Windows.Forms.Button();
            this.addMineral = new System.Windows.Forms.Button();
            this.addAggregateStability = new System.Windows.Forms.Button();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.trackBar9 = new System.Windows.Forms.TrackBar();
            this.trackBar10 = new System.Windows.Forms.TrackBar();
            this.trackBar11 = new System.Windows.Forms.TrackBar();
            this.trackBar12 = new System.Windows.Forms.TrackBar();
            this.trackBar13 = new System.Windows.Forms.TrackBar();
            this.EvolveTime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Nutrient Content";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(619, 297);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // showMinerals
            // 
            this.showMinerals.Location = new System.Drawing.Point(12, 315);
            this.showMinerals.Name = "showMinerals";
            this.showMinerals.Size = new System.Drawing.Size(133, 23);
            this.showMinerals.TabIndex = 1;
            this.showMinerals.Text = "showMinerals";
            this.showMinerals.UseVisualStyleBackColor = true;
            this.showMinerals.Click += new System.EventHandler(this.toggleMinerals);
            // 
            // showBiota
            // 
            this.showBiota.Location = new System.Drawing.Point(12, 344);
            this.showBiota.Name = "showBiota";
            this.showBiota.Size = new System.Drawing.Size(133, 23);
            this.showBiota.TabIndex = 2;
            this.showBiota.Text = "showBiota";
            this.showBiota.UseVisualStyleBackColor = true;
            this.showBiota.Click += new System.EventHandler(this.displayBiota);
            // 
            // showPorosity
            // 
            this.showPorosity.Location = new System.Drawing.Point(12, 374);
            this.showPorosity.Name = "showPorosity";
            this.showPorosity.Size = new System.Drawing.Size(133, 23);
            this.showPorosity.TabIndex = 3;
            this.showPorosity.Text = "showPorosity";
            this.showPorosity.UseVisualStyleBackColor = true;
            this.showPorosity.Click += new System.EventHandler(this.displayPorosity);
            // 
            // showWater
            // 
            this.showWater.Location = new System.Drawing.Point(12, 403);
            this.showWater.Name = "showWater";
            this.showWater.Size = new System.Drawing.Size(133, 23);
            this.showWater.TabIndex = 4;
            this.showWater.Text = "showWater";
            this.showWater.UseVisualStyleBackColor = true;
            this.showWater.Click += new System.EventHandler(this.displayWater);
            // 
            // showAeration
            // 
            this.showAeration.Location = new System.Drawing.Point(12, 432);
            this.showAeration.Name = "showAeration";
            this.showAeration.Size = new System.Drawing.Size(133, 23);
            this.showAeration.TabIndex = 5;
            this.showAeration.Text = "showAeration";
            this.showAeration.UseVisualStyleBackColor = true;
            this.showAeration.Click += new System.EventHandler(this.displayAeration);
            // 
            // showErosionFactor
            // 
            this.showErosionFactor.Location = new System.Drawing.Point(12, 461);
            this.showErosionFactor.Name = "showErosionFactor";
            this.showErosionFactor.Size = new System.Drawing.Size(133, 23);
            this.showErosionFactor.TabIndex = 6;
            this.showErosionFactor.Text = "showErosionFactor";
            this.showErosionFactor.UseVisualStyleBackColor = true;
            this.showErosionFactor.Click += new System.EventHandler(this.displayErosionFactor);
            // 
            // showNutrientVolatility
            // 
            this.showNutrientVolatility.Location = new System.Drawing.Point(12, 490);
            this.showNutrientVolatility.Name = "showNutrientVolatility";
            this.showNutrientVolatility.Size = new System.Drawing.Size(133, 23);
            this.showNutrientVolatility.TabIndex = 7;
            this.showNutrientVolatility.Text = "showNutrientVolatility";
            this.showNutrientVolatility.UseVisualStyleBackColor = true;
            this.showNutrientVolatility.Click += new System.EventHandler(this.displayNutrientVolatility);
            // 
            // showHumus
            // 
            this.showHumus.Location = new System.Drawing.Point(12, 519);
            this.showHumus.Name = "showHumus";
            this.showHumus.Size = new System.Drawing.Size(133, 23);
            this.showHumus.TabIndex = 8;
            this.showHumus.Text = "showHumus";
            this.showHumus.UseVisualStyleBackColor = true;
            this.showHumus.Click += new System.EventHandler(this.displayHumus);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(0, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 0;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(0, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 0;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(0, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 0;
            // 
            // showOrganicMatter
            // 
            this.showOrganicMatter.Location = new System.Drawing.Point(12, 548);
            this.showOrganicMatter.Name = "showOrganicMatter";
            this.showOrganicMatter.Size = new System.Drawing.Size(133, 23);
            this.showOrganicMatter.TabIndex = 9;
            this.showOrganicMatter.Text = "showOrganicMatter";
            this.showOrganicMatter.UseVisualStyleBackColor = true;
            this.showOrganicMatter.Click += new System.EventHandler(this.displayOrganicMatter);
            // 
            // showAggregateStability
            // 
            this.showAggregateStability.Location = new System.Drawing.Point(12, 577);
            this.showAggregateStability.Name = "showAggregateStability";
            this.showAggregateStability.Size = new System.Drawing.Size(133, 23);
            this.showAggregateStability.TabIndex = 10;
            this.showAggregateStability.Text = "showAggregateStability";
            this.showAggregateStability.UseVisualStyleBackColor = true;
            this.showAggregateStability.Click += new System.EventHandler(this.displayAggregateStability);
            // 
            // addOrganicMatter
            // 
            this.addOrganicMatter.Location = new System.Drawing.Point(151, 548);
            this.addOrganicMatter.Name = "addOrganicMatter";
            this.addOrganicMatter.Size = new System.Drawing.Size(133, 23);
            this.addOrganicMatter.TabIndex = 19;
            this.addOrganicMatter.Text = "addOrganicMatter";
            this.addOrganicMatter.UseVisualStyleBackColor = true;
            this.addOrganicMatter.Click += new System.EventHandler(this.addOrganicMatter_Click);
            // 
            // addHumus
            // 
            this.addHumus.Location = new System.Drawing.Point(151, 519);
            this.addHumus.Name = "addHumus";
            this.addHumus.Size = new System.Drawing.Size(133, 23);
            this.addHumus.TabIndex = 18;
            this.addHumus.Text = "addHumus";
            this.addHumus.UseVisualStyleBackColor = true;
            this.addHumus.Click += new System.EventHandler(this.addHumus_Click);
            // 
            // addNutrientVolatility
            // 
            this.addNutrientVolatility.Location = new System.Drawing.Point(151, 490);
            this.addNutrientVolatility.Name = "addNutrientVolatility";
            this.addNutrientVolatility.Size = new System.Drawing.Size(133, 23);
            this.addNutrientVolatility.TabIndex = 17;
            this.addNutrientVolatility.Text = "addNutrientVolatility";
            this.addNutrientVolatility.UseVisualStyleBackColor = true;
            this.addNutrientVolatility.Click += new System.EventHandler(this.addNutrientVolatility_Click);
            // 
            // addErosionFactor
            // 
            this.addErosionFactor.Location = new System.Drawing.Point(151, 461);
            this.addErosionFactor.Name = "addErosionFactor";
            this.addErosionFactor.Size = new System.Drawing.Size(133, 23);
            this.addErosionFactor.TabIndex = 16;
            this.addErosionFactor.Text = "addErosionFactor";
            this.addErosionFactor.UseVisualStyleBackColor = true;
            this.addErosionFactor.Click += new System.EventHandler(this.addErosionFactor_Click);
            // 
            // addAeration
            // 
            this.addAeration.Location = new System.Drawing.Point(151, 432);
            this.addAeration.Name = "addAeration";
            this.addAeration.Size = new System.Drawing.Size(133, 23);
            this.addAeration.TabIndex = 15;
            this.addAeration.Text = "addAeration";
            this.addAeration.UseVisualStyleBackColor = true;
            this.addAeration.Click += new System.EventHandler(this.addAeration_Click);
            // 
            // addWater
            // 
            this.addWater.Location = new System.Drawing.Point(151, 403);
            this.addWater.Name = "addWater";
            this.addWater.Size = new System.Drawing.Size(133, 23);
            this.addWater.TabIndex = 14;
            this.addWater.Text = "addWater";
            this.addWater.UseVisualStyleBackColor = true;
            this.addWater.Click += new System.EventHandler(this.addWater_Click);
            // 
            // addPorosity
            // 
            this.addPorosity.Location = new System.Drawing.Point(151, 374);
            this.addPorosity.Name = "addPorosity";
            this.addPorosity.Size = new System.Drawing.Size(133, 23);
            this.addPorosity.TabIndex = 13;
            this.addPorosity.Text = "addPorosity";
            this.addPorosity.UseVisualStyleBackColor = true;
            this.addPorosity.Click += new System.EventHandler(this.addPorosity_Click);
            // 
            // addBiota
            // 
            this.addBiota.Location = new System.Drawing.Point(151, 344);
            this.addBiota.Name = "addBiota";
            this.addBiota.Size = new System.Drawing.Size(133, 23);
            this.addBiota.TabIndex = 12;
            this.addBiota.Text = "addBiota";
            this.addBiota.UseVisualStyleBackColor = true;
            this.addBiota.Click += new System.EventHandler(this.addBiotaButton);
            // 
            // addMineral
            // 
            this.addMineral.Location = new System.Drawing.Point(151, 315);
            this.addMineral.Name = "addMineral";
            this.addMineral.Size = new System.Drawing.Size(133, 23);
            this.addMineral.TabIndex = 11;
            this.addMineral.Text = "addMineral";
            this.addMineral.UseVisualStyleBackColor = true;
            this.addMineral.Click += new System.EventHandler(this.addMineralbutton);
            // 
            // addAggregateStability
            // 
            this.addAggregateStability.Location = new System.Drawing.Point(151, 577);
            this.addAggregateStability.Name = "addAggregateStability";
            this.addAggregateStability.Size = new System.Drawing.Size(133, 23);
            this.addAggregateStability.TabIndex = 22;
            this.addAggregateStability.Text = "addAggregateStability";
            this.addAggregateStability.UseVisualStyleBackColor = true;
            this.addAggregateStability.Click += new System.EventHandler(this.addAggregateStability_Click);
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(290, 315);
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(104, 45);
            this.trackBar4.TabIndex = 26;
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(290, 344);
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(104, 45);
            this.trackBar5.TabIndex = 27;
            // 
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(290, 374);
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(104, 45);
            this.trackBar6.TabIndex = 28;
            // 
            // trackBar7
            // 
            this.trackBar7.Location = new System.Drawing.Point(290, 403);
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Size = new System.Drawing.Size(104, 45);
            this.trackBar7.TabIndex = 29;
            this.trackBar7.Scroll += new System.EventHandler(this.trackBar7_Scroll);
            // 
            // trackBar8
            // 
            this.trackBar8.Location = new System.Drawing.Point(290, 432);
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Size = new System.Drawing.Size(104, 45);
            this.trackBar8.TabIndex = 30;
            // 
            // trackBar9
            // 
            this.trackBar9.Location = new System.Drawing.Point(290, 461);
            this.trackBar9.Name = "trackBar9";
            this.trackBar9.Size = new System.Drawing.Size(104, 45);
            this.trackBar9.TabIndex = 31;
            // 
            // trackBar10
            // 
            this.trackBar10.Location = new System.Drawing.Point(290, 490);
            this.trackBar10.Name = "trackBar10";
            this.trackBar10.Size = new System.Drawing.Size(104, 45);
            this.trackBar10.TabIndex = 32;
            // 
            // trackBar11
            // 
            this.trackBar11.Location = new System.Drawing.Point(290, 519);
            this.trackBar11.Name = "trackBar11";
            this.trackBar11.Size = new System.Drawing.Size(104, 45);
            this.trackBar11.TabIndex = 33;
            // 
            // trackBar12
            // 
            this.trackBar12.Location = new System.Drawing.Point(290, 548);
            this.trackBar12.Name = "trackBar12";
            this.trackBar12.Size = new System.Drawing.Size(104, 45);
            this.trackBar12.TabIndex = 34;
            // 
            // trackBar13
            // 
            this.trackBar13.Location = new System.Drawing.Point(290, 577);
            this.trackBar13.Name = "trackBar13";
            this.trackBar13.Size = new System.Drawing.Size(104, 45);
            this.trackBar13.TabIndex = 35;
            // 
            // EvolveTime
            // 
            this.EvolveTime.Location = new System.Drawing.Point(478, 315);
            this.EvolveTime.Name = "EvolveTime";
            this.EvolveTime.Size = new System.Drawing.Size(153, 45);
            this.EvolveTime.TabIndex = 36;
            this.EvolveTime.Text = "EvolveTime";
            this.EvolveTime.UseVisualStyleBackColor = true;
            this.EvolveTime.Click += new System.EventHandler(this.EvolveTime_Click);
            // 
            // ProbeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 716);
            this.Controls.Add(this.EvolveTime);
            this.Controls.Add(this.trackBar13);
            this.Controls.Add(this.trackBar12);
            this.Controls.Add(this.trackBar11);
            this.Controls.Add(this.trackBar10);
            this.Controls.Add(this.trackBar9);
            this.Controls.Add(this.trackBar8);
            this.Controls.Add(this.trackBar7);
            this.Controls.Add(this.trackBar6);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.addAggregateStability);
            this.Controls.Add(this.addOrganicMatter);
            this.Controls.Add(this.addHumus);
            this.Controls.Add(this.addNutrientVolatility);
            this.Controls.Add(this.addErosionFactor);
            this.Controls.Add(this.addAeration);
            this.Controls.Add(this.addWater);
            this.Controls.Add(this.addPorosity);
            this.Controls.Add(this.addBiota);
            this.Controls.Add(this.addMineral);
            this.Controls.Add(this.showAggregateStability);
            this.Controls.Add(this.showOrganicMatter);
            this.Controls.Add(this.showHumus);
            this.Controls.Add(this.showNutrientVolatility);
            this.Controls.Add(this.showErosionFactor);
            this.Controls.Add(this.showAeration);
            this.Controls.Add(this.showWater);
            this.Controls.Add(this.showPorosity);
            this.Controls.Add(this.showBiota);
            this.Controls.Add(this.showMinerals);
            this.Controls.Add(this.chart);
            this.Name = "ProbeWindow";
            this.Text = "ProbeWindow";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Chart chart;
        
        public void populateChart() {
            chart = new Chart();
        }

        private System.Windows.Forms.Button showMinerals;
        private System.Windows.Forms.Button showBiota;
        private System.Windows.Forms.Button showPorosity;
        private System.Windows.Forms.Button showWater;
        private System.Windows.Forms.Button showAeration;
        private System.Windows.Forms.Button showErosionFactor;
        private System.Windows.Forms.Button showNutrientVolatility;
        private System.Windows.Forms.Button showHumus;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button showOrganicMatter;
        private System.Windows.Forms.Button showAggregateStability;
        private System.Windows.Forms.Button addOrganicMatter;
        private System.Windows.Forms.Button addHumus;
        private System.Windows.Forms.Button addNutrientVolatility;
        private System.Windows.Forms.Button addErosionFactor;
        private System.Windows.Forms.Button addAeration;
        private System.Windows.Forms.Button addWater;
        private System.Windows.Forms.Button addPorosity;
        private System.Windows.Forms.Button addBiota;
        private System.Windows.Forms.Button addMineral;
        private System.Windows.Forms.Button addAggregateStability;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.TrackBar trackBar7;
        private System.Windows.Forms.TrackBar trackBar8;
        private System.Windows.Forms.TrackBar trackBar9;
        private System.Windows.Forms.TrackBar trackBar10;
        private System.Windows.Forms.TrackBar trackBar11;
        private System.Windows.Forms.TrackBar trackBar12;
        private System.Windows.Forms.TrackBar trackBar13;
        private System.Windows.Forms.Button EvolveTime;
        private Ledger ledger;
        private WorldMap worldMap;
    }
}

