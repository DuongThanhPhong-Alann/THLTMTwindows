using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form2 : Form
    {
        private bool isFileOpened = false;
        private string currentFilePath = "";
        private bool isBold = false;
        private bool isItalic = false;
        private bool isUnderline = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families) ;
        }

        private void SetDefaultFontAndSize()
        {

            richTextBox1.Font = new Font("Tahoma", 14);
        }
        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();


            SetDefaultFontAndSize();


            isFileOpened = false;
            currentFilePath = "";
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                    isFileOpened = true;
                    currentFilePath = openFileDialog.FileName;
                    SetDefaultFontAndSize();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFileOpened)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    isFileOpened = true;
                    currentFilePath = saveFileDialog.FileName;
                    MessageBox.Show("Đã lưu thành công văn bản.");
                }
            }

            else
            {
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Đã lưu thành công văn bản.");
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();


            SetDefaultFontAndSize();


            isFileOpened = false;
            currentFilePath = "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!isFileOpened)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    isFileOpened = true;
                    currentFilePath = saveFileDialog.FileName;
                    MessageBox.Show("Đã lưu thành công văn bản.");
                }
            }

            else
            {
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Đã lưu thành công văn bản.");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            isBold = !isBold;
            UpdateSelectedTextStyle();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            isItalic = !isItalic;
            UpdateSelectedTextStyle();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            isUnderline = !isUnderline;
            UpdateSelectedTextStyle();
        }

        private void UpdateSelectedTextStyle()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newStyle = currentFont.Style;

                if (isBold)
                    newStyle |= FontStyle.Bold;
                else
                    newStyle &= ~FontStyle.Bold;

                if (isItalic)
                    newStyle |= FontStyle.Italic;
                else
                    newStyle &= ~FontStyle.Italic;

                if (isUnderline)
                    newStyle |= FontStyle.Underline;
                else
                    newStyle &= ~FontStyle.Underline;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in sizes)
            {
                toolStripComboBox2.Items.Add(size);
            }
        }

        
        

        

        private void toolStripComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedItem != null)
            {
                string selectedFont = toolStripComboBox1.SelectedItem.ToString();
                richTextBox1.Font = new Font(selectedFont, richTextBox1.Font.Size);
            }
        }

        private void toolStripComboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (toolStripComboBox2.SelectedItem != null)
            {
                float selectedSize = float.Parse(toolStripComboBox2.SelectedItem.ToString());
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, selectedSize);
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            
        }


    }
}
