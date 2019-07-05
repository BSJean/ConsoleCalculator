using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Operation.DictionarySet();
            comboBoxOperation.Items.AddRange(Operation.SupportedFunctions.Keys.ToArray());
            comboBoxOperation.SelectedItem = Operation.SupportedFunctions.Keys.ToArray()[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbArgs.Focus();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            List<double> argsList = new List<double>();
            bool isRight = false;
            
                string[] argsString = tbArgs.Text.Trim(' ').Split(' ');
                foreach (string s in argsString)
                {
                    double result;
                    if (Double.TryParse(s, out result))
                    {
                        argsList.Add(result);
                        isRight = true;
                    }
                    else if (s != "")
                    {
                        isRight = false;
                        break;
                    }
                }
                if (!isRight)
                {
                    MessageBox.Show("Wrong arguments!");
                    argsList.Clear();
                }
                else if (Operation.Check(comboBoxOperation.SelectedItem.ToString(), argsList.ToArray()) == false)
                {
                    MessageBox.Show("Not enough arguments!");
                    isRight = false;
                    argsList.Clear();
                }
            if (isRight)
            {
                double[] argsFunc = argsList.ToArray();
                tbResult.Text = Operation.SupportedFunctions[comboBoxOperation.SelectedItem.ToString()].Call(argsFunc).ToString();
            }
            tbArgs.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbInfo.Text = Operation.Help;
        }        

        private void tbArgs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnCalc_Click(sender, e);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbArgs.Text = "";
            tbArgs.Focus();
        }
    }
}
