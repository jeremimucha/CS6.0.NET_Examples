using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.IO;

namespace DataParallelismWithForEach
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProcessImages_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ProcessFiles();
            });
        }

        private void ProcessFiles()
        {
            // Use ParallelOptions instance to store the CancellationToken
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            // Load up all *.jpg files, and make a new folder for the modified data
            string[] files = Directory.GetFiles(@"G:\C#\C#60_NET46\Ch19_Multithreaded_Parallel_Async\Images",
                "*.jpg", SearchOption.AllDirectories);
            string newDir = @"G:\C#\C#60_NET46\Ch19_Multithreaded_Parallel_Async\ModifiedImages";
            Directory.CreateDirectory(newDir);

            // Process the image data in a blocking manner
            //foreach (string currentFile in files)
            //{
            //    string filename = Path.GetFileName(currentFile);

            //    using (Bitmap bitmap = new Bitmap(currentFile))
            //    {
            //        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitmap.Save(Path.Combine(newDir, filename));

            //        // Print out the ID of the thread processing the current image
            //        this.Text = string.Format("Processing {0} on thread {1}", filename,
            //            Thread.CurrentThread.ManagedThreadId);
            //    }
            //}

            // Process the files in parallel
            try
            {
                Parallel.ForEach(files, parOpts, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();

                    string filename = Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, filename));

                        // This code statement is now aproblem!
                        // this.Text = string.Format("Processing {0} on thread {1}", filename,
                        // Thread.CurrentThread.managedThreadId);

                        // Invoke on the Form object, to allow secondary threads to access controls
                        // in a thread-safe manner
                        this.Invoke((Action)delegate
                        {
                            this.Text = string.Format("Processing {0} on thread {1}", filename,
                                Thread.CurrentThread.ManagedThreadId);
                        });
                    }
                });
                this.Invoke((Action)delegate
                {
                    this.Text = "Done!";
                });
            }catch(OperationCanceledException e)
            {
                this.Invoke((Action)delegate
                {
                    this.Text = e.Message;
                });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // This will be used to tell all the  worker threads to stop!
            cancelToken.Cancel();
        }

        private CancellationTokenSource cancelToken = new CancellationTokenSource();
    }
}
