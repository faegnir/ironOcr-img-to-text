using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronOcr;

namespace img_to_text
{
    public partial class converter : Form
    {
        public converter()
        {
            InitializeComponent();
        }

        private void SelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
                ImagePath.Text = open.FileName;
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            IronTesseract IronOcr = new IronTesseract();
            IronOcr.Language = OcrLanguage.Turkish;
            var Result = IronOcr.Read(ImagePath.Text);
            richTextBox1.Text = Result.Text;
        }

    }
}
