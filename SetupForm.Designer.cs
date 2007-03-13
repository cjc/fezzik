/*
 * Fezzik - A text-editor based file renamer.
 * 
 * Cameron Coley - coleyc@gmail.com
 * 
 */

namespace Fezzik
{
	partial class SetupForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageSetup = new System.Windows.Forms.TabPage();
			this.button3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.tabPageHelp = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.tabPageAbout = new System.Windows.Forms.TabPage();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.tabControl1.SuspendLayout();
			this.tabPageSetup.SuspendLayout();
			this.tabPageHelp.SuspendLayout();
			this.tabPageAbout.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Executables|*.exe";
			this.openFileDialog1.Title = "Choose your preferred text editor";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1FileOk);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(370, 20);
			this.textBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(384, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(28, 20);
			this.button1.TabIndex = 1;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Choose your preferred text editor (.exe)";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(107, 157);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(107, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Create Link";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageSetup);
			this.tabControl1.Controls.Add(this.tabPageHelp);
			this.tabControl1.Controls.Add(this.tabPageAbout);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(540, 360);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPageSetup
			// 
			this.tabPageSetup.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tabPageSetup.Controls.Add(this.button3);
			this.tabPageSetup.Controls.Add(this.label3);
			this.tabPageSetup.Controls.Add(this.radioButton2);
			this.tabPageSetup.Controls.Add(this.radioButton1);
			this.tabPageSetup.Controls.Add(this.label1);
			this.tabPageSetup.Controls.Add(this.textBox1);
			this.tabPageSetup.Controls.Add(this.button1);
			this.tabPageSetup.Controls.Add(this.button2);
			this.tabPageSetup.Location = new System.Drawing.Point(4, 22);
			this.tabPageSetup.Name = "tabPageSetup";
			this.tabPageSetup.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSetup.Size = new System.Drawing.Size(532, 334);
			this.tabPageSetup.TabIndex = 0;
			this.tabPageSetup.Text = "Setup";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(235, 157);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(107, 23);
			this.button3.TabIndex = 9;
			this.button3.Text = "Remove Link";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(256, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Where would you like the link created?";
			// 
			// radioButton2
			// 
			this.radioButton2.Enabled = false;
			this.radioButton2.Location = new System.Drawing.Point(30, 127);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(434, 24);
			this.radioButton2.TabIndex = 7;
			this.radioButton2.Text = "SendTo Menu (Temporarily unavailble pending third party code use permission)";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(30, 107);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(434, 24);
			this.radioButton1.TabIndex = 6;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Folder Context Menu";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// tabPageHelp
			// 
			this.tabPageHelp.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tabPageHelp.Controls.Add(this.label2);
			this.tabPageHelp.Controls.Add(this.linkLabel1);
			this.tabPageHelp.Location = new System.Drawing.Point(4, 22);
			this.tabPageHelp.Name = "tabPageHelp";
			this.tabPageHelp.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHelp.Size = new System.Drawing.Size(532, 312);
			this.tabPageHelp.TabIndex = 1;
			this.tabPageHelp.Text = "Help";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(258, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Brief builtin help pending";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(17, 19);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(438, 23);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://code.google.com/p/fezzik/wiki/BasicUsage";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
			// 
			// tabPageAbout
			// 
			this.tabPageAbout.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tabPageAbout.Controls.Add(this.richTextBox1);
			this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
			this.tabPageAbout.Name = "tabPageAbout";
			this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAbout.Size = new System.Drawing.Size(532, 312);
			this.tabPageAbout.TabIndex = 2;
			this.tabPageAbout.Text = "About";
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new System.Drawing.Point(3, 3);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(526, 306);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// SetupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(540, 360);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.Name = "SetupForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Fezzik Setup";
			this.tabControl1.ResumeLayout(false);
			this.tabPageSetup.ResumeLayout(false);
			this.tabPageSetup.PerformLayout();
			this.tabPageHelp.ResumeLayout(false);
			this.tabPageAbout.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TabPage tabPageAbout;
		private System.Windows.Forms.TabPage tabPageHelp;
		private System.Windows.Forms.TabPage tabPageSetup;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}
