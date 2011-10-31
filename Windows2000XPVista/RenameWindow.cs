﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UltraRDC
{
    public partial class RenameWindow : Form
    {
        public RenameWindow()
        {
            InitializeComponent();
        }

        public string ValueText
        {
            get
            {
                return newValueTextBox.Text;
            }

            set
            {
                newValueTextBox.Text = value;
            }
        }

        public string Title
        {
            get
            {
                return Text;
            }

            set
            {
                Text = value;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}