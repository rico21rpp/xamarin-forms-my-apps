using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalculatorPage : ContentPage
	{
        private double amount = 0;
        private bool oprClicked = false;
        private bool totalCounted = false;

        public CalculatorPage ()
		{
			InitializeComponent ();
		}

        // -------------------------------- Operation --------------------------------

        private void OnBtnClearClicked(object sender, EventArgs e)
        {
            DynamicsNum.Text = "0";
            StaticNum.Text = "";
            amount = 0;
        }

        private void ClearTotal(object sender, EventArgs e)
        {
            if (totalCounted)
            {
                OnBtnClearClicked(sender, e);
                totalCounted = false;
            }
        }

        private void OnBtnDelClicked(object sender, EventArgs e)
        {
            var dynamicNum = DynamicsNum.Text;

            if (!totalCounted && dynamicNum != "0")
            {
                if (dynamicNum.Length == 1)
                {
                    DynamicsNum.Text = "0";
                }
                else
                {
                    int len = dynamicNum.Length;
                    DynamicsNum.Text = dynamicNum.Substring(0, len - 1);
                }
            }
        }

        private void OnBtnTotalClicked(object sender, EventArgs e)
        {
            if (!totalCounted)
            {
                var staticNum = StaticNum.Text;
                var dynamicNum = DynamicsNum.Text;

                if (staticNum != "")
                {
                    if (dynamicNum != "0")
                    {
                        string[] staticNumSplitted = staticNum.Split(' ');
                        string lastOpr = staticNumSplitted[staticNumSplitted.Length - 1];

                        if (lastOpr == "+")
                        {
                            amount += double.Parse(dynamicNum);
                        }
                        else if (lastOpr == "-")
                        {
                            amount -= double.Parse(dynamicNum);
                        }
                        else if (lastOpr == "x")
                        {
                            amount *= double.Parse(dynamicNum);
                        }
                        else if (lastOpr == "/")
                        {
                            amount /= double.Parse(dynamicNum);
                        }

                        StaticNum.Text = staticNum + " " + dynamicNum + " = " + amount;
                        DynamicsNum.Text = amount + "";
                        totalCounted = true;
                    }
                }
            }
        }

        private void OnBtnOprClicked(object sender, EventArgs e, string opr)
        {
            ClearTotal(sender, e);

            var staticNum = StaticNum.Text;
            var dynamicNum = DynamicsNum.Text;

            if (staticNum == "")
            {
                if (dynamicNum != "0")
                {
                    StaticNum.Text = dynamicNum + " " + opr;
                    amount = double.Parse(dynamicNum);
                }
            }
            else
            {
                string[] staticNumSplitted = staticNum.Split(' ');
                string lastOpr = staticNumSplitted[staticNumSplitted.Length - 1];

                if (lastOpr == "+")
                {
                    amount += double.Parse(dynamicNum);
                }
                else if (lastOpr == "-")
                {
                    amount -= double.Parse(dynamicNum);
                }
                else if (lastOpr == "x")
                {
                    amount *= double.Parse(dynamicNum);
                }
                else if (lastOpr == "/")
                {
                    amount /= double.Parse(dynamicNum);
                }

                StaticNum.Text = staticNum + " " + dynamicNum + " " + opr;
                DynamicsNum.Text = amount + "";
            }
            oprClicked = true;
        }

        private void OnBtnPlusClicked(object sender, EventArgs e)
        {
            OnBtnOprClicked(sender, e, "+");
        }

        private void OnBtnSubClicked(object sender, EventArgs e)
        {
            OnBtnOprClicked(sender, e, "-");
        }

        private void OnBtnMulClicked(object sender, EventArgs e)
        {
            OnBtnOprClicked(sender, e, "x");
        }

        private void OnBtnDivClicked(object sender, EventArgs e)
        {
            OnBtnOprClicked(sender, e, "/");
        }

        // -------------------------------- Number --------------------------------



        private void OnBtnCommaClicked(object sender, EventArgs e)
        {
            if (oprClicked)
            {
                DynamicsNum.Text = "0.";
                oprClicked = false;
            }
            else
            {
                var dynamicNum = DynamicsNum.Text;
                DynamicsNum.Text = dynamicNum + ".";
            }
        }

        private void OnBtn0Clicked(object sender, EventArgs e)
        {
            ClearTotal(sender, e);

            var staticNum = StaticNum.Text;
            var dynamicNum = DynamicsNum.Text;

            if (staticNum == "")
            {
                if (dynamicNum != "0")
                {
                    DynamicsNum.Text = dynamicNum + "0";
                }
            }
            else
            {
                if (oprClicked)
                {
                    DynamicsNum.Text = "0";
                    oprClicked = false;
                }
                else
                {
                    if (dynamicNum != "0")
                    {
                        DynamicsNum.Text = dynamicNum + "0";
                    }
                }
            }
        }


        private void OnBtnNumClicked(object sender, EventArgs e, string numStr)
        {
            ClearTotal(sender, e);
            var staticNum = StaticNum.Text;
            var dynamicNum = DynamicsNum.Text;

            if (staticNum == "")
            {
                if (dynamicNum == "0")
                {
                    DynamicsNum.Text = numStr;
                }
                else
                {
                    DynamicsNum.Text = dynamicNum + numStr;
                }
            }
            else
            {
                if (oprClicked)
                {
                    DynamicsNum.Text = numStr;
                    oprClicked = false;
                }
                else
                {
                    if (dynamicNum == "0")
                    {
                        DynamicsNum.Text = numStr;
                    }
                    else
                    {
                        DynamicsNum.Text = dynamicNum + numStr;
                    }

                }
            }
        }

        private void OnBtn1Clicked(object sender, EventArgs e)
        {
            OnBtnNumClicked(sender, e, "1");
        }

        private void OnBtn2Clicked(object sender, EventArgs e)
        {
            OnBtnNumClicked(sender, e, "2");
        }

        private void OnBtn3Clicked(object sender, EventArgs e)
        {
            OnBtnNumClicked(sender, e, "3");
        }

        private void OnBtn4Clicked(object sender, EventArgs e)
        {
            OnBtnNumClicked(sender, e, "4");
        }

        private void OnBtn5Clicked(object sender, EventArgs e)
        {
            OnBtnNumClicked(sender, e, "5");
        }

        private void OnBtn6Clicked(object sender, EventArgs e)
        {
            OnBtnNumClicked(sender, e, "6");
        }

        private void OnBtn7Clicked(object sender, EventArgs e)
        {
            OnBtnNumClicked(sender, e, "7");
        }

        private void OnBtn8Clicked(object sender, EventArgs e)
        {
            OnBtnNumClicked(sender, e, "8");
        }

        private void OnBtn9Clicked(object sender, EventArgs e)
        {
            OnBtnNumClicked(sender, e, "9");
        }
    }
}