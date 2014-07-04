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
    public partial class ImagePreview : Form
    {
        /// <summary>
        /// Instantiates an empty <see cref="ImagePreview"/>
        /// </summary>
        public ImagePreview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instantiates an <see cref="ImagePreview"/> with the image found in the <paramref name="imagePath"/>
        /// </summary>
        /// <param name="imagePath"></param>
        public ImagePreview(string imagePath) :this()
        {

            pbPreview.Image = Image.FromFile(imagePath);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }   
}
