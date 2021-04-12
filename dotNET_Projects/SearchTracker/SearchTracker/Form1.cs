using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SearchTracker
{
    public partial class Form1 : Form
    {
        public string appName = "Search Tracker";
        public string folderName = "No Folder Selected";
        public bool bSitemapModified = false;
        public bool bRobotsModified = false;
        public bool bFileModified = false;
        public bool bListboxInit = false;
        public int iHeadLine = -1;
        public int iTitleLine = -1;
        public int iMetaKeywordsLine = -1;
        public int iMetaDescriptionLine = -1;
        public string strFilename = "";
        public string[] lines = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void resetControls()
        {
            bFileModified = false;
            iHeadLine = -1;
            iTitleLine = -1;
            iMetaDescriptionLine = -1;
            iMetaKeywordsLine = -1;
            strFilename = "";
            lines = null;

            btnUpdate.Enabled = false;
            tbMetaDescription.SelectedText = "";
            tbMetaKeywords.SelectedText = "";
            tbTitle.SelectedText = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit " + appName, appName, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes) { this.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.lblFolderName.Text = folderBrowserDialog1.SelectedPath;
                folderName = folderBrowserDialog1.SelectedPath;

                this.btnSaveRobotsText.Enabled = true;
                this.btnSaveSitemapText.Enabled = true;
                //this.btnUpdate.Enabled = true;
                this.comFileList.Enabled = true;
                this.tbRobots.Enabled = true;
                this.tbSitemap.Enabled = true;

                bListboxInit = true;
                this.comFileList.Items.Clear();
                string[] files = System.IO.Directory.GetFiles(folderName);
                foreach (string filename in files)
                {
                    string tmp = filename.Substring(filename.LastIndexOf(@"\") + 1);
                    this.comFileList.Items.Add(tmp);
                }
                this.comFileList.SelectedIndex = 0;
                bListboxInit = false;

                if (File.Exists(folderName + "\\" + "sitemap.xml"))
                {
                    string[] lines = File.ReadAllLines(folderName + "\\" + "sitemap.xml");
                    this.tbSitemap.Lines = lines;
                }
                if (File.Exists(folderName + "\\" + "robots.txt"))
                {
                    string[] lines = File.ReadAllLines(folderName + "\\" + "robots.txt");
                    this.tbRobots.Lines = lines;
                }

                bRobotsModified = false;
                bSitemapModified = false;
            }
        }

        private void comFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bListboxInit) { return; }

            strFilename = (string)this.comFileList.SelectedItem;
            lines = File.ReadAllLines(folderName + "\\" + strFilename);
			int extraLines = 3;
            
			tbMetaDescription.SelectedText = "";
            tbMetaKeywords.SelectedText = "";
            tbTitle.SelectedText = "";
            iHeadLine = -1;
            iTitleLine = -1;
            iMetaDescriptionLine = -1;
            iMetaKeywordsLine = -1;
			
			for (int i=0;i<lines.Length;i++) {
                string line = lines[i];
				string linelc = line.ToLower();
				if (linelc.StartsWith("<title>") && linelc.EndsWith("</title>")) {
					tbTitle.SelectedText = line.Substring(7,line.Length-8-7);
					iTitleLine = i;
					extraLines--;
				}
				if (linelc.StartsWith("</head>")) {
					iHeadLine = i;
				}
				if (linelc.StartsWith("<meta name=\"keywords\"") || linelc.StartsWith("<meta name=keywords")) {
                    tbMetaKeywords.SelectedText = line;
                    iMetaKeywordsLine = i;
					extraLines--;
				}
				if (linelc.StartsWith("<meta name=\"description\"") || linelc.StartsWith("<meta name=description")) {
                    tbMetaDescription.SelectedText = line;
                    iMetaDescriptionLine = i;
					extraLines--;
				}
			}
			
			string[] newLines = new string[lines.Length + extraLines];
			
			if (iHeadLine != -1) {
				int j = 0;
				for (int i=0;i<iHeadLine;i++) {
					newLines[j++] = lines[i];
				}
				if (iTitleLine == -1) {
					iTitleLine = j;
					newLines[j++] = "<title></title>";
				}
                if (iMetaDescriptionLine == -1)
                {
                    iMetaDescriptionLine = j;
                    newLines[j++] = "<meta name=\"description\" content=\"\">";
                }
 				if (iMetaKeywordsLine == -1) {
					iMetaKeywordsLine = j;
					newLines[j++] = "<meta name=\"keywords\" content=\"\">";
				}
				for (int i=iHeadLine;i<lines.Length;i++) {
					newLines[j++] = lines[i];
				}
                File.WriteAllLines(folderName + "\\" + strFilename, newLines);
                lines = File.ReadAllLines(folderName + "\\" + strFilename);
			} else {
				MessageBox.Show("No <head> HTML tag");
				resetControls();
			}
       }

        private void btnSaveSitemapText_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(folderName + "\\" + "sitemap.xml",this.tbSitemap.Lines);
        }

        private void btnSaveRobotsText_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(folderName + "\\" + "robots.txt", this.tbRobots.Lines);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnSaveRobotsText.Enabled = false;
            this.btnSaveSitemapText.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.comFileList.Enabled = false;
            this.tbRobots.Enabled = false;
            this.tbSitemap.Enabled = false;
        }

        private void tbSitemap_TextChanged(object sender, EventArgs e)
        {
            bSitemapModified = true;
        }

        private void tbRobots_TextChanged(object sender, EventArgs e)
        {
            bRobotsModified = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bSitemapModified)
            {
                if (MessageBox.Show("Save sitemap.xml", appName, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question)
                       == System.Windows.Forms.DialogResult.Yes)
                { File.WriteAllLines(folderName + "\\" + "sitemap.xml", this.tbSitemap.Lines); }
            }
            if (bRobotsModified)
            {
                if (MessageBox.Show("Save robots.txt", appName, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question)
                       == System.Windows.Forms.DialogResult.Yes)
                { File.WriteAllLines(folderName + "\\" + "robots.txt", this.tbRobots.Lines); }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
			bFileModified = false;
            btnUpdate.Enabled = false;
			updateFile(strFilename);
        }

		private void updateFile(string filename) {
			lines[iTitleLine] = "<title>" + tbTitle.SelectedText + "<\title>";
			lines[iMetaKeywordsLine] = tbMetaKeywords.SelectedText;
			lines[iMetaDescriptionLine] = tbMetaDescription.SelectedText;
			File.WriteAllLines(folderName + "\\" + filename,lines);
		}
		
        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            fileDetailsChanged();
        }

        private void tbMetaKeywords_TextChanged(object sender, EventArgs e)
        {
            fileDetailsChanged();
        }

        private void tbMetaDescription_TextChanged(object sender, EventArgs e)
        {
            fileDetailsChanged();
        }

        private void fileDetailsChanged()
        {
            bFileModified = true;
            btnUpdate.Enabled = true;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();
        }
    }
}