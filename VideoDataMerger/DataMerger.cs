using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using AviFile;

namespace VideoDataMerger
{
    public class DataMerger
    {
        public void MergeData( BackgroundWorker worker, DoWorkEventArgs e, 
            string fileName,
            int startFrame, int endFrame, int startPoint, 
            int endPoint, List<RunPoint> gpsPoints, AviManager aviManager, VideoStream aviStream )
        {
            AviManager outManager = null;

            try
            {
                var maxX = 0m;
                var minX = 0m;
                var maxY = 0m;
                var minY = 0m;
            
                for ( var i = startPoint; i <= endPoint; i++ )
                {
                    var point = gpsPoints[i];
                    if ( point.X > maxX ) maxX = point.X;
                    if ( point.X < minX ) minX = point.X;
                    if ( point.Y > maxY ) maxY = point.Y;
                    if ( point.Y < minY ) minY = point.Y;
                }
                var width = ( Math.Abs( maxX - minX ) + 20 );
                var height = ( Math.Abs( maxY - minY ) + 20 );

                outManager = new AviManager( fileName, false );

                var outStream = outManager.AddVideoStream( true, aviStream.FrameRate, aviStream.GetBitmap( startFrame ) );

                var scaleFactor1 = ( outStream.Width / 4m ) / width > ( outStream.Height / 4m ) / height
                                       ? ( outStream.Height / 4m ) / height
                                       : ( outStream.Width / 4m ) / width;

                width = scaleFactor1 * width;
                height = scaleFactor1 * height;

                var bitmap = new Bitmap( (int)width, (int)height );
                var graphics = Graphics.FromImage( bitmap );
                var pen = Pens.Black;
                var pointA = gpsPoints[startPoint];
                var startTime = pointA.Time;
                for ( var i = startPoint + 1; i <= endPoint; i++ )
                {
                    var pointB = gpsPoints[i];
                    graphics.DrawLine( pen,
                                       (int)( ( ( pointA.X - minX + 10 ) ) * scaleFactor1 ),
                                       (int)( ( ( maxY - pointA.Y + 10 ) ) * scaleFactor1 ),
                                       (int)( ( ( pointB.X - minX + 10 ) ) * scaleFactor1 ),
                                       (int)( ( ( maxY - pointB.Y + 10 ) * scaleFactor1 ) )
                        );
                    pointA = pointB;
                }

                pointA = gpsPoints[startPoint];
                var count = startPoint;
                var brush = Brushes.Black;
                var font = new Font( "Courier New", 15, FontStyle.Bold );
                var timer = new TimeSpan(0);
                var frameRate = aviStream.FrameRate;
                var msPerFrame = (int)(1/frameRate*1000);
                for ( var i = startFrame; i <= endFrame; i++ )
                {
                    if ( worker.CancellationPending )
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        var img =
                            aviStream.GetBitmap(i);

                        var bmp = new Bitmap(img.Width, img.Height, img.PixelFormat);
                        var g = Graphics.FromImage(bmp);
                        g.DrawImage(img, 0, 0);

                        g.DrawImage(bitmap, img.Width - bitmap.Width - 10, 10);
                        g.FillEllipse(Brushes.Red,
                                      img.Width -
                                      bitmap.Width + (int) ((pointA.X - minX + 10)*scaleFactor1) - 13,
                                      (int) ((maxY - pointA.Y + 10)*scaleFactor1) + 7,
                                      6, 6);
                        if ((pointA.Time - startTime).ToString("N1") == ((i - startFrame)/frameRate).ToString("N1"))
                        {
                            count++;
                            if (count < endPoint)
                            {
                                pointA = gpsPoints[count];
                            }

                        }
                        g.DrawString("Speed:  " + pointA.Speed + " mph", font, brush, 0, 0);
                        g.DrawString("Lat G:  " + pointA.LatG, font, brush, 0, 20);
                        g.DrawString("Long G: " + pointA.LongG, font, brush, 0, 40);

                        timer = timer.Add(new TimeSpan(0, 0, 0, 0, msPerFrame));
                        g.DrawString(
                            string.Format("{0}:{1}.{2}", timer.Minutes, timer.Seconds.ToString().PadLeft(2, '0'),
                                          timer.Milliseconds.ToString().PadLeft(3, '0')), font, brush, 0, 60);

                        outStream.AddFrame(bmp);
                        worker.ReportProgress( (i*100) / (endFrame-startFrame) -1 );
                    }
                }
                if ( worker.CancellationPending )
                {
                    e.Cancel = true;
                }
                else
                {
                    var audioStream = aviManager.GetWaveStream();
                    var streamInfo = new Avi.AVISTREAMINFO();
                    var waveFormat = new Avi.PCMWAVEFORMAT();
                    var audioSize = 0;
                    var audioData = audioStream.GetStreamData(ref streamInfo, ref waveFormat, ref audioSize);
                    var audioPerFrame = audioSize*1.0m/aviStream.CountFrames;
                    var newStartPtr = new IntPtr(audioData.ToInt64() + (Int64) (startFrame*audioPerFrame));
                    var newAudioSize = (int) (audioPerFrame*endFrame - audioPerFrame*startFrame);
                    outManager.AddAudioStream(newStartPtr, streamInfo, waveFormat, newAudioSize);
                }
                outManager.Close();
                worker.ReportProgress( 100 );

            }
            
            catch (Exception e1)
            {
                if ( outManager != null )
                    outManager.Close();
                throw e1;
            }            
        }
    }
}
