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
                    if (txtEventName.Text != null && txtFileName.Text != null && txtMakerKey.Text != null)
                    {
                        saveFile(txtEventName.Text, txtFileName.Text, txtMakerKey.Text);
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
        }
    }
}
