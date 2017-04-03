using System;
using System.IO;
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
                using (SaveFileDialog SD = new SaveFileDialog())
                {
                    if (!SD.CheckFileExists)
                    {
                        File.WriteAllText(SD.FileName, txtMainEdit.Text);
                    }
                }             
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

            OpenFileDialog OD = new OpenFileDialog()
            {
                InitialDirectory = "c:\\",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if(OD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(OD.FileName))
                    {
                        txtMainEdit.Text = sr.ReadToEnd();
                        currentFileName = OD.FileName;
                        isDirty = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
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

            this.Close();
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentFile();
        }
    }
}
