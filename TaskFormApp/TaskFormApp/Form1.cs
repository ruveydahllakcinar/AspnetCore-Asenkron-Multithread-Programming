using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int counter { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnreadfile_Click(object sender, EventArgs e)
        {
            string data = String.Empty;
            Task<string> read = ReadFileAsync();

            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com");
            data = await read;
            richTextBox1.Text = data;
        }

        private void btncounter_Click(object sender, EventArgs e)
        {
            txtBoxCounter.Text=counter++.ToString();
        }

        private string ReadFile()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("file.txt"))
            {
                Thread.Sleep(5000);
                data = s.ReadToEnd();

            }

            return data;
        }

        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("file.txt"))
            {
                Task<string> mytask= s.ReadToEndAsync();

                data = await mytask;
                return data;
            }
        }

        private Task<string> ReadFileAsync2()
        {
            StreamReader s = new StreamReader("file.txt");
            
                return s.ReadToEndAsync();
            
        }
    }
}
