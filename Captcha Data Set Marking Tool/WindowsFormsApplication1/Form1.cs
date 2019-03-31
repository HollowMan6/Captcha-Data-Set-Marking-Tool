using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public String pic;
        public Form1()
        {
            InitializeComponent();
            String[] files = Directory.GetFiles(Application.StartupPath + "/wrong/","*.png");
            pic = files[0].Replace(Application.StartupPath + "/wrong/", "");
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "/wrong/" + pic);
            textBox1.Text = pic.Replace(".png", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            try
            {
                File.Move(Application.StartupPath + "/wrong/" + pic, Application.StartupPath + "/right/" + textBox1.Text + ".png");
            }
            catch (Exception)
            {
                File.Delete(Application.StartupPath + "/wrong/" + pic);
            }
            finally
            {
                String[] files = Directory.GetFiles(Application.StartupPath + "/wrong/", "*.png");
                pic = files[0].Replace(Application.StartupPath + "/wrong/", "");
                if (pic == null)
                    MessageBox.Show("wrong文件夹下不存在png文件！", "错误");
                else
                {
                    pictureBox1.Image = Image.FromFile(Application.StartupPath + "/wrong/" + pic);
                    textBox1.Text = pic.Replace(".png", "");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            File.Delete(Application.StartupPath + "/wrong/" + pic);
            String[] files = Directory.GetFiles(Application.StartupPath + "/wrong/", "*.png");
            pic = files[0].Replace(Application.StartupPath + "/wrong/", "");
            if (pic == null)
                MessageBox.Show("wrong文件夹下不存在png文件！", "错误");
            else
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "/wrong/" + pic);
                textBox1.Text = pic.Replace(".png", "");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                button1_Click(null,null);
            }
        }
    }
}
