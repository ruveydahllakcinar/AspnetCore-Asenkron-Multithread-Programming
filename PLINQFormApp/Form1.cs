using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLINQFormApp
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }
        private bool Calculate(int x)
        {
            Thread.SpinWait(50000);
            return x % 12 == 0;
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            Task.Run(() => {

                try
                {
                    Enumerable.Range(1, 1000000).AsParallel().WithCancellation(cancellationTokenSource.Token).Where(Calculate).ToList().ForEach(x =>
                    {
                        Thread.Sleep(100);
                        listBox1.Invoke((MethodInvoker)delegate
                        {
                            listBox1.Items.Add(x);
                        });
                    });
                } catch(OperationCanceledException ope)
                {
                    MessageBox.Show("Operation was canceled");
                }
                catch (Exception)
                {

                    MessageBox.Show("A new error has occurred");
                }




            });

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
    }
}
