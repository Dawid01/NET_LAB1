using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KnapsackProblem;

namespace KnapsackProblemWindowApp
{
    public partial class Knapsack : Form
    {
        private TextBox _resultText;

        public Knapsack()
        {
            InitializeComponent();
            this.Text = "Knapsack";
            
        }

        private void run_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}