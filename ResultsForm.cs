/*
 * Fezzik - A text-editor based file renamer.
 * 
 * Cameron Coley - coleyc@gmail.com
 * 
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Fezzik
{
	
	/// <summary>
	/// Description of ResultsForm.
	/// </summary>
	public partial class ResultsForm : Form
	{
		private string dirname;
		private FileSystemInfo[] origfiles;	
		private FileInfo indexfile;

        private int FezzikWindowWidth = 450;

		public ResultsForm(string dir)
		{
			InitializeComponent();
			dirname = dir;
			// FIXME: completedPanel.Visible = false;
			DisplayOps(new List<FezzikOp>());
		}
		
		public void FezzikDirectory(string editor, string arguments, DirectoryInfo di)
		{

			//Obtain and open a temp file. Write all the filenames into the temp file
			indexfile = new FileInfo(Path.GetTempFileName());

            this.DesktopLocation = new Point(0,0);
            this.Width = FezzikWindowWidth;
            this.Height = Screen.GetWorkingArea(this).Height;

			TextWriter tw = new StreamWriter(indexfile.FullName);

			origfiles = di.GetFileSystemInfos();
			bool firstline = true;
			foreach(FileSystemInfo fsi in origfiles)
			{
				if (!firstline) tw.Write(tw.NewLine);
				if (fsi.GetType() == typeof(FileInfo))
				{
					tw.Write(fsi.Name);
				} 
				else if (fsi.GetType() == typeof(DirectoryInfo))
				{
					tw.Write(fsi.Name + "\\");
				}
				firstline = false;
			}
			tw.Close();

			//Create FileSytemWatcher to monitor the temp indexfile.
			FileSystemWatcher fsw = new FileSystemWatcher(indexfile.Directory.FullName,indexfile.Name);
			fsw.NotifyFilter = NotifyFilters.LastWrite;
			fsw.Changed += new FileSystemEventHandler(OnChanged);
			fsw.EnableRaisingEvents = true;

			string argline = arguments + " \"" + indexfile.FullName + "\"";

			backgroundWorker1.RunWorkerAsync(new WorkerArgs(editor, argline));
			
		}
		
		public void DisplayOps(List<FezzikOp> ops) 
		{
			label1.Text = "Results for  " + dirname;
			
			listView1.Items.Clear();
			
			// There is some resize magic here, so bear with me.
			// If anyone ever reads this and has a better way to do resize magic for listviews and their columns, let me know coleyc@gmail.com

			// Store the Client Width of the empty listview
			int preclientwidth = listView1.ClientSize.Width;

			// Resize the columns with HeaderSize to push them out to fill the listview perfectly while still empty.
			listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

			// Store the difference between form width and sum of column widths
			int formcoloffset = this.Width - listView1.Columns[0].Width - listView1.Columns[1].Width;

			// Add everything from the ops log to the list view
			foreach (FezzikOp fo in ops)
			{
				listView1.Items.Add(new ListViewItem(new string[2]{fo.oldfilename,fo.newfilename},(int)fo.type));
			}
			// If nothing in ops, add a single info item.
			if (ops.Count == 0) {
				listView1.Items.Add(new ListViewItem("No changes made",(int)FezzikOpTypes.Info));
			}

			// Resize the columns to content and then header width to flesh them out properly.
			listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

			// Using the form/sum(col) diff, and the earlier measured clientwidth (to determine the presence of scrollbars), bust the form width out to perfect width.
			// TODO: There should be a limit on this, don't want the form going out to 4000 pixels or something like that.
			this.Width = listView1.Columns[0].Width + listView1.Columns[1].Width + formcoloffset + (preclientwidth - listView1.ClientSize.Width);
		}
		
	    private List<FezzikOp> ProcessChanges(FileSystemInfo[] originalFiles, List<string> newfilenames, string dir, bool commit)
	    {
			List<FezzikOp> ops = new List<FezzikOp>();
			System.Text.StringBuilder sblog = new System.Text.StringBuilder("File Renaming Audit Log for " + dir + "\n\n");
	    	
	    	if (origfiles.Length != newfilenames.Count)
			{
				ops.Add(new FezzikOp(String.Format("Length mismatch. {0} files in source, {1} filenames in modified index", origfiles.Length, newfilenames.Count),"",FezzikOpTypes.Error));
			}
			else
			{
				// Iterate over files, check whether they should be left, renamed or deleted.
				for (int i=0; i< origfiles.Length;i++)
				{
					if ((origfiles[i].Name.Equals(newfilenames[i])) || ((newfilenames[i].Equals(origfiles[i].Name + "\\")) && (origfiles[i].GetType() == typeof(DirectoryInfo))))
					{
						// Don't rename if unchanged
                        ops.Add(new FezzikOp(origfiles[i].Name,"", FezzikOpTypes.Info));
					}
					else if (newfilenames[i].Equals("?"))
					{
						// Don't rename if new name is "?"
                        ops.Add(new FezzikOp(origfiles[i].Name, "", FezzikOpTypes.Info));
					}
					else if (newfilenames[i].Equals(""))
					{
						// Delete file if line has been left blank.
						try
						{
							if (commit)
							{
								origfiles[i].Delete();
							}
							ops.Add(new FezzikOp(origfiles[i].Name,"",FezzikOpTypes.Delete));

							sblog.Append(FezzikOpTypes.Delete.ToString() + " \"" + origfiles[i].Name + "\"\n");
						}
						catch (IOException ioe)
						{
							MessageBox.Show(String.Format("Error deleting \"{0}\". " + ioe.Message,origfiles[i].Name),"Fezzik Error", MessageBoxButtons.OK);
							ops.Add(new FezzikOp(String.Format("Delete \"{0}\" failed",origfiles[i].Name),"",FezzikOpTypes.Error));
						}
					}
					else
					{
						try
						{
							string oldname = origfiles[i].Name;
							if (commit)
							{
								if (origfiles[i].GetType() == typeof(FileInfo))
								{
									((FileInfo)origfiles[i]).MoveTo(((FileInfo)origfiles[i]).Directory.FullName + "\\" + newfilenames[i]);
								} else if (origfiles[i].GetType() == typeof(DirectoryInfo))
								{
									((DirectoryInfo)origfiles[i]).MoveTo(((DirectoryInfo)origfiles[i]).Parent.FullName + "\\" + newfilenames[i]);
								}
							}
							ops.Add(new FezzikOp(oldname,newfilenames[i],FezzikOpTypes.Rename));
							sblog.Append(FezzikOpTypes.Rename.ToString() + " \"" + oldname + "\" - \"" + newfilenames[i] + "\"\n");
						}
						catch (IOException ioe)
						{
							MessageBox.Show(String.Format("Error renaming \"{0}\" to \"{1}\". " + ioe.Message,origfiles[i].Name,newfilenames[i]),"Fezzik Error", MessageBoxButtons.OK);
							ops.Add(new FezzikOp(String.Format("Rename \"{0}\" failed",origfiles[i].Name),"",FezzikOpTypes.Error));
						}
					}
				}
			}
	    	
			if (commit)
			{
				System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog() ;
				appLog.Source = "Fezzik File Renamer";
				appLog.WriteEntry(sblog.ToString());
			}
			
	    	return ops;
	    }		
		
	    private void OnChanged(object source, FileSystemEventArgs e)
	    {
	    	lock(timer1)
	    	{
			   if (this.InvokeRequired)
			   {
			      this.BeginInvoke(new MethodInvoker(delegate()
			      {
                   	timer1.Stop();
    				timer1.Enabled = true;
    				timer1.Start();
			      }));
			   }
	    	}
	    }
	    
		void ListView1ColumnClick(object sender, ColumnClickEventArgs e)
		{
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);			
		}
		
		
		void BackgroundWorker1DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			WorkerArgs wa = (WorkerArgs)e.Argument;
			Process p = Process.Start(wa.Editor,wa.Args);
			p.WaitForInputIdle();
            ResizeMainWindow(p);
			p.WaitForExit();			
		}
		
		void BackgroundWorker1RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			List<string> newfilenames = new List<string>();

			TextReader tr = new StreamReader(indexfile.FullName);
			while(tr.Peek() != -1)
			{
				newfilenames.Add(tr.ReadLine());
			}
			tr.Close();
			
			List<FezzikOp> ops = ProcessChanges(origfiles,newfilenames, "", true);
			this.DisplayOps(ops);
            //FIXME:
            //previewPanel.Visible = false;
            //completedPanel.Visible = true;
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			List<string> newfilenames = new List<string>();
			try {
				// Specify what is done when a file is changed, created, or deleted.
				TextReader tr = new StreamReader(indexfile.FullName);
				while(tr.Peek() != -1)
				{
					newfilenames.Add(tr.ReadLine());
				}
				tr.Close();
				// Read was successful, disable timer.
				timer1.Enabled = false;
				
				List<FezzikOp> ops = ProcessChanges(origfiles,newfilenames, "", false);
				this.DisplayOps(ops);
			}
			catch (System.IO.IOException)
			{
				// An IOException here probably means the text editor is still writing the file, try again at next tick.
	    		timer1.Enabled = true;
	    		timer1.Interval = 200;
			}
		}
		
		
		void CancelButtonClick(object sender, EventArgs e)
		{
			Application.Exit();
		}

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
            int x, int y, int width, int height, uint uFlags);

        private const uint SHOWWINDOW = 0x0040;

        private void ResizeMainWindow(System.Diagnostics.Process process)
        {
            if (process != null)
            {
                SetWindowPos(process.MainWindowHandle, this.Handle,
                    FezzikWindowWidth, 0, Screen.GetWorkingArea(this).Width - FezzikWindowWidth,
                    Screen.GetWorkingArea(this).Height, SHOWWINDOW);
            }
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

	class WorkerArgs
	{
		public WorkerArgs(string editor, string args)
		{
			Editor = editor;
			Args = args;
		}
		public string Editor;
		public string Args;
	}
	
    
}
