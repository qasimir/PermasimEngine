using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProbeTool {
    public partial class ProbeWindow : Form {
        public ProbeWindow() {
            InitializeComponent();
        }

        private bool mineralsOn = false;
        private bool biotaOn = false;
        private bool porosityOn = false;
        private bool waterOn = false;
        private bool aerationOn = false;
        private bool erosionFactorOn = false;
        private bool nutrientVolatilityOn = false;
        private bool humusOn = false;
        private bool OrganicMatterOn = false;
        private bool aggregateStabilityOn = false;

        // we need series and buttons for:
        // all nutrients
        // biota
        // porosity
        // water 
        // aeration
        // erosion factor
        // nutrient volatility
        // humus
        // organicMatter
        // aggregateStability


        // need buttons/sliders for:

        // compaction event
        // digging
        // rain
        // adding/subtracting from the above
        // time evolution

        private Series buildSeries(string name) {
            Series series = new Series();
            series.ChartArea = "ChartArea1";
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.Legend = "Legend1";
            series.Name = name;
            return series;
        }

        private void toggleMinerals(object sender, EventArgs e) {
            if (mineralsOn) {
                SeriesCollection series = this.chart.Series;
                series.RemoveAt(series.IndexOf("Nitrogen"));
                series.RemoveAt(series.IndexOf("Phosphorus"));
                series.RemoveAt(series.IndexOf("Potassium"));
                series.RemoveAt(series.IndexOf("traceMinerals"));
            } else {
                this.chart.Series.Add(buildSeries("Nitrogen"));
                this.chart.Series.Add(buildSeries("Phosphorus"));
                this.chart.Series.Add(buildSeries("Potassium"));
                this.chart.Series.Add(buildSeries("traceMinerals"));
                //this.chart.Series["Nitrogen"].Points
            }
            
        }

        private void displayBiota(object sender, EventArgs e) {

        }

        private void displayPorosity(object sender, EventArgs e) {

        }

        private void displayWater(object sender, EventArgs e) {

        }

        private void displayAeration(object sender, EventArgs e) {

        }

        private void displayErosionFactor(object sender, EventArgs e) {

        }

        private void displayNutrientVolatility(object sender, EventArgs e) {

        }

        private void displayHumus(object sender, EventArgs e) {

        }

        private void displayOrganicMatter(object sender, EventArgs e) {

        }

        private void displayAggregateStability(object sender, EventArgs e) {

        }

        private void addMineralbutton(object sender, EventArgs e) {

        }

        private void addBiotaButton(object sender, EventArgs e) {

        }

        private void addPorosity_Click(object sender, EventArgs e) {

        }

        private void addAeration_Click(object sender, EventArgs e) {

        }

        private void addWater_Click(object sender, EventArgs e) {

        }

        private void addErosionFactor_Click(object sender, EventArgs e) {

        }

        private void addNutrientVolatility_Click(object sender, EventArgs e) {

        }

        private void addHumus_Click(object sender, EventArgs e) {

        }

        private void addOrganicMatter_Click(object sender, EventArgs e) {

        }

        private void addAggregateStability_Click(object sender, EventArgs e) {

        }

        private void trackBar7_Scroll(object sender, EventArgs e) {

        }

        private void EvolveTime_Click(object sender, EventArgs e) {
            TimeEvolver timeEvolver = new TimeEvolver();
            timeEvolver.evolveTime();
            this.ledger.updateLedger();
            
        }
    }
}
