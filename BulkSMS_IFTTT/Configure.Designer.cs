
namespace BulkSMS_IFTTT
{
    partial class Configure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configure));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkLblIFTTT = new System.Windows.Forms.LinkLabel();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMakerKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFileExplorer = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openContactFile = new System.Windows.Forms.OpenFileDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkLblIFTTT);
            this.groupBox1.Controls.Add(this.txtEventName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMakerKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IFTTT Settings";
            // 
            // lnkLblIFTTT
            // 
            this.lnkLblIFTTT.AutoSize = true;
            this.lnkLblIFTTT.Location = new System.Drawing.Point(432, 80);
            this.lnkLblIFTTT.Name = "lnkLblIFTTT";
            this.lnkLblIFTTT.Size = new System.Drawing.Size(46, 17);
            this.lnkLblIFTTT.TabIndex = 5;
            this.lnkLblIFTTT.TabStop = true;
            this.lnkLblIFTTT.Text = "IFTTT";
            this.lnkLblIFTTT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblIFTTT_LinkClicked);
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(170, 72);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(139, 22);
            this.txtEventName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "IFTTT Event Name:";
            // 
            // txtMakerKey
            // 
            this.txtMakerKey.Location = new System.Drawing.Point(170, 34);
            this.txtMakerKey.Name = "txtMakerKey";
            this.txtMakerKey.Size = new System.Drawing.Size(308, 22);
            this.txtMakerKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IFTTT Maker Key:";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(164, 226);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 29);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(257, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFileExplorer);
            this.groupBox2.Controls.Add(this.txtFileName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contacts File";
            // 
            // btnFileExplorer
            // 
            this.btnFileExplorer.Location = new System.Drawing.Point(485, 32);
            this.btnFileExplorer.Name = "btnFileExplorer";
            this.btnFileExplorer.Size = new System.Drawing.Size(42, 23);
            this.btnFileExplorer.TabIndex = 2;
            this.btnFileExplorer.Text = "...";
            this.btnFileExplorer.UseVisualStyleBackColor = true;
            this.btnFileExplorer.Click += new System.EventHandler(this.btnFileExplorer_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(108, 32);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(370, 22);
            this.txtFileName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "File Name:";
            // 
            // openContactFile
            // 
            this.openContactFile.FileName = "openFileDialog1";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(350, 226);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 268);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Configure";
            this.Text = "Configure";
            this.Load += new System.EventHandler(this.Configure_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lnkLblIFTTT;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMakerKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFileExplorer;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openContactFile;
        private System.Windows.Forms.Button btnClose;
    }
}