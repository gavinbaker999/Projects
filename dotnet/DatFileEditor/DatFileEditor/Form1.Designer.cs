namespace DatFileEditor
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.open_file = new System.Windows.Forms.Button();
            this.save_file = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.description_text = new System.Windows.Forms.TextBox();
            this.price_text = new System.Windows.Forms.TextBox();
            this.sold_text = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.open_pic = new System.Windows.Forms.Button();
            this.next_record = new System.Windows.Forms.Button();
            this.last_record = new System.Windows.Forms.Button();
            this.add_record = new System.Windows.Forms.Button();
            this.delete_record = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutDATFileEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picture_text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.record_num_text = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.thin_ratio_check = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "DAT";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "DAT Files|*.dat";
            // 
            // open_file
            // 
            this.open_file.Location = new System.Drawing.Point(41, 38);
            this.open_file.Name = "open_file";
            this.open_file.Size = new System.Drawing.Size(75, 23);
            this.open_file.TabIndex = 0;
            this.open_file.Text = "Open";
            this.open_file.UseVisualStyleBackColor = true;
            this.open_file.Click += new System.EventHandler(this.open_file_Click);
            // 
            // save_file
            // 
            this.save_file.Location = new System.Drawing.Point(147, 38);
            this.save_file.Name = "save_file";
            this.save_file.Size = new System.Drawing.Size(75, 23);
            this.save_file.TabIndex = 1;
            this.save_file.Text = "Save";
            this.save_file.UseVisualStyleBackColor = true;
            this.save_file.Click += new System.EventHandler(this.save_file_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(260, 38);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 2;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sold:";
            // 
            // description_text
            // 
            this.description_text.Location = new System.Drawing.Point(105, 108);
            this.description_text.Name = "description_text";
            this.description_text.Size = new System.Drawing.Size(188, 20);
            this.description_text.TabIndex = 6;
            // 
            // price_text
            // 
            this.price_text.Location = new System.Drawing.Point(105, 131);
            this.price_text.Name = "price_text";
            this.price_text.Size = new System.Drawing.Size(77, 20);
            this.price_text.TabIndex = 7;
            // 
            // sold_text
            // 
            this.sold_text.Location = new System.Drawing.Point(105, 155);
            this.sold_text.Name = "sold_text";
            this.sold_text.Size = new System.Drawing.Size(188, 20);
            this.sold_text.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(341, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 104);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.DefaultExt = "JPG";
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "JPG Files|*.jpg";
            // 
            // open_pic
            // 
            this.open_pic.Location = new System.Drawing.Point(311, 79);
            this.open_pic.Name = "open_pic";
            this.open_pic.Size = new System.Drawing.Size(75, 23);
            this.open_pic.TabIndex = 10;
            this.open_pic.Text = "Get Picture";
            this.open_pic.UseVisualStyleBackColor = true;
            this.open_pic.Click += new System.EventHandler(this.open_pic_Click);
            // 
            // next_record
            // 
            this.next_record.Location = new System.Drawing.Point(41, 220);
            this.next_record.Name = "next_record";
            this.next_record.Size = new System.Drawing.Size(75, 23);
            this.next_record.TabIndex = 11;
            this.next_record.Text = "Next Record";
            this.next_record.UseVisualStyleBackColor = true;
            this.next_record.Click += new System.EventHandler(this.next_record_Click);
            // 
            // last_record
            // 
            this.last_record.Location = new System.Drawing.Point(122, 220);
            this.last_record.Name = "last_record";
            this.last_record.Size = new System.Drawing.Size(102, 23);
            this.last_record.TabIndex = 12;
            this.last_record.Text = "Previous Record";
            this.last_record.UseVisualStyleBackColor = true;
            this.last_record.Click += new System.EventHandler(this.last_record_Click);
            // 
            // add_record
            // 
            this.add_record.Location = new System.Drawing.Point(230, 220);
            this.add_record.Name = "add_record";
            this.add_record.Size = new System.Drawing.Size(75, 23);
            this.add_record.TabIndex = 13;
            this.add_record.Text = "Add Record";
            this.add_record.UseVisualStyleBackColor = true;
            this.add_record.Click += new System.EventHandler(this.add_record_Click);
            // 
            // delete_record
            // 
            this.delete_record.Location = new System.Drawing.Point(311, 220);
            this.delete_record.Name = "delete_record";
            this.delete_record.Size = new System.Drawing.Size(88, 23);
            this.delete_record.TabIndex = 14;
            this.delete_record.Text = "Delete Record";
            this.delete_record.UseVisualStyleBackColor = true;
            this.delete_record.Click += new System.EventHandler(this.delete_record_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(539, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutDATFileEditorToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutDATFileEditorToolStripMenuItem
            // 
            this.aboutDATFileEditorToolStripMenuItem.Name = "aboutDATFileEditorToolStripMenuItem";
            this.aboutDATFileEditorToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.aboutDATFileEditorToolStripMenuItem.Text = "About DAT File Editor";
            this.aboutDATFileEditorToolStripMenuItem.Click += new System.EventHandler(this.aboutDATFileEditorToolStripMenuItem_Click);
            // 
            // picture_text
            // 
            this.picture_text.Location = new System.Drawing.Point(105, 181);
            this.picture_text.Name = "picture_text";
            this.picture_text.ReadOnly = true;
            this.picture_text.Size = new System.Drawing.Size(188, 20);
            this.picture_text.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Picture:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Records:";
            // 
            // record_num_text
            // 
            this.record_num_text.Location = new System.Drawing.Point(421, 40);
            this.record_num_text.Name = "record_num_text";
            this.record_num_text.ReadOnly = true;
            this.record_num_text.Size = new System.Drawing.Size(38, 20);
            this.record_num_text.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "€ will be added to end of price";
            // 
            // thin_ratio_check
            // 
            this.thin_ratio_check.AutoSize = true;
            this.thin_ratio_check.Location = new System.Drawing.Point(392, 79);
            this.thin_ratio_check.Name = "thin_ratio_check";
            this.thin_ratio_check.Size = new System.Drawing.Size(75, 17);
            this.thin_ratio_check.TabIndex = 21;
            this.thin_ratio_check.Text = "Thin Ratio";
            this.thin_ratio_check.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thin_ratio_check.UseVisualStyleBackColor = true;
            this.thin_ratio_check.CheckedChanged += new System.EventHandler(this.thin_ratio_check_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 255);
            this.Controls.Add(this.thin_ratio_check);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.record_num_text);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picture_text);
            this.Controls.Add(this.delete_record);
            this.Controls.Add(this.add_record);
            this.Controls.Add(this.last_record);
            this.Controls.Add(this.next_record);
            this.Controls.Add(this.open_pic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sold_text);
            this.Controls.Add(this.price_text);
            this.Controls.Add(this.description_text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.save_file);
            this.Controls.Add(this.open_file);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DAT File Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button open_file;
        private System.Windows.Forms.Button save_file;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox description_text;
        private System.Windows.Forms.TextBox price_text;
        private System.Windows.Forms.TextBox sold_text;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button open_pic;
        private System.Windows.Forms.Button next_record;
        private System.Windows.Forms.Button last_record;
        private System.Windows.Forms.Button add_record;
        private System.Windows.Forms.Button delete_record;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutDATFileEditorToolStripMenuItem;
        private System.Windows.Forms.TextBox picture_text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox record_num_text;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox thin_ratio_check;
    }
}

