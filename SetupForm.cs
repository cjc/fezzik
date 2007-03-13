﻿/*
 * Fezzik - A text-editor based file renamer.
 * 
 * Cameron Coley - coleyc@gmail.com
 * 
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
// Temporarily removed pending approval to redistribute code.
// using MSjogren.Samples.ShellLink;
using Microsoft.Win32;

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

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			richTextBox1.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\deflang3081{\fonttbl{\f0\fswiss\fprq2\fcharset0 Century Gothic;}{\f1\fswiss\fcharset0 Arial;}}
{\colortbl ;\red0\green0\blue0;}
{\*\generator Msftedit 5.41.15.1507;}\viewkind4\uc1\pard\qc\cf1\f0\fs72 Fezzik\cf0\f1\fs20\par
\fs16 A text editor based file renamer\par
http://code.google.com/p/fezzik\par
\pard\par
\b\fs18 Silk - \b0 http://www.famfamfam.com/lab/icons/silk/\b\par
\b0\par
This program uses selected icons from the excellent Silk set by Mark James.\par
\par
\b ShellLink - \b0 http://www.msjogren.net/dotnet/eng/samples/dotnet_shelllink.asp\b\par
\b0\par
This program uses code from Mattias Sj\'f6gren's ShellLink to create shortcuts in the SendTo menu.\fs20\par
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
		
		void Button3Click(object sender, EventArgs e)
		{
			// Remove menu item.
		
			if (radioButton1.Checked)
			{
				// RemoveContext Menu
				RemoveContextMenuItem("FezzikFileRenamer");
				MessageBox.Show("Context menu item removed.","Fezzik",MessageBoxButtons.OK);
			} 
			else if (radioButton2.Checked)
			{
				// Remove SendTo Shortcut
				// Delete the shortcut with the right name under the SendTo folder.
			}
			
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

				if (radioButton1.Checked)
				{
					// Add Context Menu
					AddContextMenuItem("FezzikFileRenamer", "Rename files with Fezzik", Application.ExecutablePath + " \"" + textBox1.Text + "\" \"%1\"");

					textBox1.Text = "";
					MessageBox.Show("Context menu item created","Fezzik",MessageBoxButtons.OK);
				} 
				else if (radioButton2.Checked)
				{
					// Add SendTo shortcut
					//MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.SendTo));
					//ShellShortcut ss = new ShellShortcut(Environment.GetFolderPath(Environment.SpecialFolder.SendTo) + "\\" + textBox2.Text + ".lnk");
					//ss.Path = System.Reflection.Assembly.GetExecutingAssembly().Location;
					//ss.Arguments = "\"" + textBox1.Text + "\"";
					//ss.Description = "Rename files with Fezzik";
					//ss.Save();
	
					textBox1.Text = "";
					MessageBox.Show("SendTo shortcut created","Fezzik",MessageBoxButtons.OK);

				}

			}
		}

		//Method based on http://blog.voidnish.com/?p=17
		
		//MenuName - Name for the menu item (Play, Open etc.)
		//MenuDescription - The actual text that will be shown
		//MenuCommand - Path to executable
		private bool AddContextMenuItem(string MenuName, string MenuDescription, string MenuCommand)
		{
		  bool ret = false;
		  RegistryKey rkey =
		    Registry.ClassesRoot.OpenSubKey("Folder");
		  if(rkey != null)
		  {
		    string extstring = rkey.GetValue("").ToString();
		    rkey.Close();
		    if( extstring != null )
		    {
		      if( extstring.Length > 0 )
		      {
		        rkey = Registry.ClassesRoot.OpenSubKey(
		          extstring,true);
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
		      }
		    }
		  }
		  return ret;
		}		
		
		private void RemoveContextMenuItem(string MenuName)
		{
			RegistryKey reg = Registry.ClassesRoot.OpenSubKey("Folder\\shell\\" + MenuName + "\\command");
			if(reg != null)
			{
				reg.Close();
				Registry.ClassesRoot.DeleteSubKey("Folder\\shell\\" + MenuName + "\\command");
			}
			reg = Registry.ClassesRoot.OpenSubKey("Folder\\shell\\" + MenuName);
			if(reg != null)
			{
				reg.Close();
				Registry.ClassesRoot.DeleteSubKey("Folder\\shell\\" + MenuName);
			}
		}
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://code.google.com/p/fezzik/wiki/BasicUsage");
		}
	}
}
