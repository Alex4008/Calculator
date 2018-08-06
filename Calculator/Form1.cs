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
        public Form1()
        {
            InitializeComponent();
        }

        string strView;
        decimal valueOne;
        decimal valueTwo;
        string strSign;
        string strValueOne;
        string strValueTwo;
        bool boolOne;
        bool boolTwo;
        bool boolSign;
        bool boolNeg;
        bool boolFin;
        bool boolDecOne;
        bool boolDecTwo;
        decimal result;
        decimal reportedValue;

        private void ClearMethod()
        {
            boolOne = false;
            boolTwo = false;
            boolSign = false;
            boolFin = false;
            lblEquals.Visible = false;
            boolDecOne = false;
            boolDecTwo = false;
            strSign = "";
            strView = "";
            valueOne = 0;
            valueTwo = 0;
            result = 0;
            lblAnswer.Text = "";
            lblViewer.Text = "";
            strValueOne = "";
            strValueTwo = "";
        }

        private void DisplayNumber(int value)
        {
            if (boolOne.Equals(false))
            {
                valueOne = value;
                strValueOne = value.ToString();
                strView = strView + value;
                lblViewer.Text = strView;
                boolOne = true;
            }
            else if (boolTwo.Equals(false) && (boolSign.Equals(true)))
            {
                valueTwo = value;
                strValueTwo = value.ToString();
                strView = strView + value;
                lblViewer.Text = strView;
                boolTwo = true;
                lblEquals.Visible = true;
            }
            else if (boolSign.Equals(false))
            {
                reportedValue = strValueOne.Length;
                if (reportedValue >= 8)
                {
                    MessageBox.Show("Error: 0");
                }
                else if(reportedValue <= 7)
                {
                    strValueOne = strValueOne + value;
                    valueOne = Convert.ToDecimal(strValueOne);
                    strView = strView + value;
                    lblViewer.Text = strView;
                }
            }
            else if (boolSign.Equals(true) && (boolFin.Equals(false)))
            {
                reportedValue = strValueTwo.Length;
                if (reportedValue >= 8)
                {
                    MessageBox.Show("Error: 1");
                }
                else
                {
                    strValueTwo = strValueTwo + value;
                    valueTwo = Convert.ToDecimal(strValueTwo);
                    strView = strView + value;
                    lblViewer.Text = strView;
                }
            }
            else
            {
                ClearMethod();
                valueOne = value;
                strValueOne = value.ToString();
                strView = strView + value;
                lblViewer.Text = strView;
                boolOne = true;
            }
        }

        private void AddOperation(string operation)
        {
            if (boolSign.Equals(false) && (boolOne.Equals(true)))
            {
                strView = strView + operation;
                lblViewer.Text = strView;
                strSign = operation;
                boolSign = true;
                boolDecOne = false;
                boolDecTwo = false;
            }
            else if (boolSign.Equals(true) && (boolFin.Equals(true)))
            {
                valueOne = result; //Sets value one to the result
                result = 0; //Resets the result
                valueTwo = 0; //Resets value two

                boolTwo = false;
                boolFin = false;
                lblEquals.Visible = false;
                lblAnswer.Text = "";
                //Adds the operation
                strView = valueOne.ToString() + operation;
                lblViewer.Text = strView;
                strSign = operation;
                boolSign = true;
                boolDecOne = false;
                boolDecTwo = false;

            }
            else if (boolSign.Equals(true) && (boolTwo.Equals(true)))
            {
                if(strSign.Equals(" + "))
                {
                    result = valueOne + valueTwo;

                    valueOne = result;
                    strValueOne = result.ToString();
                    result = 0;
                    lblAnswer.Text = "";
                    valueTwo = 0;
                    strValueTwo = "";
                    boolTwo = false;
                    strView = valueOne + operation;
                    lblEquals.Visible = false;
                    strSign = operation;
                    lblViewer.Text = strView;
                    boolDecOne = false;
                    boolDecTwo = false;
                }
                else if (strSign.Equals(" - "))
                {
                    result = valueOne - valueTwo;

                    valueOne = result;
                    strValueOne = result.ToString();
                    result = 0;
                    lblAnswer.Text = "";
                    valueTwo = 0;
                    strValueTwo = "";
                    boolTwo = false;
                    strView = valueOne + operation;
                    lblEquals.Visible = false;
                    strSign = operation;
                    lblViewer.Text = strView;
                    boolDecOne = false;
                    boolDecTwo = false;
                }
                else if (strSign.Equals(" x "))
                {
                    result = valueOne * valueTwo;

                    valueOne = result;
                    strValueOne = result.ToString();
                    result = 0;
                    lblAnswer.Text = "";
                    valueTwo = 0;
                    strValueTwo = "";
                    boolTwo = false;
                    strView = valueOne + operation;
                    lblEquals.Visible = false;
                    strSign = operation;
                    lblViewer.Text = strView;
                    boolDecOne = false;
                    boolDecTwo = false;
                }
                else if (strSign.Equals(" / "))
                {
                    result = valueOne / valueTwo;

                    valueOne = result;
                    strValueOne = result.ToString();
                    result = 0;
                    lblAnswer.Text = "";
                    valueTwo = 0;
                    strValueTwo = "";
                    boolTwo = false;
                    strView = valueOne + operation;
                    lblEquals.Visible = false;
                    strSign = operation;
                    lblViewer.Text = strView;
                    boolDecOne = false;
                    boolDecTwo = false;
                }
            }
            else if (boolSign.Equals(true))
            {
                //Reset the current operation
                boolSign = false;
                strSign = "";
                strView = valueOne.ToString();
                //Adds new seleted operation
                strView = strView + operation;
                lblViewer.Text = strView;
                strSign = operation;
                boolSign = true;
                boolDecOne = false;
                boolDecTwo = false;
            }
            else
            {
                //MessageBox.Show("Select a value!");
                boolOne = true;
                boolSign = true;
                strSign = operation;
                strValueOne = "0";
                valueOne = 0;
                strView = 0 + operation;
                lblViewer.Text = strView;
                boolDecOne = false;
                boolDecTwo = false;

            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //1
        {
            DisplayNumber(1);
        } 

        private void button2_Click(object sender, EventArgs e) // 2
        {
            DisplayNumber(2);
        }

        private void button3_Click(object sender, EventArgs e) // 3
        {
            DisplayNumber(3);
        }

        private void btnFour_Click(object sender, EventArgs e) // 4
        {
            DisplayNumber(4);
        }

        private void btnFive_Click(object sender, EventArgs e) // 5
        {
            DisplayNumber(5);
        }

        private void btnSix_Click(object sender, EventArgs e) // 6
        {
            DisplayNumber(6);
        }

        private void btnSeven_Click(object sender, EventArgs e) // 7
        {
            DisplayNumber(7);
        }

        private void btnEight_Click(object sender, EventArgs e) // 8
        {
            DisplayNumber(8);
        }

        private void btnNine_Click(object sender, EventArgs e) // 9
        {
            DisplayNumber(9);
        }

        private void btnZero_Click(object sender, EventArgs e) // 0
        {
            DisplayNumber(0);
        }

        private void btnDec_Click(object sender, EventArgs e) //This needs a shit ton of work
        {
            if (boolSign.Equals(false))
            {
                if (boolDecOne.Equals(false) && (boolOne.Equals(false)))
                {
                    DisplayNumber(0);
                    strValueOne = strValueOne + "0.";
                    valueOne = Convert.ToDecimal(strValueOne);
                    strView = strView + ".";
                    lblViewer.Text = strView;
                    boolDecOne = true;
                }
                else if(boolDecOne.Equals(false) && (boolOne.Equals(true)))
                {
                    strValueOne = strValueOne + ".";
                    valueOne = Convert.ToDecimal(strValueOne);
                    strView = strView + ".";
                    lblViewer.Text = strView;
                    boolDecOne = true;
                }
            }
            else if (boolSign.Equals(true))
            {
                if (boolDecTwo.Equals(false) && (boolTwo.Equals(false)))
                {
                    DisplayNumber(0);
                    strValueTwo = strValueTwo + "0.";
                    valueTwo = Convert.ToDecimal(strValueTwo);
                    strView = strView + ".";
                    lblViewer.Text = strView;
                    lblEquals.Visible = true;
                    boolDecTwo = true;
                }
                else if(boolDecTwo.Equals(false) && (boolTwo.Equals(true)))
                {
                    strValueTwo = strValueTwo + ".";
                    valueTwo = Convert.ToDecimal(strValueTwo);
                    strView = strView + ".";
                    lblViewer.Text = strView;
                    boolDecTwo = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) // Add
        {
            AddOperation(" + ");
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            AddOperation(" - ");
        }

        private void btnMult_Click(object sender, EventArgs e) // Multiply
        {
            AddOperation(" x ");
        }

        private void btnDiv_Click(object sender, EventArgs e) // Divide
        {
            AddOperation(" / ");
        }

        private void btnCalc_Click(object sender, EventArgs e) //Calculate
        {
            if(boolTwo.Equals(true) && (boolFin.Equals(false)))
            {
                if (strSign.Equals(" + "))
                {
                    result = valueOne + valueTwo;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else if(strSign.Equals(" - "))
                {
                    result = valueOne - valueTwo;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else if(strSign.Equals(" x "))
                {
                    result = valueOne * valueTwo;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else if (strSign.Equals(" / "))
                {
                    if(valueTwo == 0)
                    {
                        ClearMethod();
                        lblViewer.Text = "Undefined";
                    }
                    else
                    {
                        result = valueOne / valueTwo;
                        result = Math.Round(result, 2);
                        lblAnswer.Text = result.ToString();
                        boolFin = true;
                    }
                }
                else
                {
                    MessageBox.Show("Error: 2");
                }
            }
            else if (boolOne.Equals(true) && boolSign.Equals(true) && boolFin.Equals(false))
            {
                valueTwo = valueOne;
                boolTwo = true;
                strValueTwo = valueOne.ToString();
                strView = strView + strValueTwo;
                lblViewer.Text = strView;
                lblEquals.Visible = true;

                if (strSign.Equals(" + "))
                {
                    result = valueOne + valueTwo;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else if (strSign.Equals(" - "))
                {
                    result = valueOne - valueTwo;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else if (strSign.Equals(" x "))
                {
                    result = valueOne * valueTwo;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else if (strSign.Equals(" / "))
                {
                    result = valueOne / valueTwo;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else
                {
                    MessageBox.Show("Error: 3");
                }
            }
            else if(boolFin.Equals(true))
            {
                //MessageBox.Show("Select values and an operation to calculate!");
                if (strSign.Equals(" + "))
                {
                    result = valueOne + result;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else if (strSign.Equals(" - "))
                {
                    result = valueOne - result;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else if (strSign.Equals(" x "))
                {
                    result = valueOne * result;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else if (strSign.Equals(" / "))
                {
                    result = valueOne / result;
                    result = Math.Round(result, 2);
                    lblAnswer.Text = result.ToString();
                    boolFin = true;
                }
                else
                {
                    MessageBox.Show("Error: 4");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e) // Exit
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e) //Clear
        {
            ClearMethod();
        }

        private void btnDel_Click(object sender, EventArgs e) //Back button
        {
            if (boolTwo.Equals(true))
            {
                boolTwo = false;
                boolFin = false;
                valueTwo = 0;
                strValueTwo = "";
                strView = valueOne.ToString() + strSign;
                lblViewer.Text = strView;
                lblEquals.Visible = false;
                result = 0;
                lblAnswer.Text = "";
            }
            else if (boolSign.Equals(true))
            {
                boolSign = false;
                strSign = "";
                strView = valueOne.ToString();
                lblViewer.Text = strView;
            }
            else if (boolOne.Equals(true))
            {
                boolOne = false;
                valueOne = 0;
                strValueOne = "";
                strView = "";
                lblViewer.Text = strView;
            }
            else
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnNegPos_Click(object sender, EventArgs e) //Neg/Pos number
        {
            if (boolTwo.Equals(true) && boolNeg.Equals(false))
            {
                valueTwo = -valueTwo;
                strView = valueOne.ToString() + strSign + valueTwo.ToString();
                lblViewer.Text = strView;
            }
            else if (boolTwo.Equals(true) && boolNeg.Equals(true))
            {
                valueTwo = +valueTwo;
                strView = valueOne.ToString() + strSign + valueTwo.ToString();
                lblViewer.Text = strView;
            }
            else if (boolOne.Equals(true) && boolNeg.Equals(false))
            {
                valueOne = -valueOne;
                strView = valueOne.ToString() + strSign;
                lblViewer.Text = strView;
            }
            else if (boolOne.Equals(true) && boolNeg.Equals(true))
            {
                valueOne = +valueOne;
                strView = valueOne.ToString() + strSign;
                lblViewer.Text = strView;
            }
        }
    }
}
