using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Marathon
{
    /// <summary>
    /// Prompting for a filename
    /// </summary>
    public partial class Filename : Form
    {
        private string file;

        /// <summary>
        /// The filename chosen by the user
        /// </summary>
        public string File
        {
            get { return file; }
        }

        /// <summary>
        /// Constructor initializing the form
        /// </summary>
        public Filename()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                OK.Enabled = true;
            else if (textBox1.Text.Length == 0)
                OK.Enabled = false;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            file = textBox1.Text + ".lawl";
            this.Close();
        }
    }
}
