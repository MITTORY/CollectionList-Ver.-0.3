using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace список
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            языкToolStripMenuItem.ComboBox.DataSource = new CultureInfo[]
                {
                    CultureInfo.GetCultureInfo("ru-RU"),
                    CultureInfo.GetCultureInfo("en-US")
                };
            языкToolStripMenuItem.ComboBox.DisplayMember = "NativeName";
            языкToolStripMenuItem.ComboBox.ValueMember = "Name";

            if(!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                языкToolStripMenuItem.ComboBox.SelectedValue = Properties.Settings.Default.Language;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = языкToolStripMenuItem.ComboBox.SelectedValue.ToString();
            Properties.Settings.Default.Save();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                listBox1.Items.Add("[" + comboBox1.SelectedItem.ToString() + "]" + " " + textBox1.Text.ToString());
                textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox2.Text);
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=1)
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                int index = listBox1.SelectedIndex;
                String text = listBox1.SelectedItem.ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Insert(index - 1, text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count)
            {
                int index = listBox1.SelectedIndex;
                String text = listBox1.SelectedItem.ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Insert(index + 1, text);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writter = new StreamWriter(dlg.FileName);

                for (int i = 0; i< listBox1.Items.Count; i++)
                {
                    writter.WriteLine(listBox1.Items[i].ToString());
                }
                MessageBox.Show(Message.ExitRequets3, Message.ExitTitle3, MessageBoxButtons.OK, MessageBoxIcon.Information);
                writter.Close();
            }
            dlg.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName);
                    foreach (string line in lines)
                        listBox1.Items.Add(line);
                        
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
        }   

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(Message.ExitRequest1, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Message.ExitRequest2,"",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void языкToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void перезапуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}




/*DialogResult result = MessageBox.Show("Вы точно хотите сменить язык?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
if (result == DialogResult.Yes)
    Application.Restart();*/


