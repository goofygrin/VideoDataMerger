using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoDataMerger
{
    public partial class ProgressForm : Form
    {
        private readonly BackgroundWorker backgroundWorker;
        public ProgressForm( BackgroundWorker bgWorker )
        {
            InitializeComponent();
            backgroundWorker = bgWorker;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            // Cancel the asynchronous operation.
            backgroundWorker.CancelAsync();
        }

        private void backgroundWorker_ProgressChanged( object sender,
            ProgressChangedEventArgs e )
        {
            progressBar1.Value = e.ProgressPercentage >= 0 ? 
                (e.ProgressPercentage >= 100 ? 100 : e.ProgressPercentage) : 0;
        }

        private void ProgressForm_Shown( object sender, EventArgs e )
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
}
