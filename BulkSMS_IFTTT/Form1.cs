using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;

namespace BulkSMS_IFTTT
{
    public partial class Form1 : Form
    {
        public string sConnectionString;
        static readonly string textFile = AppDomain.CurrentDomain.BaseDirectory + @"\Config.txt";
        string sFilename = string.Empty;
        string sEventName = string.Empty;
        string sKey = string.Empty;
        CheckBox headerCheckBox = new CheckBox();
        private static readonly HttpClient client = new HttpClient();
        decimal ProgressBarMax = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configure configureWindow = new Configure();
            configureWindow.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] keys;
            if (File.Exists(textFile))
            {
                // Read entire text file content in one string    
                string text = File.ReadAllText(textFile);
                if (text != "")
                {
                    keys = text.Split(';');
                    if (keys.Length == 0)
                    {
                        Configure configure = new Configure();
                        configure.ShowDialog();
                        FillExcelData();
                    }
                    else
                    {
                        sFilename = keys[1];
                        sEventName = keys[0];
                        sKey = keys[2];
                        FillExcelData();
                    }
                }

            }
            else
            {
                Configure configure = new Configure();
                configure.ShowDialog();
                FillExcelData();
            }
        }

        private void FillData()
        {
            FileInfo file = new FileInfo(sFilename);
            if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
            string extension = file.Extension;
            switch (extension)
            {
                case ".xls":
                    sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilename + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
                case ".xlsx":
                    sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilename + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    break;
                default:
                    sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilename + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }
            //sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + sFilename + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";
            if (sConnectionString.Length > 0)
            {
                OleDbConnection cn = new OleDbConnection(sConnectionString);
                {
                    cn.Open();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter Adpt = new OleDbDataAdapter("select * from [sheet1$]", cn);
                    Adpt.Fill(dt);
                    DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                    dgvCmb.ValueType = typeof(bool);
                    dgvCmb.Name = "Chk";
                    dgvCmb.HeaderText = "Select";
                    dataGridView1.Columns.Add(dgvCmb);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void FillExcelData()
        {
            using (var stream = File.Open(sFilename, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                   
                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    // The result of each spreadsheet is in result.Tables
                    DataTable dt = new DataTable();
                    dt = result.Tables[0];
                    dataGridView1.DataSource = dt;
                    //Add a CheckBox Column to the DataGridView Header Cell.

                    //Find the Location of Header Cell.
                    Point headerCellLocation = this.dataGridView1.GetCellDisplayRectangle(0, -1, true).Location;

                    //Place the Header CheckBox in the Location of the Header Cell.
                    headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
                    headerCheckBox.BackColor = Color.White;
                    headerCheckBox.Size = new Size(18, 18);

                    //Assign Click event to the Header CheckBox.
                    headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
                    dataGridView1.Controls.Add(headerCheckBox);

                    //Add a CheckBox Column to the DataGridView at the first position.
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = "";
                    checkBoxColumn.Width = 30;
                    checkBoxColumn.Name = "checkBoxColumn";
                    dataGridView1.Columns.Insert(0, checkBoxColumn);

                    //Assign Click event to the DataGridView Cell.
                    dataGridView1.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);

                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
            if (txtMessage.Text != "")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue) == true)
                    {
                        ProgressBarMax += 1;
                    }
                }
                //MessageProgress.Maximum = ProgressBarMax;
                sendSMSAsync();
            }
            else
            {
                MessageBox.Show("There is no message to send", "BulkSMS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }

        private void sendSMSAsync()
        {
            
            decimal success = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue) == true)
                {
                    DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);

                    string strName = row.Cells[1].EditedFormattedValue.ToString();
                    string strPhoneNumber = row.Cells[2].EditedFormattedValue.ToString();

                    var request = (HttpWebRequest)WebRequest.Create("https://maker.ifttt.com/trigger/" + sEventName + "/with/key/" + sKey);
                    var postData = "value1=" + Uri.EscapeDataString(strPhoneNumber);
                    postData = postData + "&value2=" + Uri.EscapeDataString("Hi " + strName + ", " + txtMessage.Text);
                    var data = Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var response = (HttpWebResponse)request.GetResponse();

                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    postData = "";

                    success += 1;
                    
                    decimal v = Math.Abs(success / ProgressBarMax);
                    MessageProgress.Value = Convert.ToInt32(v * 100);
                    lblstatus.Text = success.ToString() +" / " + ProgressBarMax.ToString();
                    checkBox.Value = false;
                    headerCheckBox.Checked = false;
                    
                }
               
            }

            MessageBox.Show("Messages Successfully Sent.!!!");
            txtMessage.Text = "";
            ProgressBarMax = 0;
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dataGridView1.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = isChecked;
            }
        }
    }
}
