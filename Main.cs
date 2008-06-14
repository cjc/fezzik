/*
 * Fezzik - A text-editor based file renamer.
 * 
 * Cameron Coley - coleyc@gmail.com
 * 
 */
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Fezzik
{
	public enum FezzikOpTypes
	{
		Rename = 0,
		Delete = 1,
		Info = 2,
		Error = 3
	}

	public struct FezzikOp {
		public string oldfilename;
		public string newfilename;
		public FezzikOpTypes type;
		public FezzikOp (string ofn, string nfn, FezzikOpTypes type)
		{
			oldfilename = ofn;
			newfilename = nfn;
			this.type = type;
		}
	}

	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			FileInfo indexfile;
			FileSystemInfo[] origfiles;
			List<string> newfilenames = new List<string>();
			//FileSystemWatcher fsw;

			if ((args.Length == 1) && (args[0] == "/testresultsform"))
			{
				List<FezzikOp> ops = new List<FezzikOp>();
				ops.Add(new FezzikOp("Van Diemen's Land","Tasmania",FezzikOpTypes.Rename));
				ops.Add(new FezzikOp("Sumer","",FezzikOpTypes.Delete));
				ops.Add(new FezzikOp("Atlantis","",FezzikOpTypes.Delete));
				ops.Add(new FezzikOp("Constantinople","Istanbul",FezzikOpTypes.Rename));
				ops.Add(new FezzikOp("Formosa","Taiwan",FezzikOpTypes.Rename));
				ops.Add(new FezzikOp(String.Format("Delete \"{0}\" failed","Iraq"),"",FezzikOpTypes.Error));
				ops.Add(new FezzikOp("Tarquin Fin-tim-lin-bin-whin-bim-lim-bus-stop-F'tang-F'tang-Olé-Biscuitbarrel","Jethro Q. Walrustitty",FezzikOpTypes.Rename));

				Application.Run(new ResultsForm(ops,@"c:\fake\directory\testdata\"));
			}
			else if (args.Length == 0) {
				Application.Run(new SetupForm());
			}
			else if (args.Length != 2) {
				MessageBox.Show("Invalid Arguments. Arguments must consist of: Path to Text Editor Exe, Path to directory to rename.","Fezzik Error", MessageBoxButtons.OK);
				Application.Exit();
			} else {
				// Create DirectoryInfo object and check that directory exists
				DirectoryInfo di = new DirectoryInfo(args[1]);
				if (!di.Exists)
				{
					MessageBox.Show("ERROR: Specified directory does not exist");
					Application.Exit();
				}

				//Obtain and open a temp file. Write all the filenames into the temp file
				indexfile = new FileInfo(Path.GetTempFileName());

				TextWriter tw = new StreamWriter(indexfile.FullName);

				origfiles = di.GetFileSystemInfos();
				foreach(FileSystemInfo fsi in origfiles)
				{
					if (fsi.GetType() == typeof(FileInfo))
					{
						tw.WriteLine(fsi.Name);
					} 
					else if (fsi.GetType() == typeof(DirectoryInfo))
					{
						tw.WriteLine(fsi.Name + "\\");
					}
				}
				tw.Close();

				//Create FileSytemWatcher to monitor the temp indexfile.
				//fsw = new FileSystemWatcher(indexfile.Directory.FullName,indexfile.Name);
				//fsw.NotifyFilter = NotifyFilters.LastWrite;
				//fsw.Changed += new FileSystemEventHandler(OnChanged);
				//fsw.EnableRaisingEvents = true;

				Process p = Process.Start(args[0],"\"" + indexfile.FullName + "\"");
				p.WaitForInputIdle();
				p.WaitForExit();

				TextReader tr = new StreamReader(indexfile.FullName);
				while(tr.Peek() != -1)
				{
					newfilenames.Add(tr.ReadLine());
				}
				tr.Close();
				if (origfiles.Length != newfilenames.Count) 
				{
					MessageBox.Show(String.Format("ERROR: Length mismatch. {0} files in source, {1} filenames in modified index", origfiles.Length, newfilenames.Count),"Fezzik Error", MessageBoxButtons.OK);
					Application.Exit();
				}
				else
				{
					List<FezzikOp> ops = new List<FezzikOp>();
					// Iterate over files, check whether they should be left, renamed or deleted.
					for (int i=0; i< origfiles.Length;i++)
					{
						if ((origfiles[i].Name.Equals(newfilenames[i])) || ((newfilenames[i].Equals(origfiles[i].Name + "\\")) && (origfiles[i].GetType() == typeof(DirectoryInfo))))
						{
							// Don't rename if unchanged
						}
						else if (newfilenames[i].Equals("?"))
						{
							// Don't rename if new name is "?"
						}
						else if (newfilenames[i].Equals(""))
						{
							// Delete file if line has been left blank. Seek confirmation?
							try
							{
								if (MessageBox.Show(String.Format("Delete \"{0}\"?",origfiles[i].Name),"Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes )
								{
									origfiles[i].Delete();
									ops.Add(new FezzikOp(origfiles[i].Name,"",FezzikOpTypes.Delete));
								} else {

									 ops.Add(new FezzikOp(String.Format("Delete \"{0}\" failed",origfiles[i].Name),"",FezzikOpTypes.Delete));
								}
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
								if (origfiles[i].GetType() == typeof(FileInfo))
								{
									((FileInfo)origfiles[i]).MoveTo(((FileInfo)origfiles[i]).Directory.FullName + "\\" + newfilenames[i]);
								} else if (origfiles[i].GetType() == typeof(DirectoryInfo))
								{
									((DirectoryInfo)origfiles[i]).MoveTo(((DirectoryInfo)origfiles[i]).Parent.FullName + "\\" + newfilenames[i]);
								}
								ops.Add(new FezzikOp(oldname,newfilenames[i],FezzikOpTypes.Rename));
							}
							catch (IOException ioe)
							{
								MessageBox.Show(String.Format("Error renaming \"{0}\" to \"{1}\". " + ioe.Message,origfiles[i].Name,newfilenames[i]),"Fezzik Error", MessageBoxButtons.OK);
								ops.Add(new FezzikOp(String.Format("Rename \"{0}\" failed",origfiles[i].Name),"",FezzikOpTypes.Error));
							}
						}
					}
					Application.Run(new ResultsForm(ops,di.FullName));
				}
			}
		}
	}
}
