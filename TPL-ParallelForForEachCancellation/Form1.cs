using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPL_ParallelForForEachCancellation
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public int counter { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cancellationTokenSource=new CancellationTokenSource();
            List<string> urls = new List<string>()
            {
                "https://trello.com/",
                "https://chat.openai.com/",
                "https://drive.google.com/",
                "https://www.canva.com/",
                "https://mail.google.com/",
                "https://github.com/",
                "https://amazon.com",
                "https://google.com",
                "https://firebase.com"
            };

            HttpClient client = new HttpClient();


            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken =cancellationTokenSource.Token;
            Task.Run(() =>
            {

                try
                {
                    Parallel.ForEach(urls, parallelOptions, (url) =>
                    {
                        string content = client.GetStringAsync(url).Result;
                        string data = $"{url}:{content.Length}";
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();

                        listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(data); });

                    });
                }
                catch (OperationCanceledException operationex)
                {
                    MessageBox.Show("The operation was cancel:" + operationex.Message);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("General Error: " + ex.Message);
                }
               
            });
        



        }

        private void button3_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = counter++.ToString();

        }
    }
}
