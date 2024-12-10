using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // 1000 ms = 1 giây
            timer1.Start();
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hộp thoại mở file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Media Files|*.avi;*.mpeg;*.wav;*.midi;*.mp4;*.mp3",
                Title = "Chọn file media"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Phát file được chọn bằng Windows Media Player
                axWindowsMediaPlayer1.URL = openFileDialog.FileName;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Thoát ứng dụng
            Application.Exit();
        }

        private void oPENToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Media Files|*.avi;*.mpeg;*.wav;*.midi;*.mp4;*.mp3";
            //dlg.Filter = "AVI file| *.avi | MPEG File | *.mpeg | Wav File | *.Wav | Midi File | *.midi | MP4 File | *.mp4 | MP3 File | *.mp3";
            if(dlg.ShowDialog() == DialogResult.OK)
                    axWindowsMediaPlayer1.URL = dlg.FileName;
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss tt"));
        }
    }
}
