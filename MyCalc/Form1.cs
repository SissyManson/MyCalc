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
         * Event for clicking the nums 0-9
         * Event for the operations
         * Memory
         * History
         * 
         * Problems: Second num in tb1,wtf
         */
        bool isOperPerf = false;
        char lastOperation = ' ';
        double num1 = 0;
        double num2 = 0;
        bool IsFocused { get; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbInput.Focus();
        }

        private void btnNumbers_click(object sender, EventArgs e)
        {
            if (isOperPerf)
            {
                lblOperations.Text = lastOperation.ToString();
                tbInput2.Focus();
               // textBox_Result.Clear();
            }

            isOperPerf = false;
            Button button = (Button)sender;

            //I have to check if the '.' is clicked. If it is, to paste it in the tb1 or tb2, if it's not just to show what button is clicked 
            if (button.Text == ".")
            {
                if (!tbInput.Text.Contains("."))
                {
                    tbInput.Text = tbInput.Text + button.Text;
                }
                else
                {
                    tbInput2.Text = tbInput2.Text + button.Text;
                }
            }else
            {
                if (tbInput.Focus())
                {
                    tbInput.Text = tbInput.Text + button.Text;
                }
                else if(tbInput2.Focus())
                {
                    tbInput2.Text = tbInput2.Text + button.Text;
                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            lastOperation = '+';
            num1 = double.Parse(tbInput.Text);
            lblOperations.Text = lastOperation.ToString();
            if(num1 != 0)
            {
                tbInput2.Focus();
            }
           // tbInput.Clear();
        }

        private void btn_Minus_Click(object sender, EventArgs e)
        {
            lastOperation = '-';
            num1 = double.Parse(tbInput.Text);
            lblOperations.Text = lastOperation.ToString();
            if (num1 != 0)
            {
                tbInput2.Focus();
            }
            // tbInput.Clear();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            lastOperation = '*';
            num1 = double.Parse(tbInput.Text);
            lblOperations.Text = lastOperation.ToString();
            if (num1 != 0)
            {
                tbInput2.Focus();
            }
            // tbInput.Clear();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            lastOperation = '/';
            num1 = double.Parse(tbInput.Text);
            lblOperations.Text = lastOperation.ToString();
            if (num1 != 0)
            {
                tbInput2.Focus();
            }
            // tbInput.Clear();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            lastOperation = '%';
            num1 = double.Parse(tbInput.Text);
            lblOperations.Text = lastOperation.ToString();
            if (num1 != 0)
            {
                tbInput2.Focus();
            }
            //tbInput.Clear();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            num2 = double.Parse(tbInput2.Text);
            //tbInput2.Clear();
            switch (lastOperation)
            {
                case '+': tbResult.Text = (num1 + num2).ToString(); break;
                case '-': tbResult.Text = (num1 - num2).ToString(); break;
                case '*': tbResult.Text = (num1 * num2).ToString(); break;
                case '/': tbResult.Text = (num1 / num2).ToString(); break;
                case '%': tbResult.Text = (num1 % num2).ToString(); break;
            }

        }

        private void btnClrAll_Click(object sender, EventArgs e)
        {
            tbInput.Text = "";
            tbInput2.Text = "";
            tbResult.Text = "";
            lblOperations.Text = "";
        }
    }
}