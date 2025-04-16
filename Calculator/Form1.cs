using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double result = 0;
        private string currentOperation = "";
        private bool operationPressed = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (operationPressed)
            {
                txtDisplay.Clear();
                operationPressed = false;
            }

            Button button = (Button)sender;
            txtDisplay.Text += button.Text;
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0 && !operationPressed)
            {
                btnEqual.PerformClick();
                currentOperation = button.Text;
                lblHistory.Text = result + " " + currentOperation;
                operationPressed = true;
            }
            else
            {
                currentOperation = button.Text;
                result = Double.Parse(txtDisplay.Text);
                lblHistory.Text = result + " " + currentOperation;
                operationPressed = true;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (currentOperation)
            {
                case "+":
                    result += Double.Parse(txtDisplay.Text);
                    break;
                case "-":
                    result -= Double.Parse(txtDisplay.Text);
                    break;
                case "*":
                    result *= Double.Parse(txtDisplay.Text);
                    break;
                case "/":
                    if (txtDisplay.Text == "0")
                    {
                        MessageBox.Show("Cannot divide by zero");
                        return;
                    }
                    result /= Double.Parse(txtDisplay.Text);
                    break;
                default:
                    break;
            }
            txtDisplay.Text = result.ToString();
            lblHistory.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            result = 0;
            lblHistory.Text = "";
        }

       
        private TextBox txtDisplay;
        private Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0;
        private Button btnAdd, btnSubtract, btnMultiply, btnDivide, btnEqual, btnClear;
        private Label lblHistory;
    }

}
