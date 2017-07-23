using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateRaw
{
    public partial class Form1 : Form
    {
        string mPrefix = "data";

        public Form1()
        {
            InitializeComponent();

            this.Text = Application.ProductName;

            this.textBoxWidth.Text  = "1";
            this.textBoxHeight.Text = "1";

            this.textBoxFileNum.Text = "10";
        }

        //---------------------------------------------------------------------
        private void buttonSave_Click(object sender, EventArgs e)
        {
            int imgW = int.Parse(this.textBoxWidth.Text );
            int imgH = int.Parse(this.textBoxHeight.Text);

            int imgWH = imgW * imgH;

            ushort[] data = new ushort[imgWH];

            int NumOfFiles = int.Parse(this.textBoxFileNum.Text);

            for (int nFile = 0; nFile < NumOfFiles; nFile++)
            {
                for (int n = 0; n < imgWH; n++)
                {
                    data[n] = (ushort)(n + nFile * imgW / NumOfFiles);
                }

                string filename = this.mPrefix + "_W" + imgW.ToString("0000") + "_H" + imgH.ToString("0000") + "_N" + nFile.ToString("0000") + ".raw";
                System.IO.BinaryWriter bw = new System.IO.BinaryWriter(new System.IO.FileStream(filename, System.IO.FileMode.OpenOrCreate));

                for (int n = 0; n < imgWH; n++)
                {
                    bw.Write(data[n]);
                }

                bw.Close();
            }

            MessageBox.Show("Finished");
        }
    }
}
