using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskCalculatorUI
{
    public partial class results : Form
    {
        public results()
        {
            InitializeComponent();
        }

        private void results_Load(object sender, EventArgs e)
        {
            label1.Text = first_window.prediction.ToString() + " years risk for this woman: " + first_window.predictionResult.ToString();
            label2.Text = first_window.prediction.ToString() + " years risk for average woman: " + first_window.averageRisk.ToString();
            this.Location = first_window.l1;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 100)
            {
                this.Opacity = this.Opacity + 0.2;
            }
            else {
                timer1.Stop();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void evaluate_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       
    }
}
