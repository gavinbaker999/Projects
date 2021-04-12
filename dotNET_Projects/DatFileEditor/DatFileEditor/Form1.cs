using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace DatFileEditor
{
    public partial class Form1 : Form
    {
        const String appName = "DAT File Editor";

        private string    filenameDATFile,fileDATFile,pathDATFile;
        private int       current;
        private ArrayList elems;

        public Form1()
        {
            InitializeComponent();

            elems = new ArrayList();
            current = 1; // do not use image drectory name line
            filenameDATFile = "Untitled";
            fileDATFile = "Untitled";
            pathDATFile = "";

            save_file.Enabled = false;
            open_pic.Enabled = false;
            next_record.Enabled = false;
            last_record.Enabled = false;
            add_record.Enabled = false;
            delete_record.Enabled = false;
            description_text.Enabled = false;
            price_text.Enabled = false;
            sold_text.Enabled = false;
            thin_ratio_check.Enabled = false;

            display_stats();
        }

        private void display_stats()
        {
            this.Text = appName + " - " + fileDATFile;
            if (save_file.Enabled)
            {
                record_num_text.Text = current.ToString() + "/" + (elems.Count - 1).ToString();
            }
        }

        private void save_record()
        {
            string ratio = "0";
            if (thin_ratio_check.Checked) { ratio = "1"; }

            string tmp = picture_text.Text + ":" + ratio + ":" + description_text.Text + ":" + price_text.Text + ":" + sold_text.Text + ":";
            elems.RemoveAt(current);
            elems.Insert(current, tmp);
        }

        private void display_record() {
            string tmp = (string)elems[current];
            string[] seps = { ":" };
            string[] fields = tmp.Split(seps, System.StringSplitOptions.None);

            picture_text.Text = fields[0];
            if (fields[1] == "0") { thin_ratio_check.Checked = false; } else { thin_ratio_check.Checked = true; }
            description_text.Text = fields[2];
            price_text.Text = fields[3];
            sold_text.Text = fields[4];

            pictureBox1.ImageLocation = (String)elems[0] + "\\" + picture_text.Text;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            if (thin_ratio_check.Checked)
            {
                pictureBox1.Width = (int)(0.85 * (double)pictureBox1.Height);
            }
            else
            {
                pictureBox1.Width = (int)(1.36 * (double)pictureBox1.Height);
            }
            pictureBox1.Invalidate();
        }

        private void openFile() {
            elems.Clear();

            String[] lines = File.ReadAllLines(filenameDATFile);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length != 0) { elems.Add(lines[i]); }
            }

            save_file.Enabled = true;
            open_pic.Enabled = true;
            next_record.Enabled = true;
//          last_record.Enabled = true;
            add_record.Enabled = true;
            delete_record.Enabled = true;
            description_text.Enabled = true;
            price_text.Enabled = true;
            sold_text.Enabled = true;
            open_file.Enabled = false;
            thin_ratio_check.Enabled = true;

            display_stats();
            display_record();
        }

        private void saveFile()
        {
            save_record();
            int numRecs = elems.Count;
            String[] lines = new string[numRecs];
            for (int i = 0; i < numRecs; i++)
            {
                lines[i] = (String)elems[i];
            }
            File.WriteAllLines(filenameDATFile, lines);
            MessageBox.Show("File Saved");
        }

        private void open_file_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filenameDATFile = openFileDialog1.FileName;
                int index = filenameDATFile.LastIndexOf("\\");
                pathDATFile = filenameDATFile.Substring(0, index);
                fileDATFile = filenameDATFile.Substring(index + 1);
                System.IO.File.Copy(filenameDATFile, filenameDATFile + ".bak",true);
                openFile();
            }
        }

        private void save_file_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit " + appName,appName, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) 
                == System.Windows.Forms.DialogResult.Yes) {this.Close();}
        }

        private void open_pic_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = (String)elems[0];
            openFileDialog2.RestoreDirectory = true;
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string tmp = openFileDialog2.FileName;
                int index = tmp.LastIndexOf("\\");
                picture_text.Text = tmp.Substring(index + 1);

                String path = tmp.Substring(0,index);
                if (!path.EndsWith((String)elems[0])) 
                {
                    System.IO.File.Copy(tmp,pathDATFile + "\\"+ (String)elems[0] + "\\" + tmp.Substring(index + 1),true);
                }

                save_record();
                display_record();
            }
        }

        private void next_record_Click(object sender, EventArgs e)
        {
            save_record();
            if (++current == elems.Count - 1) {
                current = elems.Count - 1;
                next_record.Enabled = false;
            }
            last_record.Enabled = true;
            display_stats();
            display_record();
        }

        private void last_record_Click(object sender, EventArgs e)
        {
            save_record();
            if (--current <= 1) { 
                current = 1;
                last_record.Enabled = false;
            } // do not use image drectory name line
            next_record.Enabled = true;
            display_stats();
            display_record();
        }

        private void add_record_Click(object sender, EventArgs e)
        {
            picture_text.Text = "";
            description_text.Text = "";
            price_text.Text = "";
            sold_text.Text = "";
            thin_ratio_check.Checked = false;

            string tmp = picture_text.Text + ":0:" + description_text.Text + ":" + price_text.Text + ":" + sold_text.Text + ":";
            elems.Insert(current, tmp);

            display_stats();
            display_record();
        }

        private void delete_record_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete current record", appName, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                elems.RemoveAt(current);
                if (current == elems.Count) { current = elems.Count - 1; } // check for delete last record
                display_stats();
                display_record();
            }
        }

        private void aboutDATFileEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();
        }

        private void thin_ratio_check_CheckedChanged(object sender, EventArgs e)
        {
            if (thin_ratio_check.Checked) {
                pictureBox1.Width = (int)(0.85 * (double)pictureBox1.Height);
            } else {
                pictureBox1.Width = (int)(1.36 * (double)pictureBox1.Height);
            }
            pictureBox1.Invalidate();
        }

    }
}