using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReverseString;

namespace PalindromeCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string tempString = textBox1.Text;
            if (!string.IsNullOrEmpty(tempString))
            {
                label1.Visible = tempString == ReverseString.Program.ReverseThisString(tempString);                
            }
        }
    }
}
