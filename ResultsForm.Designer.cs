/*
 * Fezzik - A text-editor based file renamer.
 * 
 * Cameron Coley - coleyc@gmail.com
 * 
 */
namespace Fezzik
{
	partial class ResultsForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsForm));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.completedPanel = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.previewPanel = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.completedPanel.SuspendLayout();
			this.previewPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "arrow_switch.png");
			this.imageList1.Images.SetKeyName(1, "delete.png");
			this.imageList1.Images.SetKeyName(2, "information.png");
			this.imageList1.Images.SetKeyName(3, "error.png");
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(0, 17);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(306, 353);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 3;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView1ColumnClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Original File";
			this.columnHeader1.Width = 150;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "New Filename";
			this.columnHeader2.Width = 150;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(306, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Results for";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1RunWorkerCompleted);
			// 
			// timer1
			// 
			this.timer1.Interval = 200;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// completedPanel
			// 
			this.completedPanel.Controls.Add(this.label3);
			this.completedPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.completedPanel.Location = new System.Drawing.Point(0, 336);
			this.completedPanel.Name = "completedPanel";
			this.completedPanel.Size = new System.Drawing.Size(306, 34);
			this.completedPanel.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(23, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(190, 28);
			this.label3.TabIndex = 2;
			this.label3.Text = "Changes Made";
			// 
			// previewPanel
			// 
			this.previewPanel.Controls.Add(this.label2);
			this.previewPanel.Controls.Add(this.cancelButton);
			this.previewPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.previewPanel.Location = new System.Drawing.Point(0, 301);
			this.previewPanel.Name = "previewPanel";
			this.previewPanel.Size = new System.Drawing.Size(306, 35);
			this.previewPanel.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(23, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(190, 28);
			this.label2.TabIndex = 1;
			this.label2.Text = "Changes Preview";
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(219, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// ResultsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(306, 370);
			this.Controls.Add(this.previewPanel);
			this.Controls.Add(this.completedPanel);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.label1);
			this.Name = "ResultsForm";
			this.Text = "Fezzik Results";
			this.completedPanel.ResumeLayout(false);
			this.previewPanel.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel previewPanel;
		private System.Windows.Forms.Panel completedPanel;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ImageList imageList1;
		
	}
}
