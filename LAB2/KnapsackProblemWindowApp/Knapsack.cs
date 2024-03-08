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

        public Knapsack()
        {
            InitializeComponent();
        }

        private void run_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numberOfItemsText.Text) || 
                string.IsNullOrWhiteSpace(seedText.Text) || 
                string.IsNullOrWhiteSpace(capacityText.Text))
            {
                MessageBox.Show("Fill in all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int n, seed, capacity;
            
            if (!int.TryParse(numberOfItemsText.Text, out n) ||
                !int.TryParse(seedText.Text, out seed) ||
                !int.TryParse(capacityText.Text, out capacity))
            {
                MessageBox.Show("Invalid input. Please enter valid integers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            Problem problem = new Problem(n, seed);
            instance.Text = problem.ToString();
            result.Text = problem.Solve(capacity).ToString();
        }
        
    }
}