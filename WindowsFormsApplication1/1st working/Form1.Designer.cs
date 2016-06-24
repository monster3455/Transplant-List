namespace WindowsFormsApplication1
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
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddGroupBox = new System.Windows.Forms.GroupBox();
            this.AMPMBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.MinuteBox = new System.Windows.Forms.TextBox();
            this.HourBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.YearBox = new System.Windows.Forms.TextBox();
            this.DayBox = new System.Windows.Forms.TextBox();
            this.MonthBox = new System.Windows.Forms.TextBox();
            this.OrganBox = new System.Windows.Forms.TextBox();
            this.BloodTypeBox = new System.Windows.Forms.TextBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintBox = new System.Windows.Forms.RichTextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.SearchNameButton = new System.Windows.Forms.Button();
            this.RecieveButton = new System.Windows.Forms.Button();
            this.SearchOrganButton = new System.Windows.Forms.Button();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.Location = new System.Drawing.Point(69, 19);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(152, 20);
            this.FirstNameBox.TabIndex = 1;
            this.FirstNameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(172, 362);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(75, 23);
            this.EnterButton.TabIndex = 3;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bloodtype";
            // 
            // AddGroupBox
            // 
            this.AddGroupBox.Controls.Add(this.AMPMBox);
            this.AddGroupBox.Controls.Add(this.label9);
            this.AddGroupBox.Controls.Add(this.MinuteBox);
            this.AddGroupBox.Controls.Add(this.HourBox);
            this.AddGroupBox.Controls.Add(this.label8);
            this.AddGroupBox.Controls.Add(this.label7);
            this.AddGroupBox.Controls.Add(this.YearBox);
            this.AddGroupBox.Controls.Add(this.DayBox);
            this.AddGroupBox.Controls.Add(this.MonthBox);
            this.AddGroupBox.Controls.Add(this.OrganBox);
            this.AddGroupBox.Controls.Add(this.BloodTypeBox);
            this.AddGroupBox.Controls.Add(this.LastNameBox);
            this.AddGroupBox.Controls.Add(this.label6);
            this.AddGroupBox.Controls.Add(this.label5);
            this.AddGroupBox.Controls.Add(this.label4);
            this.AddGroupBox.Controls.Add(this.label1);
            this.AddGroupBox.Controls.Add(this.label3);
            this.AddGroupBox.Controls.Add(this.FirstNameBox);
            this.AddGroupBox.Controls.Add(this.label2);
            this.AddGroupBox.Location = new System.Drawing.Point(12, 27);
            this.AddGroupBox.Name = "AddGroupBox";
            this.AddGroupBox.Size = new System.Drawing.Size(238, 188);
            this.AddGroupBox.TabIndex = 6;
            this.AddGroupBox.TabStop = false;
            // 
            // AMPMBox
            // 
            this.AMPMBox.FormattingEnabled = true;
            this.AMPMBox.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.AMPMBox.Location = new System.Drawing.Point(175, 150);
            this.AMPMBox.Name = "AMPMBox";
            this.AMPMBox.Size = new System.Drawing.Size(46, 21);
            this.AMPMBox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(104, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = ":";
            // 
            // MinuteBox
            // 
            this.MinuteBox.Location = new System.Drawing.Point(122, 151);
            this.MinuteBox.MaxLength = 2;
            this.MinuteBox.Name = "MinuteBox";
            this.MinuteBox.Size = new System.Drawing.Size(29, 20);
            this.MinuteBox.TabIndex = 18;
            this.MinuteBox.Text = "MM";
            this.MinuteBox.Click += new System.EventHandler(this.MinuteBox_Click);
            // 
            // HourBox
            // 
            this.HourBox.Location = new System.Drawing.Point(69, 151);
            this.HourBox.MaxLength = 2;
            this.HourBox.Name = "HourBox";
            this.HourBox.Size = new System.Drawing.Size(29, 20);
            this.HourBox.TabIndex = 17;
            this.HourBox.Text = "HH";
            this.HourBox.Click += new System.EventHandler(this.HourBox_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(157, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "/";
            // 
            // YearBox
            // 
            this.YearBox.Location = new System.Drawing.Point(175, 125);
            this.YearBox.MaxLength = 4;
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(46, 20);
            this.YearBox.TabIndex = 14;
            this.YearBox.Text = "YYYY";
            this.YearBox.Click += new System.EventHandler(this.YearBox_Click);
            // 
            // DayBox
            // 
            this.DayBox.Location = new System.Drawing.Point(122, 125);
            this.DayBox.MaxLength = 2;
            this.DayBox.Name = "DayBox";
            this.DayBox.Size = new System.Drawing.Size(29, 20);
            this.DayBox.TabIndex = 13;
            this.DayBox.Text = "DD";
            this.DayBox.Click += new System.EventHandler(this.DayBox_Click);
            // 
            // MonthBox
            // 
            this.MonthBox.Location = new System.Drawing.Point(69, 125);
            this.MonthBox.MaxLength = 2;
            this.MonthBox.Name = "MonthBox";
            this.MonthBox.Size = new System.Drawing.Size(29, 20);
            this.MonthBox.TabIndex = 12;
            this.MonthBox.Text = "MM";
            this.MonthBox.Click += new System.EventHandler(this.MonthBox_Click);
            // 
            // OrganBox
            // 
            this.OrganBox.Location = new System.Drawing.Point(69, 99);
            this.OrganBox.Name = "OrganBox";
            this.OrganBox.Size = new System.Drawing.Size(152, 20);
            this.OrganBox.TabIndex = 11;
            // 
            // BloodTypeBox
            // 
            this.BloodTypeBox.Location = new System.Drawing.Point(69, 71);
            this.BloodTypeBox.Name = "BloodTypeBox";
            this.BloodTypeBox.Size = new System.Drawing.Size(152, 20);
            this.BloodTypeBox.TabIndex = 10;
            // 
            // LastNameBox
            // 
            this.LastNameBox.Location = new System.Drawing.Point(69, 45);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(152, 20);
            this.LastNameBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Organ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(575, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // PrintBox
            // 
            this.PrintBox.Location = new System.Drawing.Point(257, 28);
            this.PrintBox.Name = "PrintBox";
            this.PrintBox.ReadOnly = true;
            this.PrintBox.Size = new System.Drawing.Size(306, 357);
            this.PrintBox.TabIndex = 8;
            this.PrintBox.Text = "";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 220);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(116, 23);
            this.AddButton.TabIndex = 9;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SearchNameButton
            // 
            this.SearchNameButton.Location = new System.Drawing.Point(12, 249);
            this.SearchNameButton.Name = "SearchNameButton";
            this.SearchNameButton.Size = new System.Drawing.Size(116, 23);
            this.SearchNameButton.TabIndex = 10;
            this.SearchNameButton.Text = "Search by Name";
            this.SearchNameButton.UseVisualStyleBackColor = true;
            this.SearchNameButton.Click += new System.EventHandler(this.SearchNameButton_Click);
            // 
            // RecieveButton
            // 
            this.RecieveButton.Location = new System.Drawing.Point(134, 220);
            this.RecieveButton.Name = "RecieveButton";
            this.RecieveButton.Size = new System.Drawing.Size(116, 23);
            this.RecieveButton.TabIndex = 11;
            this.RecieveButton.Text = "Recieve Patient";
            this.RecieveButton.UseVisualStyleBackColor = true;
            this.RecieveButton.Click += new System.EventHandler(this.RecieveButton_Click);
            // 
            // SearchOrganButton
            // 
            this.SearchOrganButton.Location = new System.Drawing.Point(12, 278);
            this.SearchOrganButton.Name = "SearchOrganButton";
            this.SearchOrganButton.Size = new System.Drawing.Size(116, 23);
            this.SearchOrganButton.TabIndex = 12;
            this.SearchOrganButton.Text = "Search by Organ";
            this.SearchOrganButton.UseVisualStyleBackColor = true;
            this.SearchOrganButton.Click += new System.EventHandler(this.SearchOrganButton_Click);
            // 
            // ModifyButton
            // 
            this.ModifyButton.Location = new System.Drawing.Point(134, 249);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(116, 23);
            this.ModifyButton.TabIndex = 13;
            this.ModifyButton.Text = "Modify";
            this.ModifyButton.UseVisualStyleBackColor = true;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(12, 362);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(75, 23);
            this.PrintButton.TabIndex = 14;
            this.PrintButton.Text = "View";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(134, 278);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(116, 23);
            this.DeleteButton.TabIndex = 15;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 397);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.ModifyButton);
            this.Controls.Add(this.SearchOrganButton);
            this.Controls.Add(this.RecieveButton);
            this.Controls.Add(this.SearchNameButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.PrintBox);
            this.Controls.Add(this.AddGroupBox);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form";
            this.AddGroupBox.ResumeLayout(false);
            this.AddGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox AddGroupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox MinuteBox;
        private System.Windows.Forms.TextBox HourBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox YearBox;
        private System.Windows.Forms.TextBox DayBox;
        private System.Windows.Forms.TextBox MonthBox;
        private System.Windows.Forms.TextBox OrganBox;
        private System.Windows.Forms.TextBox BloodTypeBox;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.RichTextBox PrintBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox AMPMBox;
        private System.Windows.Forms.Button SearchNameButton;
        private System.Windows.Forms.Button RecieveButton;
        private System.Windows.Forms.Button SearchOrganButton;
        private System.Windows.Forms.Button ModifyButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}

