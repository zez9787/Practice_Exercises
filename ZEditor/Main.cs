using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZEditor
{
    public partial class Main : Form
    {
        public bool isDirty;
        private string currentFileName;

        public Main()
        {
            InitializeComponent();
        }

        private void txtMainEdit_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void SaveCurrentFile()
        {
            if (currentFileName != "")
            {
                File.WriteAllText(currentFileName, txtMainEdit.Text);
                isDirty = false;
            }
            else
            {
                SaveFileDialog SD = new SaveFileDialog();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDirty)
            {
                DialogResult result = MessageBox.Show("File has been modified. Do you want to save changes?",
                    "Save Changes?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SaveCurrentFile();
                }
                else if (result == DialogResult.Cancel)
                    return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.CheckFileExists)
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    txtMainEdit.Text = sr.ReadToEnd();
                    currentFileName = openFileDialog1.FileName;
                }
            }
            isDirty = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDirty)
            {
                DialogResult result = MessageBox.Show("File has been modified. Do you want to save changes?",
                    "Save Changes?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SaveCurrentFile();
                    return;
                }
                else if (result == DialogResult.Cancel)
                    return;
            }
            txtMainEdit.Text = "";
            currentFileName = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (isDirty)
            {
                DialogResult result = MessageBox.Show("File has been modified. Do you want to save changes?",
                       "Save Changes?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SaveCurrentFile();
                }
                else if (result == DialogResult.Cancel)
                    return;
            }
            this.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SD = new SaveFileDialog();
            if (SD.ShowDialog() == DialogResult.OK)
            {
                if (!SD.CheckFileExists)
                {
                    File.WriteAllText(SD.FileName, txtMainEdit.Text);
                    isDirty = false;
                    currentFileName = SD.FileName;
                }
            }
        }
    }
}
