namespace SearchTracker
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.btnSaveSitemapText = new System.Windows.Forms.Button();
            this.btnSaveRobotsText = new System.Windows.Forms.Button();
            this.comFileList = new System.Windows.Forms.ComboBox();
            this.tbSitemap = new System.Windows.Forms.TextBox();
            this.tbRobots = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbMetaKeywords = new System.Windows.Forms.TextBox();
            this.tbMetaDescription = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(556, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Set Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFolderName
            // 
            this.lblFolderName.Location = new System.Drawing.Point(105, 41);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(226, 18);
            this.lblFolderName.TabIndex = 2;
            this.lblFolderName.Text = "No Folder Selected";
            // 
            // btnSaveSitemapText
            // 
            this.btnSaveSitemapText.Location = new System.Drawing.Point(437, 243);
            this.btnSaveSitemapText.Name = "btnSaveSitemapText";
            this.btnSaveSitemapText.Size = new System.Drawing.Size(95, 23);
            this.btnSaveSitemapText.TabIndex = 5;
            this.btnSaveSitemapText.Text = "Save Sitemap";
            this.btnSaveSitemapText.UseVisualStyleBackColor = true;
            this.btnSaveSitemapText.Click += new System.EventHandler(this.btnSaveSitemapText_Click);
            // 
            // btnSaveRobotsText
            // 
            this.btnSaveRobotsText.Location = new System.Drawing.Point(443, 405);
            this.btnSaveRobotsText.Name = "btnSaveRobotsText";
            this.btnSaveRobotsText.Size = new System.Drawing.Size(89, 23);
            this.btnSaveRobotsText.TabIndex = 6;
            this.btnSaveRobotsText.Text = "Save Robots";
            this.btnSaveRobotsText.UseVisualStyleBackColor = true;
            this.btnSaveRobotsText.Click += new System.EventHandler(this.btnSaveRobotsText_Click);
            // 
            // comFileList
            // 
            this.comFileList.FormattingEnabled = true;
            this.comFileList.Location = new System.Drawing.Point(337, 36);
            this.comFileList.Name = "comFileList";
            this.comFileList.Size = new System.Drawing.Size(195, 21);
            this.comFileList.TabIndex = 7;
            this.comFileList.SelectedIndexChanged += new System.EventHandler(this.comFileList_SelectedIndexChanged);
            // 
            // tbSitemap
            // 
            this.tbSitemap.Location = new System.Drawing.Point(12, 265);
            this.tbSitemap.Multiline = true;
            this.tbSitemap.Name = "tbSitemap";
            this.tbSitemap.Size = new System.Drawing.Size(520, 132);
            this.tbSitemap.TabIndex = 8;
            this.tbSitemap.TextChanged += new System.EventHandler(this.tbSitemap_TextChanged);
            // 
            // tbRobots
            // 
            this.tbRobots.Location = new System.Drawing.Point(12, 427);
            this.tbRobots.Multiline = true;
            this.tbRobots.Name = "tbRobots";
            this.tbRobots.Size = new System.Drawing.Size(520, 117);
            this.tbRobots.TabIndex = 9;
            this.tbRobots.TextChanged += new System.EventHandler(this.tbRobots_TextChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(159, 96);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(373, 20);
            this.tbTitle.TabIndex = 10;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // tbMetaKeywords
            // 
            this.tbMetaKeywords.Location = new System.Drawing.Point(159, 137);
            this.tbMetaKeywords.Name = "tbMetaKeywords";
            this.tbMetaKeywords.Size = new System.Drawing.Size(373, 20);
            this.tbMetaKeywords.TabIndex = 11;
            this.tbMetaKeywords.TextChanged += new System.EventHandler(this.tbMetaKeywords_TextChanged);
            // 
            // tbMetaDescription
            // 
            this.tbMetaDescription.Location = new System.Drawing.Point(159, 176);
            this.tbMetaDescription.Multiline = true;
            this.tbMetaDescription.Name = "tbMetaDescription";
            this.tbMetaDescription.Size = new System.Drawing.Size(373, 61);
            this.tbMetaDescription.TabIndex = 12;
            this.tbMetaDescription.TextChanged += new System.EventHandler(this.tbMetaDescription_TextChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(457, 76);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "HTML <TITLE> Tag";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Meta <description> Tag";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Meta <keywords> Tag";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 556);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbMetaDescription);
            this.Controls.Add(this.tbMetaKeywords);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.tbRobots);
            this.Controls.Add(this.tbSitemap);
            this.Controls.Add(this.comFileList);
            this.Controls.Add(this.btnSaveRobotsText);
            this.Controls.Add(this.btnSaveSitemapText);
            this.Controls.Add(this.lblFolderName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Search Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.Button btnSaveSitemapText;
        private System.Windows.Forms.Button btnSaveRobotsText;
        private System.Windows.Forms.ComboBox comFileList;
        private System.Windows.Forms.TextBox tbSitemap;
        private System.Windows.Forms.TextBox tbRobots;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.TextBox tbMetaKeywords;
        private System.Windows.Forms.TextBox tbMetaDescription;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
    }
}

