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

namespace Change_Encrypt_File_to_ANSI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Text files|*.txt";
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                //display result         
                foreach (string name in openFileDialog1.FileNames)
                {
                   
                    listView1.Items.Add(name);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (!Directory.Exists(textBox1.Text))
            {
                MessageBox.Show("Path to save file does not exists");
                return;
            }
            if (listView1.Items.Count == 0 )
            {
                MessageBox.Show("Please select any file");
                return;
            }
            try
            {
                foreach (ListViewItem itm in listView1.Items)
                {
                    string fileName_NS = itm.Text;
                    string text = null;
                    using (var sr = new StreamReader(fileName_NS))
                    {
                        text = sr.ReadToEnd();
                    }
                    string OldfileName = Path.GetFileName(fileName_NS);
                    Console.WriteLine(OldfileName);
                    // ################### แปลง UTF-8 เป็น TIS-620 ###################
                    Encoding encoding = Encoding.GetEncoding("TIS-620");
                    string fileName = textBox1.Text + "\\" + OldfileName;

                    using (FileStream fs = new FileStream(fileName, FileMode.Create))
                    {
                        using (StreamWriter writer = new StreamWriter(fs, encoding))
                        {
                            writer.Write(text);
                        }
                    }
                }
                MessageBox.Show("Complete");
                listView1.Items.Clear();
                System.Diagnostics.Process.Start(textBox1.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult fd = folderBrowserDialog1.ShowDialog();
            if (fd == DialogResult.OK)
            {
                // display result
                textBox1.Text = (folderBrowserDialog1.SelectedPath);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
    
}


