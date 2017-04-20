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

namespace CSharpAsync
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnCallMethod_Click(object sender, EventArgs e)
        {
            this.Text = await DoWorkAsync();
        }

        // async and await here are optional
        private async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Done with work!";
            });
        }

        
        // returning void with an async method
        private async Task MethodReturningVoidAsync()
        {
            await Task.Run(() =>
            {
                // Do some work here
                Thread.Sleep(4000);
            });
        }

        private async void btnVoidMethodCall_Click(object sender, EventArgs e)
        {
            await MethodReturningVoidAsync();
            MessageBox.Show("Done!");
        }

        private async void btnMultiAwaits_Click(object sender,  EventArgs e)
        {
            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with first task!");

            await Task.Run(() => { Thread.Sleep(1000); });
            MessageBox.Show("Done with second task!");

            await Task.Run(() => { Thread.Sleep(1500); });
            MessageBox.Show("Done with third task!");
        }

        private void MethodForThreadPool(object state)
        {
            int[] args = (int[])state;
            // args[0] -> time in ms to sleep
            // args[1] -> taks id
            Thread.Sleep(args[0]);
            MessageBox.Show(string.Format("Done with task #{0}", args[1]));
        }

        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(MethodForThreadPool), new int[] { 3000, 1 });
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(MethodForThreadPool), new int[] { 2000, 2 });
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(MethodForThreadPool), new int[] { 1000, 3 });
        }
    }
}
