using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCI.DCEG.BCRA.Engine;
using NCI.DCEG.BCRA.ConsoleSample;

namespace RiskCalculatorUI
{
    public partial class first_window : Form
    {

        public static Point l1 = new Point();
        public static int prediction = 0;
        public static double predictionResult = 0.0;
        public static double averageRisk = 0.0;
        public first_window()
        {
            InitializeComponent();
        }
        Point mouseDownPoint = Point.Empty;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPoint = Point.Empty;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint.IsEmpty)
                return;
            Form f = sender as Form;
            f.Location = new Point(f.Location.X + (e.X - mouseDownPoint.X), f.Location.Y + (e.Y - mouseDownPoint.Y));
            l1 = f.Location;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            l1 = this.Location;
            
           
        }

       
        private void firstNameInput_Click(object sender, EventArgs e)
        {
            if (firstNameInput.Text == "Sarah") {
                firstNameInput.Clear();   
            }
        }
        private void lastNameInput_Click(object sender, EventArgs e)
        {
            if (lastNameInput.Text == "Williams")
            {
                lastNameInput.Clear();
            }
        }
        private void birthDateInput_Click(object sender, EventArgs e) {
            if (birthDateInput.Text == "yyyy/mm/dd")
            {
                birthDateInput.Clear();
            }
        }
        private void emailInput_Click(object sender, EventArgs e) {
            if (emailInput.Text == "sarah@example.com")
            {
                emailInput.Clear();
            }
        }
        private void projectionInput_Click(object sender, EventArgs e) {
            if (projectionInput.Text == "years")
            {
                projectionInput.Clear();
            }
        }
        private void menarchInput_Click(object sender, EventArgs e) {
            if (menarchInput.Text == "years")
            {
                menarchInput.Clear();
            }
        }
        private void firstChildAge_Click(object sender, EventArgs e) {
            if (firstChildAge.Text == "years")
            {
                firstChildAge.Clear();
            }
        }
        private void numberOfBiopsies_Click(object sender, EventArgs e)
        {
            if (numberOfBiopsies.Text == "number")
            {
                numberOfBiopsies.Clear();
            }
        }
        private void firstRelativesInput_Click(object sender, EventArgs e)
        {
            if (firstRelativesInput.Text == "number")
            {
                firstRelativesInput.Clear();
            }
        }

        private void evaluate_Click(object sender, EventArgs e)
        {
            evaluateRisk();
        }


        public void evaluateRisk(){
            

            double absRisk = 0, avgRisk = 0, absRiskPctg = 0, avgRiskPctg = 0;
            
            //int currentAge = BcptConvert.GetCurrentAge(35);
            //int menarcheAge = BcptConvert.GetMenarcheAge("11");
            //int firstLiveBirthAge = BcptConvert.GetFirstLiveBirthAge("29");
            //int firstDegreeRel = BcptConvert.GetFirstDegRelatives("1");
            //int hadBiopsy = BcptConvert.GetEverHadBiopsy("1");
            //int numBiopsy = BcptConvert.GetNumberOfBiopsy("1");
            //int hyperPlasia = BcptConvert.GetHyperPlasia("1");
            //int race = BcptConvert.GetRace("7");
            string[] qw = (birthDateInput.Text).Split('/');
            int xy = Convert.ToInt32(qw[0]);
            int ag = 2014 - xy;
            prediction = Convert.ToInt32(projectionInput.Text);
            int currentAge = BcptConvert.GetCurrentAge(ag);

            int menarcheAge = BcptConvert.GetMenarcheAge(menarchInput.Text);
            int firstLiveBirthAge = BcptConvert.GetFirstLiveBirthAge(firstChildAge.Text);
            int firstDegreeRel = BcptConvert.GetFirstDegRelatives(firstRelativesInput.Text);
            int hadBiopsy = BcptConvert.GetEverHadBiopsy(breastBiopsy.SelectedItem.ToString());
            
            int numBiopsy = BcptConvert.GetNumberOfBiopsy(numberOfBiopsies.Text);
            int hyperPlasia = BcptConvert.GetHyperPlasia(hyperplasiaInput.SelectedItem.ToString());

            int race = BcptConvert.GetRace(raceInput.SelectedItem.ToString());
            // Calculate 5 year risk.
            Helper.RiskCalc(0, currentAge, currentAge + 5, menarcheAge, firstLiveBirthAge, hadBiopsy, numBiopsy,
                hyperPlasia, firstDegreeRel, race, out absRisk, out avgRisk);
            Helper.CalcPercentage(absRisk, avgRisk, out absRiskPctg, out avgRiskPctg);

            predictionResult = absRiskPctg;
            averageRisk = avgRiskPctg;

            Console.WriteLine("5 year risk");
            Console.WriteLine("This woman (age {0:N}) = {1:F}", currentAge, absRiskPctg);
            Console.WriteLine("Average woman (age {0:N}) = {1:F}", currentAge, avgRiskPctg);
            //System.Windows.Forms.MessageBox.Show(absRiskPctg.ToString());
            // Calculate lifetime risk.
            Helper.RiskCalc(0, currentAge, 90, menarcheAge, firstLiveBirthAge, hadBiopsy, numBiopsy,
                hyperPlasia, firstDegreeRel, race, out absRisk, out avgRisk);
            Helper.CalcPercentage(absRisk, avgRisk, out absRiskPctg, out avgRiskPctg);


            results rsWin = new results();
            rsWin.Show();

            Console.WriteLine("\nLifetime risk");
            Console.WriteLine("This woman (to age 90): " + absRiskPctg.ToString("F1"));
            Console.WriteLine("Average woman (to age 90): " + avgRiskPctg.ToString("F1"));
            //nameLabel.Text = absRiskPctg.ToString("F1");
            Console.Read();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        


    }

    
}
    