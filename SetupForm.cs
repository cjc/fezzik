/*
 * Fezzik - A text-editor based file renamer.
 * 
 * Cameron Coley - coleyc@gmail.com
 * 
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Security.Permissions;

namespace Fezzik
{
	/// <summary>
	/// Description of SetupForm.
	/// </summary>
	public partial class SetupForm : Form
	{
		public SetupForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			richTextBox1.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\deflang3081{\fonttbl{\f0\fswiss\fprq2\fcharset0 Century Gothic;}{\f1\fswiss\fcharset0 Arial;}}
{\colortbl ;\red0\green0\blue0;}
{\*\generator Msftedit 5.41.15.1507;}\viewkind4\uc1\pard\qc\cf1\f0\fs72 Fezzik\cf0\f1\fs20\par
\fs16 A text editor based file renamer\par
http://code.google.com/p/fezzik\par
\pard\par
\b\fs18 Silk - \b0 http://www.famfamfam.com/lab/icons/silk/\b\par
\b0\par
This program uses selected icons from the excellent Silk set by Mark James.\par
}
";
		}

		void Button1Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
		}
		
		void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			textBox1.Text = openFileDialog1.FileName;
		}

		void Button2Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "")
			{
				MessageBox.Show("Please select your text editor","Fezzik",MessageBoxButtons.OK);
			}
			else
			{
				try {
					FileInfo fi = new FileInfo(textBox1.Text);
					if (!fi.Exists) {throw new IOException("File does not exist");}
				}
				catch (IOException ioe)
				{
					MessageBox.Show(ioe.Message,"File Error", MessageBoxButtons.OK);
					Application.Exit();
				}

				// Add Context Menu
				AddContextMenuItem("FezzikFileRenamer", textBox2.Text , Application.ExecutablePath + " \"" + textBox1.Text + "\" \"%1\" \"" + textBox5.Text + "\"");
				textBox1.Text = "";
				MessageBox.Show("Context menu item created","Fezzik",MessageBoxButtons.OK);
				GetCurrentContextMenu();
			}
		}

		//Method based on http://blog.voidnish.com/?p=17
		
		//MenuName - Name for the menu item (Play, Open etc.)
		//MenuDescription - The actual text that will be shown
		//MenuCommand - Path to executable
		private bool AddContextMenuItem(string MenuName, string MenuDescription, string MenuCommand)
		{
		  bool ret = false;
		  RegistryKey rkey = Registry.CurrentUser.OpenSubKey("Software\\Classes", true);
		  rkey = rkey.CreateSubKey("Directory");
		  
	        if(rkey != null)
	        {
	          string strkey = "shell\\" + MenuName + "\\command";
	          RegistryKey subky = rkey.CreateSubKey(strkey);
	          if(subky != null)
	          {
	            subky.SetValue("",MenuCommand);
	            subky.Close();
	            subky = rkey.OpenSubKey("shell\\" +
	              MenuName, true);
	            if(subky != null)
	            {
	              subky.SetValue("",MenuDescription);
	              subky.Close();
	            }
	            ret = true;
	          }
	          rkey.Close();
	        }

		  return ret;
		}		
		
		private void RemoveContextMenuItem(string MenuName)
		{
			RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software\\Classes\\Directory\\shell\\" + MenuName + "\\command");
			if(reg != null)
			{
				reg.Close();
				Registry.CurrentUser.DeleteSubKey("Software\\Classes\\Directory\\shell\\" + MenuName + "\\command");
			}
			reg = Registry.CurrentUser.OpenSubKey("Software\\Classes\\Directory\\shell\\" + MenuName);
			if(reg != null)
			{
				reg.Close();
				Registry.CurrentUser.DeleteSubKey("Software\\Classes\\Directory\\shell\\" + MenuName);
			}
		}
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://code.google.com/p/fezzik/wiki/BasicUsage");
		}

		private void CheckSecurity(string MenuName)
		{
			//check registry permissions
			RegistryPermission regPerm;
			regPerm = new RegistryPermission(RegistryPermissionAccess.Write, "HKEY_CURRENT_USER\\Software\\Classes\\Directory\\shell\\" + MenuName);
			regPerm.AddPathList(RegistryPermissionAccess.Write, "HKEY_CURRENT_USER\\Software\\Classes\\Directory\\shell\\" + MenuName + "\\command");
			regPerm.Demand();
		}
		
		
		void SetupFormLoad(object sender, EventArgs e)
		{
			GetCurrentContextMenu();
		}
		
		void GetCurrentContextMenu()
		{
			this.CheckSecurity("FezzikFileRenamer");
			RegistryKey regmenu = null;
			RegistryKey regcmd = null;

			regmenu = Registry.CurrentUser.OpenSubKey("Software\\Classes\\Directory\\shell\\FezzikFileRenamer",false);
			if(regmenu != null)
			{
				this.textBox2.Text = (String)regmenu.GetValue("");
				regcmd = Registry.CurrentUser.OpenSubKey("Software\\Classes\\Directory\\shell\\FezzikFileRenamer\\command",false);
				buttonRemoveContext.Enabled = true;
				if(regcmd != null)
				{
					string[] cmd = ((String)regcmd.GetValue("")).Split("\"".ToCharArray());
					this.textBox1.Text = cmd[1];
					this.textBox5.Text = cmd[5];
				}
			} else {
				buttonRemoveContext.Enabled = false;
			}	

		}
		
		void ButtonRemoveContextClick(object sender, EventArgs e)
		{
				// RemoveContext Menu
				RemoveContextMenuItem("FezzikFileRenamer");
				MessageBox.Show("Context menu item removed.","Fezzik",MessageBoxButtons.OK);
				textBox1.Text = "";
				textBox2.Text = "";
				buttonRemoveContext.Enabled = false;
		}
	
	}
}
