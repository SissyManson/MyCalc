using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalc
{
    public partial class Form1 : Form
    {
        /*
         * Creating a calc with 3tb for the num1&2 & the result + lbl to show the operation(+, -, * , /, % ) 
         *  Event for clicking the nums 0-9
         *  Event for the operations
         * Memory
         * History
         * 
         */
         
        double num1 = 0;
        double num2 = 0;
        double memory = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblOperations.Text = "";
            btnMC.Enabled = false;
            btnMR.Enabled = false;
            lbHistory.Items.Clear();
        }
        //buttons 0-9 and .
        private void btnNumbers_click(object sender, EventArgs e)
        {
            string btnNumber = ((Button)sender).Text;
            if (lblOperations.Text == "")
                tbInput.Text += btnNumber;
            else
                tbInput2.Text += btnNumber;
        }
        // button =
        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                num1 = double.Parse(tbInput.Text);
                num2 = double.Parse(tbInput2.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Empty Fields !");

            }
            catch (OverflowException exc)
            {
                MessageBox.Show(exc.Message);
            }
            catch (Exception)
            {

            }
            calculate();

            //to the history
            string oper = lblOperations.Text;
            string history = tbInput.Text + " " + oper + " " + tbInput2.Text + " = " + tbResult.Text;
            lbHistory.Items.Add(history);
        }
        //function for calculating the result
        private void calculate()
        {

            double result = 0;

            switch (lblOperations.Text)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "%": result = num1 % num2; break;
                case "/":
                    try
                    {
                        result = num1 / num2;
                    }
                    catch (DivideByZeroException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }

            tbResult.Text = result.ToString();
        }
        //btn CE
        private void btnClrAll_Click(object sender, EventArgs e)
        {
            tbInput.Text = "";
            tbInput2.Text = "";
            tbResult.Text = "";
            lblOperations.Text = "";
        }
        //for the operations + - * / %
        private void btnoperchange_click(object sender, EventArgs e)
        {
            string symbol = ((Button)sender).Text;
            lblOperations.Text = symbol;
            
            if (tbInput.Text != "" && tbInput2.Text != "" && lblOperations.Text != "")
            {
                tbInput.Text = tbResult.Text;
                tbInput2.Clear();
                tbResult.Text = "";

                calculate();
            }
            
        }
        //for the memory
        private void btnMC_Click(object sender, EventArgs e)
        {
            memory = 0;
            tbResult.Text = memory.ToString();
            tbInput.Text = "";
            btnMC.Enabled = false;
            btnMR.Enabled = false;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            tbResult.Text = memory.ToString();
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            double res = double.Parse(tbInput.Text);
            memory += res;
            btnMR.Enabled = true;
            btnMC.Enabled = true;
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            double res = double.Parse(tbInput.Text);
            memory -= res;
        }

        //history
        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (!lbHistory.Visible)
            {
                lbHistory.Visible = true;
            }
            else
                lbHistory.Visible = false;
        }
    }
}