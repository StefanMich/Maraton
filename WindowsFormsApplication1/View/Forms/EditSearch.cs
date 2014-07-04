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
    public partial class EditSearch : Form
    {
        private string title;
        private string editedTitle;

        /// <summary>
        /// Gets the original title 
        /// </summary>
        public string Title
        {
            get { return title; }
        }

        /// <summary>
        /// Gets the edited title
        /// </summary>
        public string EditedTitle
        {
            get { return editedTitle; }
        }

        /// <summary>
        /// Instantiates an empty <see cref="EditSearch"/>
        /// </summary>
        public EditSearch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instantiates an <see cref="EditSearch"/> with a title
        /// </summary>
        /// <param name="title"></param>
        public EditSearch(string title)
            : this()
        {
            this.title = title;
            this.tbTitle.Text = title;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            editedTitle = tbTitle.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Close();
        }


    }
}
