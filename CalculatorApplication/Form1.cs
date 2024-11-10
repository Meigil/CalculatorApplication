using System;
using System.Windows.Forms;

namespace CalculatorApplication
{
    public partial class Form1 : Form
    {
        private CalculatorClass cal;
        private double num1, num2;

        public Form1()
        {
            InitializeComponent();
            cal = new CalculatorClass();
        }


        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {

                num1 = Convert.ToDouble(txtBoxInput1.Text);
                num2 = Convert.ToDouble(txtBoxInput2.Text);


                string operation = cbOperator.SelectedItem.ToString();
                double result = 0;


                switch (operation)
                {
                    case "+":
                        result = cal.GetSum(num1, num2);
                        break;
                    case "-":
                        result = cal.GetDifference(num1, num2);
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            throw new DivideByZeroException();
                        break;
                    default:
                        MessageBox.Show("Select a valid operator.");
                        return;
                }


                lblDisplayTotal.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Cannot divide by zero.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class CalculatorClass
    {
       
        public delegate T Information<T>(T arg);
        public Information<double> info;


        public event Information<double> CalculateEvent
        {
            add
            {
                Console.WriteLine("Added the delegate.");
            }
            remove
            {
                Console.WriteLine("Removed the delegate.");
            }
        }

        public double GetSum(double num1, double num2)
        {
            return num1 + num2;
        }

        
        public double GetDifference(double num1, double num2)
        {
            return num1 - num2;
        }
    }

   
}



