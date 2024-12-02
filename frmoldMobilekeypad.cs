using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronSoftware_Challenge
{
    public partial class frmoldMobilekeypad : Form
    {
        // Creating character array align with keypad number
        char[][] keyPadCharacter =
        {
            new char[] { '&', '!', '('},
            new char[] { 'a', 'b', 'c'},
            new char[] { 'd', 'e', 'f'},
            new char[] { 'g', 'h', 'i'},
            new char[] { 'j', 'k', 'l'},
            new char[] { 'm', 'n', 'o'},
            new char[] { 'p', 'q', 'r', 's' },
            new char[] { 't', 'u', 'v'},
            new char[] { 'w', 'x', 'y','z'},
            new char[] { '*'},
            new char[] {' '},
            new char[] {'#'},

        };
        string sInputNumber="", sCurrentNumber = "", sPreviousNumber ="", sAllnumber = "";
        string sResult = "";

        public frmoldMobilekeypad()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e) //Button Click Event For 1 - 9
        {
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 1\r\n& (") // Assign Button Number Into Variable
            {
                sInputNumber += "1"; // Assign Button Number 
            }

            if (sender.ToString() == "System.Windows.Forms.Button, Text: 2 \r\na b c\r\n")
            {
                sInputNumber += "2";
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 3\r\nd e f")
            {
                sInputNumber += "3";
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 4\r\ng h i")
            {
                sInputNumber += "4";
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 5\r\nj k l")
            {
                sInputNumber += "5";
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 6\r\nm n o\r\n")
            {
                sInputNumber += "6";
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 7 \r\np q r s")
            {
                sInputNumber += "7";
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 8\r\nt u v")
            {
                sInputNumber += "8";
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 9\r\nw x y z")
            {
                sInputNumber += "9";
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: 0 \r\nspace")
            {
                sInputNumber += "0";
            }
            lblDisplay.Text = sInputNumber;
          
        }

        private string oldPhonePad(string sInput) 
        {
            string sTextResult = "";
            int iSameNumberCount = 0; 

            for (int i = 0; i < sInput.Length; i++) // Loop the whole number sentence
            {
                sCurrentNumber = sInput[i].ToString();
                if (sCurrentNumber == "0") //Check if there is space
                {
                    sPreviousNumber = "";
                    iSameNumberCount = 0;
                }
                else
                {
                    if (sCurrentNumber == sPreviousNumber) // If current number is same with previous number, system will pick next character depend on total number of Number
                    {
                        timer1.Stop();
                        timer1.Start();

                        iSameNumberCount++;

                        if (sTextResult.Length > 0)
                        {
                            sTextResult = sTextResult.Remove(sTextResult.Length - 1);
                        }

                        sTextResult += keyPadCharacter[Convert.ToInt32(sCurrentNumber) - 1][iSameNumberCount].ToString();
                    }
                    else
                    {
                        sTextResult += keyPadCharacter[Convert.ToInt32(sCurrentNumber) - 1][iSameNumberCount].ToString();
                        sPreviousNumber = sCurrentNumber;
                        iSameNumberCount = 0;
                    }
                }
            }
           

            return sTextResult;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            sCurrentNumber = "";
            sPreviousNumber = "";
            sInputNumber = "";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            lblDisplay.Text =  oldPhonePad(lblDisplay.Text); //Call function to convert digit number into character and show it in display
        }
        private void btnDelete_Click(object sender, EventArgs e) // Press < button to delete character
        {
            string sDisplayText = lblDisplay.Text;
            if (sDisplayText.Length > 0)
            {
                sDisplayText = sDisplayText.Remove(sDisplayText.Length - 1);
                lblDisplay.Text = sDisplayText;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            sPreviousNumber = "";
            sResult = "";
        }

    }
}
