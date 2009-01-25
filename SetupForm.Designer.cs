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
			this.buttonChooseEditor1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonUpdateContext = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageSetup = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBoxSendTo = new System.Windows.Forms.GroupBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonChooseEditor2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonCreateSendTo = new System.Windows.Forms.Button();
			this.groupBoxContext = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.buttonRemoveContext = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPageHelp = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.tabPageAbout = new System.Windows.Forms.TabPage();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPageSetup.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBoxSendTo.SuspendLayout();
			this.groupBoxContext.SuspendLayout();
			this.tabPageHelp.SuspendLayout();
			this.tabPageAbout.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Executables|*.exe";
			this.openFileDialog1.Title = "Choose your preferred text editor";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1FileOk);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 42);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(370, 20);
			this.textBox1.TabIndex = 0;
			// 
			// buttonChooseEditor1
			// 
			this.buttonChooseEditor1.Location = new System.Drawing.Point(384, 42);
			this.buttonChooseEditor1.Name = "buttonChooseEditor1";
			this.buttonChooseEditor1.Size = new System.Drawing.Size(28, 20);
			this.buttonChooseEditor1.TabIndex = 1;
			this.buttonChooseEditor1.Text = "...";
			this.buttonChooseEditor1.UseVisualStyleBackColor = true;
			this.buttonChooseEditor1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Choose your preferred text editor (.exe)";
			// 
			// buttonUpdateContext
			// 
			this.buttonUpdateContext.Location = new System.Drawing.Point(53, 162);
			this.buttonUpdateContext.Name = "buttonUpdateContext";
			this.buttonUpdateContext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.buttonUpdateContext.Size = new System.Drawing.Size(125, 23);
			this.buttonUpdateContext.TabIndex = 5;
			this.buttonUpdateContext.Text = "Create / Change";
			this.buttonUpdateContext.UseVisualStyleBackColor = true;
			this.buttonUpdateContext.Click += new System.EventHandler(this.Button2Click);
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
			this.tabControl1.Size = new System.Drawing.Size(446, 456);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPageSetup
			// 
			this.tabPageSetup.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tabPageSetup.Controls.Add(this.tableLayoutPanel1);
			this.tabPageSetup.Location = new System.Drawing.Point(4, 22);
			this.tabPageSetup.Name = "tabPageSetup";
			this.tabPageSetup.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSetup.Size = new System.Drawing.Size(438, 430);
			this.tabPageSetup.TabIndex = 0;
			this.tabPageSetup.Text = "Setup";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.groupBoxSendTo, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBoxContext, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(432, 424);
			this.tableLayoutPanel1.TabIndex = 12;
			// 
			// groupBoxSendTo
			// 
			this.groupBoxSendTo.Controls.Add(this.textBox4);
			this.groupBoxSendTo.Controls.Add(this.label6);
			this.groupBoxSendTo.Controls.Add(this.textBox3);
			this.groupBoxSendTo.Controls.Add(this.label5);
			this.groupBoxSendTo.Controls.Add(this.buttonChooseEditor2);
			this.groupBoxSendTo.Controls.Add(this.label3);
			this.groupBoxSendTo.Controls.Add(this.buttonCreateSendTo);
			this.groupBoxSendTo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxSendTo.Enabled = false;
			this.groupBoxSendTo.Location = new System.Drawing.Point(3, 215);
			this.groupBoxSendTo.Name = "groupBoxSendTo";
			this.groupBoxSendTo.Padding = new System.Windows.Forms.Padding(7);
			this.groupBoxSendTo.Size = new System.Drawing.Size(426, 206);
			this.groupBoxSendTo.TabIndex = 11;
			this.groupBoxSendTo.TabStop = false;
			this.groupBoxSendTo.Text = "SendTo Menu";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(10, 136);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(370, 20);
			this.textBox4.TabIndex = 8;
			this.textBox4.Text = "Rename Files with Fezzik";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(256, 23);
			this.label6.TabIndex = 9;
			this.label6.Text = "Choose the wording for your context menu item";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(10, 88);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(370, 20);
			this.textBox3.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(10, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(256, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "Choose your preferred text editor (.exe)";
			// 
			// buttonChooseEditor2
			// 
			this.buttonChooseEditor2.Location = new System.Drawing.Point(386, 88);
			this.buttonChooseEditor2.Name = "buttonChooseEditor2";
			this.buttonChooseEditor2.Size = new System.Drawing.Size(28, 20);
			this.buttonChooseEditor2.TabIndex = 5;
			this.buttonChooseEditor2.Text = "...";
			this.buttonChooseEditor2.UseVisualStyleBackColor = true;
			this.buttonChooseEditor2.Click += new System.EventHandler(this.ButtonChooseEditor2Click);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(7, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(412, 40);
			this.label3.TabIndex = 1;
			this.label3.Text = resources.GetString("label3.Text");
			// 
			// buttonCreateSendTo
			// 
			this.buttonCreateSendTo.Location = new System.Drawing.Point(49, 168);
			this.buttonCreateSendTo.Name = "buttonCreateSendTo";
			this.buttonCreateSendTo.Size = new System.Drawing.Size(125, 23);
			this.buttonCreateSendTo.TabIndex = 0;
			this.buttonCreateSendTo.Text = "Create SendTo Link";
			this.buttonCreateSendTo.UseVisualStyleBackColor = true;
			this.buttonCreateSendTo.Click += new System.EventHandler(this.ButtonCreateSendToClick);
			// 
			// groupBoxContext
			// 
			this.groupBoxContext.Controls.Add(this.textBox5);
			this.groupBoxContext.Controls.Add(this.label7);
			this.groupBoxContext.Controls.Add(this.textBox2);
			this.groupBoxContext.Controls.Add(this.textBox1);
			this.groupBoxContext.Controls.Add(this.buttonRemoveContext);
			this.groupBoxContext.Controls.Add(this.label4);
			this.groupBoxContext.Controls.Add(this.buttonUpdateContext);
			this.groupBoxContext.Controls.Add(this.label1);
			this.groupBoxContext.Controls.Add(this.buttonChooseEditor1);
			this.groupBoxContext.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxContext.Location = new System.Drawing.Point(3, 3);
			this.groupBoxContext.Name = "groupBoxContext";
			this.groupBoxContext.Size = new System.Drawing.Size(426, 206);
			this.groupBoxContext.TabIndex = 10;
			this.groupBoxContext.TabStop = false;
			this.groupBoxContext.Text = "Context Menu";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(7, 120);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(370, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "Rename Files with &Fezzik";
			// 
			// buttonRemoveContext
			// 
			this.buttonRemoveContext.Enabled = false;
			this.buttonRemoveContext.Location = new System.Drawing.Point(205, 162);
			this.buttonRemoveContext.Name = "buttonRemoveContext";
			this.buttonRemoveContext.Size = new System.Drawing.Size(125, 23);
			this.buttonRemoveContext.TabIndex = 8;
			this.buttonRemoveContext.Text = "Remove";
			this.buttonRemoveContext.UseVisualStyleBackColor = true;
			this.buttonRemoveContext.Click += new System.EventHandler(this.ButtonRemoveContextClick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(256, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Choose the wording for your context menu item";
			// 
			// tabPageHelp
			// 
			this.tabPageHelp.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tabPageHelp.Controls.Add(this.label2);
			this.tabPageHelp.Controls.Add(this.linkLabel1);
			this.tabPageHelp.Location = new System.Drawing.Point(4, 22);
			this.tabPageHelp.Name = "tabPageHelp";
			this.tabPageHelp.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHelp.Size = new System.Drawing.Size(438, 430);
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
			this.tabPageAbout.Size = new System.Drawing.Size(438, 430);
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
			this.richTextBox1.Size = new System.Drawing.Size(432, 424);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.Filter = "Executables|*.exe";
			this.openFileDialog2.Title = "Choose your preferred text editor";
			this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog2FileOk);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(8, 81);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(370, 20);
			this.textBox5.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 65);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(256, 23);
			this.label7.TabIndex = 10;
			this.label7.Text = "Command Line Options";
			// 
			// SetupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(446, 456);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.Name = "SetupForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Fezzik Setup";
			this.Load += new System.EventHandler(this.SetupFormLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPageSetup.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBoxSendTo.ResumeLayout(false);
			this.groupBoxSendTo.PerformLayout();
			this.groupBoxContext.ResumeLayout(false);
			this.groupBoxContext.PerformLayout();
			this.tabPageHelp.ResumeLayout(false);
			this.tabPageAbout.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button buttonChooseEditor1;
		private System.Windows.Forms.Button buttonChooseEditor2;
		private System.Windows.Forms.OpenFileDialog openFileDialog2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button buttonCreateSendTo;
		private System.Windows.Forms.Button buttonUpdateContext;
		private System.Windows.Forms.Button buttonRemoveContext;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBoxSendTo;
		private System.Windows.Forms.GroupBox groupBoxContext;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TabPage tabPageAbout;
		private System.Windows.Forms.TabPage tabPageHelp;
		private System.Windows.Forms.TabPage tabPageSetup;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		
	}
}
