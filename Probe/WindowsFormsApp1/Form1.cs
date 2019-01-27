using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbeTool {
    public partial class ProbeWindow : Form {
        public ProbeWindow() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.chart.Series["Nutrient Content"].Points.AddXY("Henry",23);
            this.chart.Series["Nutrient Content"].Points.AddXY("Sam", 22);
            this.chart.Series["Nutrient Content"].Points.AddXY("Martin", 67);
            this.chart.Series["Nutrient Content"].Points.AddXY("Adrienne", 54);

        }
    }
}
