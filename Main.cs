/*
 * Fezzik - A text-editor based file renamer.
 * 
 * Cameron Coley - coleyc@gmail.com
 * 
 */
 
using System;
using System.Collections.Generic;
using System.IO;
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

				ResultsForm rf = new ResultsForm(@"c:\fake\directory\testdata\");
				rf.DisplayOps(ops);
				Application.Run(rf);
			}
			else if (args.Length == 0) {
				Application.Run(new SetupForm());
			}
			else if (args.Length != 2 && args.Length != 3) {
				MessageBox.Show("Invalid Arguments. Arguments must consist of: Path to Text Editor Exe, Path to directory to rename, command line options to pass through to the text editor exe (optional).","Fezzik Error", MessageBoxButtons.OK);
				Application.Exit();
			} else {
				
				// Create DirectoryInfo object and check that directory exists
				DirectoryInfo di = new DirectoryInfo(args[1]);
				if (!di.Exists)
				{
					MessageBox.Show("ERROR: Specified directory does not exist");
					Application.Exit();
				}				
				
				ResultsForm rf = new ResultsForm(di.FullName);
				rf.FezzikDirectory(args[0],args[2],di);

				Application.Run(rf);
				//List<FezzikOp> ops = ProcessChanges(origfiles,newfilenames,di.FullName, true);
				
				//rf.DisplayOps(ops);
				//Application.Run(rf);
			}
		}
		
		

		
	}
}
