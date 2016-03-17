﻿using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace EasyConnect
{
	partial class AboutBox : Form
	{
		public AboutBox()
		{
			InitializeComponent();
			
			_productNameLabel.Text = AssemblyProduct;
			_versionLabel.Text = String.Format("Version {0}", AssemblyVersion);
			_copyrightLabel.Text = AssemblyCopyright;
			_descriptionTextBox.Text = AssemblyDescription;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Text = String.Format("About {0}", AssemblyTitle);
		}

		public string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);

				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute) attributes[0];

					if (titleAttribute.Title != "")
						return titleAttribute.Title;
				}
				
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);

				if (attributes.Length == 0)
					return "";

				return ((AssemblyDescriptionAttribute) attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);

				if (attributes.Length == 0)
					return "";

				return ((AssemblyProductAttribute) attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);

				if (attributes.Length == 0)
					return "";

				return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
				
				if (attributes.Length == 0)
					return "";
				
				return ((AssemblyCompanyAttribute) attributes[0]).Company;
			}
		}

		private void _okButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void _linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://lstratman.github.io/EasyConnect/");
		}
	}
}