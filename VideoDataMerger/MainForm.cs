using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AviFile;

namespace VideoDataMerger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeBackgoundWorker();
        }

        private void InitializeBackgoundWorker()
        {
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
        }


        private VideoStream aviStream;
        private AviManager aviManager;
        private List<RunPoint> gpsPoints;
        private Image mapBitmap;
        private decimal scaleFactor;
        private decimal minX;
        private decimal maxY;
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        private ProgressForm pgForm;

        private void MainForm_Load( object sender, EventArgs e )
        {
            slider.Enabled = false;
            mapSlider.Enabled = false;
        }

        private void SetupGPSFile( string fileName )
        {
            mapSlider.Enabled = true;
            GetPoints(fileName);
            mapBitmap = GetMapBitmap();
            SetupMapDisplay();
        }
        
        private void SetupAVIFile(string fileName)
        {
            CloseAVI();
            aviManager = new AviManager( fileName, true );
            aviStream = aviManager.GetVideoStream();
            aviStream.GetFrameOpen();

            slider.Enabled = true;
            slider.Minimum = 0;
            slider.Maximum = aviStream.CountFrames - 1;
            slider.SmallChange = 1;
            slider.LargeChange = (int)aviStream.FrameRate;
            slider.Value = 0;

            txtStartFrame.Text = "0";
            txtEndFrame.Text = ( aviStream.CountFrames - 1 ).ToString();

            SetSelectedFrame( 0 );
        }

        private void CloseAVI()
        {
            if ( aviStream != null )
            {
                aviStream.GetFrameClose();
                aviStream.Close();
            }
            if ( aviManager != null )
                aviManager.Close();            
        }

        private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            CloseAVI();
        }

        private void SetSelectedFrame( int frame )
        {
            var bitmap = aviStream.GetBitmap( frame );
            var newBitmap = new Bitmap( 320, 240 );
            var g = Graphics.FromImage( newBitmap );
            g.ScaleTransform( 320 / ( bitmap.Width * 1.0f ), 240 / ( bitmap.Height * 1.0f ) );
            g.DrawImage( bitmap, 0, 0 );
            pbSource.Image = newBitmap;
            lblCurrentFrame.Text = string.Format("{0} ({1:N2})", frame, frame/aviStream.FrameRate);
        }

        private void slider_Scroll( object sender, EventArgs e )
        {
            SetSelectedFrame( slider.Value );
        }

        private void label2_Click( object sender, EventArgs e )
        {
            txtEndFrame.Text = slider.Value.ToString();
        }

        private void label1_Click( object sender, EventArgs e )
        {
            txtStartFrame.Text = slider.Value.ToString();
        }

        private void GetPoints( string fileName )
        {
            gpsPoints = new List<RunPoint>();
            using ( var reader = new StreamReader( fileName ) )
            {
                var line1 = new List<string>( reader.ReadLine().ToLower().Split(',') );
                var timeIndex = line1.IndexOf("time [s]");
                var positionXIndex = line1.IndexOf( "position x [m]" );
                var positionYIndex = line1.IndexOf( "position y [m]" );
                var speedIndex = line1.IndexOf( "gps speed [mph]" );
                var latGIndex = line1.IndexOf( "accel lateral [g]" );
                var longGIndex = line1.IndexOf( "accel longitudinal [g]" );
                while (!reader.EndOfStream)
                {
                    var data = reader.ReadLine().Split(',');
                    gpsPoints.Add(new RunPoint(data[timeIndex], data[positionXIndex], 
                        data[positionYIndex], data[speedIndex], data[latGIndex], data[longGIndex]));
                }
            }
        }
        private void SetupMapDisplay()
        {
            mapSlider.Minimum = 0;
            mapSlider.Maximum = gpsPoints.Count() - 1;
            mapSlider.SmallChange = 1;
            mapSlider.LargeChange = gpsPoints.Count() / 10;
            txtStartPoint.Text = "0";
            txtEndPoint.Text = (gpsPoints.Count()-1).ToString();

            SetupPointDisplay( 0 );
        }
        private void SetupPointDisplay( int index )
        {
            var point = gpsPoints[index];
            lblSpeed.Text = point.Speed.ToString();
            lblLatG.Text = point.LatG.ToString();
            lblLongG.Text = point.LongG.ToString();
            lblCurrentPoint.Text = string.Format( "{0} ({1})", index, point.Time );
            lblTime.Text = point.Time.ToString();

            var bm = new Bitmap(mapBitmap);
            var g = Graphics.FromImage(bm);
            g.FillEllipse( Brushes.Red,
                    (int)( ( point.X - minX ) * scaleFactor ) - 3,
                    (int)( ( maxY - point.Y ) * scaleFactor ) - 3,
                    6, 6 );
            pbMap.Image = bm;
        }

        private Image GetMapBitmap()
        {
            var maxX = 0m;
            minX = 0m;
            maxY = 0m;
            var minY = 0m;
            foreach ( var point in gpsPoints )
            {
                if ( point.X > maxX ) maxX = point.X;
                if ( point.X < minX ) minX = point.X;
                if ( point.Y > maxY ) maxY = point.Y;
                if ( point.Y < minY ) minY = point.Y;
            }
            var width = ( Math.Abs( maxX - minX ) );
            var height = ( Math.Abs( maxY - minY ) );
            
            scaleFactor = 310 / width >= 230 / height
                ? 230 / height
                : 310 / width;

            var bitmap = new Bitmap( 320, 240 );
            var graphics = Graphics.FromImage( bitmap );
            var pen = Pens.Black;
            var pointA = gpsPoints[0];
            for ( var i = 1; i < gpsPoints.Count; i++ )
            {
                var pointB = gpsPoints[i];
                graphics.DrawLine( pen,
                    (int)( ( ( pointA.X - minX ) ) * scaleFactor ),
                    (int)( ( ( maxY - pointA.Y ) ) * scaleFactor ),
                    (int)( ( ( pointB.X - minX ) ) * scaleFactor ),
                    (int)( ( ( maxY - pointB.Y ) * scaleFactor ) )
                    );
                pointA = pointB;
            }
            return bitmap;
        }

        private void mapSlider_Scroll( object sender, EventArgs e )
        {
            SetupPointDisplay( mapSlider.Value );
        }

        private void label7_Click( object sender, EventArgs e )
        {
            txtStartPoint.Text = mapSlider.Value.ToString();
        }

        private void label6_Click( object sender, EventArgs e )
        {
            txtEndPoint.Text = mapSlider.Value.ToString();
        }

        private void MergeVideoAndData(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if ( worker.CancellationPending )
            {
                e.Cancel = true;
            }
            else
            {
                int startFrame = int.Parse(txtStartFrame.Text);
                int endFrame = int.Parse(txtEndFrame.Text);
                int startPoint = int.Parse(txtStartPoint.Text);
                int endPoint = int.Parse(txtEndPoint.Text);
                var merger = new DataMerger();


                merger.MergeData( worker, e, string.Format( "{0}_merged.avi", aviFileDialog.FileName.Substring( 0, aviFileDialog.FileName.Length - 4 ) ),
                    startFrame, endFrame, startPoint, endPoint, gpsPoints, aviManager, aviStream);
            }
            //MessageBox.Show("Done!");
        }

        private void btnMerge_Click( object sender, EventArgs e )
        {
            if ( lblVideoFileName.Text == "No file selected" || lblGPSFile.Text == "No file selected" )
            {
                MessageBox.Show("Please select a video and a GPS CSV file.");
            }
            else
            {
                pgForm = new ProgressForm(backgroundWorker);
                pgForm.ShowDialog();
            }
        }

        private void backgroundWorker_DoWork( object sender, DoWorkEventArgs e )
        {
            // Get the BackgroundWorker that raised this event.
            var worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            //e.Result = ComputeFibonacci( (int)e.Argument, worker, e );
            MergeVideoAndData(worker, e);
        }

        private void backgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            // First, handle the case where an exception was thrown.
            pgForm.Close();
            if ( e.Error != null )
            {
                MessageBox.Show( e.Error.Message );
            }
            else if ( e.Cancelled )
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                MessageBox.Show( "Cancelled" );
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                MessageBox.Show( "Done" );
            }
        }

        private void btnChooseVideo_Click( object sender, EventArgs e )
        {
            var result = aviFileDialog.ShowDialog();
            if ( result == DialogResult.OK )
            {
                if ( File.Exists( aviFileDialog.FileName ) )
                {
                    lblVideoFileName.Text = aviFileDialog.SafeFileName;
                    SetupAVIFile(aviFileDialog.FileName);
                    
                }
                else
                    MessageBox.Show( "Please select a valid file!" );
            }
        }

        private void btnChooseGPS_Click( object sender, EventArgs e )
        {
            var result = csvFileDialog.ShowDialog();
            if ( result == DialogResult.OK )
            {
                if ( File.Exists( csvFileDialog.FileName ) )
                {
                    lblGPSFile.Text = csvFileDialog.SafeFileName;
                    this.Refresh();
                    SetupGPSFile( csvFileDialog.FileName);
                }
                else
                    MessageBox.Show( "Please select a valid file!" );
            }
        }



        

        

        
    }
}
