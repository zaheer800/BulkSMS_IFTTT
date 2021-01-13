using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulkSMS_IFTTT
{
    public partial class Configure : Form
    {
        public Configure()
        {
            InitializeComponent();
        }

        public static string dirParameter = AppDomain.CurrentDomain.BaseDirectory + @"\Config.txt";
        static readonly string textFile = AppDomain.CurrentDomain.BaseDirectory + @"\Config.txt";

        private void btnFileExplorer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Contacts File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "Excel files (*.xls)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            openContactFile = openFileDialog1;

            if (openContactFile.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openContactFile.FileName;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableDisableControls(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEvent();
            
        }
        public void SaveEvent()
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to save configuration?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question); if (result == DialogResult.No)
            {
                return;
            }
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (txtEventName.Text != "" && txtFileName.Text != "" && txtMakerKey.Text != "")
                    {
                        saveFile(txtEventName.Text, txtFileName.Text, txtMakerKey.Text);
                    }
                    else
                    {
                        MessageBox.Show("All the fields are mandatory", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }
        public void saveFile(string eventname, string filename, string makerkey)
        {
            string Msg = eventname + ";" + filename + ";" + makerkey;

            // Save File to .txt  
            FileStream fParameter = new FileStream(dirParameter, FileMode.Create, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(Msg);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();
            EnableDisableControls(false);
            MessageBox.Show("Configurations Saved Successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Configure_Load(object sender, EventArgs e)
        {
            string[] keys;
            if (File.Exists(textFile))
            {
                // Read entire text file content in one string    
                string text = File.ReadAllText(textFile);
                if(text!="")
                {
                    keys = text.Split(';');
                    txtEventName.Text = keys[0];
                    txtFileName.Text = keys[1];
                    txtMakerKey.Text = keys[2];
                    EnableDisableControls(false);

                }
                else
                {
                    NoConfigFound(true);
                }
            }
            else
            {
                NoConfigFound(false);
            }
        }

        private void NoConfigFound(bool bFileFound)
        {
            if(!bFileFound)
            {
                MessageBox.Show("No Configuration settings found", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            EnableDisableControls(true);
        }

        private void EnableDisableControls(bool bEnable)
        {
            btnFileExplorer.Enabled = bEnable;
            txtEventName.Enabled = bEnable;
            txtFileName.Enabled = bEnable;
            txtMakerKey.Enabled = bEnable;
            btnSave.Enabled = bEnable;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (File.Exists(textFile))
            {
                ReadConfigFile(textFile);
            }
        }

        private void lnkLblIFTTT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://ifttt.com/");
            Process.Start(sInfo);
        }

        private void ReadConfigFile(string textFile)
        {
            string[] keys;
            string text = string.Empty;
            Form1 f = new Form1();

            if (File.Exists(textFile))
            {
                text = File.ReadAllText(textFile);
            }

            if (text != "")
            {
                keys = text.Split(';');
                if (keys.Length != 3)
                {
                    MessageBox.Show("Looks like the Configuration is corrupted");
                }
                else
                {
                    f.sFilename = keys[1];
                    f.sEventName = keys[0];
                    f.sKey = keys[2];
                    f.FillExcelData();
                }
            }
            else
            {
                MessageBox.Show("Invalid Configuration");
            }

        }

    }
}
