using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SQLTrace.Controls
{
    public partial class NewIssueForm : Form
    {
        public NewIssueForm()
        {
            InitializeComponent();
        }
        
        public string IssueText
        {
            get
            {
                return exceptionTextBox.Text;
            }
            set
            {
                exceptionTextBox.Text = value;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}