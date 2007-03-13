/*
 * Fezzik - A text-editor based file renamer.
 * 
 * Cameron Coley - coleyc@gmail.com
 * 
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fezzik
{
	/// <summary>
	/// Description of ResultsForm.
	/// </summary>
	public partial class ResultsForm : Form
	{
		public ResultsForm(List<FezzikOp> ops, string dir)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			label1.Text += "  " + dir;
			
			System.Text.StringBuilder sblog = new System.Text.StringBuilder("File Renaming Audit Log for " + dir + "\n\n");
			
			//CJC There is some resize magic here, so bear with me.
			//CJC If anyone ever reads this and has a better way to do resize magic for listviews and their columns, let me know biguglyguy@gmail.com

			//CJC Store the Client Width of the empty listview
			int preclientwidth = listView1.ClientSize.Width;

			//CJC Resize the columns with HeaderSize to push them out to fill the listview perfectly while still empty.
			listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

			//CJC Store the difference between form width and sum of column widths
			int formcoloffset = this.Width - listView1.Columns[0].Width - listView1.Columns[1].Width;

			//CJC Add everything from the ops log to the list view
			foreach (FezzikOp fo in ops)
			{
				listView1.Items.Add(new ListViewItem(new string[2]{fo.oldfilename,fo.newfilename},(int)fo.type));
				// Add each item to log
				sblog.Append(fo.type.ToString() + " \"" + fo.oldfilename + "\" - \"" + fo.newfilename + "\"\n");
				
			}
			//CJC If nothing in ops, add a single info item.
			if (ops.Count == 0) {
				listView1.Items.Add(new ListViewItem("No changes made",(int)FezzikOpTypes.Info));
			}

			//CJC Resize the columns to content and then header width to flesh them out properly.
			listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

			//CJC Using the form/sum(col) diff, and the earlier measured clientwidth (to determine the presence of scrollbars), bust the form width out to perfect width.
			// TODO: There should be a limit on this, don't want the form going out to 4000 pixels or something like that.
			this.Width = listView1.Columns[0].Width + listView1.Columns[1].Width + formcoloffset + (preclientwidth - listView1.ClientSize.Width);

			System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog() ;
			appLog.Source = "Fezzik File Renamer";
			appLog.WriteEntry(sblog.ToString());
		}
		
		
		void ListView1ColumnClick(object sender, ColumnClickEventArgs e)
		{
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);			
		}
	}

	// Implements the manual sorting of items by columns.
    class ListViewItemComparer : System.Collections.IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
    }	
}
