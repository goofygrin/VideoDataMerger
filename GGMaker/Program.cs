using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using AviFile;

namespace GGMaker
{
    class Program
    {
        static void Main( string[] args )
        {
            var gpsPoints = new List<RunPoint>();
            using ( var reader = new StreamReader( args[0] ) )
            {
                reader.ReadLine();
                while ( !reader.EndOfStream )
                {
                    var data = reader.ReadLine().Split( ',' );
                    gpsPoints.Add( new RunPoint( data[0], data[1], data[2], data[3], data[8], data[9] ) );
                }
            }
            var maxG = 0m;
            foreach( var point in gpsPoints )
            {
                if ( Math.Abs( point.LatG ) > maxG )
                    maxG = Math.Abs(point.LatG);
                if ( Math.Abs( point.LongG ) > maxG )
                    maxG = Math.Abs(point.LongG);
            }
            maxG *= 1.1m;
            var height = 450;
            var width = 450;
            var bm = new Bitmap(height, width);
            var g = Graphics.FromImage(bm);
            g.FillRectangle( Brushes.White, 0, 0, height, width);
            g.DrawEllipse( Pens.Black, width-401, 0, 400, 400 );
            g.DrawEllipse( Pens.Black, width-351, 50, 300, 300 );
            g.DrawEllipse( Pens.Black, width-301, 100, 200, 200 );
            g.DrawEllipse( Pens.Black, width-251, 150, 100, 100 );
            g.DrawLine( Pens.Black, width - 401, 0, width - 401, 400 );
            g.DrawLine( Pens.Black, width - 201, 0, width - 201, 400 );
            g.DrawLine( Pens.Black, width - 401, 400, width, 400 );
            g.DrawLine( Pens.Black, width - 401, 200, width, 200 );
            var f = new Font("Courier New", 7);
            g.DrawString( "0", f, Brushes.Black, width - 401 - f.Size, 200-f.Size );
            g.DrawString( (maxG*.25m).ToString( "N2"), f, Brushes.Black, width - 401 - ((maxG*.25m).ToString( "N2").Length * f.Size), 150-f.Size );
            g.DrawString( (maxG*.5m).ToString( "N2"), f, Brushes.Black, width - 401 - ((maxG*.5m).ToString( "N2").Length * f.Size), 100-f.Size );
            g.DrawString( (maxG*0.75m).ToString( "N2"), f, Brushes.Black, width - 401 - ((maxG*.75m).ToString( "N2").Length * f.Size), 50-f.Size );
            g.DrawString( (maxG*-.25m).ToString( "N2"), f, Brushes.Black, width - 401 - ((maxG*-.25m).ToString( "N2").Length * f.Size), 250-f.Size );
            g.DrawString( (maxG*-.5m).ToString( "N2"), f, Brushes.Black, width - 401 - ((maxG*-.5m).ToString( "N2").Length * f.Size), 300-f.Size );
            g.DrawString( (maxG*-0.75m).ToString( "N2"), f, Brushes.Black, width - 401 - ((maxG*-.75m).ToString( "N2").Length * f.Size), 350-f.Size );
            
            g.DrawString( "0", f, Brushes.Black, width - 201-(f.Size/2), 400 );
            g.DrawString( ( maxG * .25m ).ToString( "N2" ), f, Brushes.Black, width - 151 - ( ( maxG * .25m ).ToString( "N2" ).Length * f.Size/2 ), 400 );
            g.DrawString( ( maxG * .5m ).ToString( "N2" ), f, Brushes.Black, width - 101 - ( ( maxG * .5m ).ToString( "N2" ).Length * f.Size/2 ), 400 );
            g.DrawString( ( maxG * 0.75m ).ToString( "N2" ), f, Brushes.Black, width - 51 - ( ( maxG * .75m ).ToString( "N2" ).Length * f.Size/2 ), 400 );
            g.DrawString( ( maxG * -.25m ).ToString( "N2" ), f, Brushes.Black, width - 251 - ( ( maxG * -.25m ).ToString( "N2" ).Length * f.Size/2 ), 400 );
            g.DrawString( ( maxG * -.5m ).ToString( "N2" ), f, Brushes.Black, width - 301 - ( ( maxG * -.5m ).ToString( "N2" ).Length * f.Size/2 ), 400 );
            g.DrawString( ( maxG * -0.75m ).ToString( "N2" ), f, Brushes.Black, width - 351 - ( ( maxG * -.75m ).ToString( "N2" ).Length * f.Size/2 ), 400 );
            
            g.DrawString( maxG.ToString(), f, Brushes.Black, width - 401 - ( maxG.ToString().Length * 7 ), 0 );
            g.DrawString(  maxG.ToString(), f, Brushes.Black, width-(maxG.ToString().Length*7), 400 );
            g.DrawString( "-" + maxG, f, Brushes.Black, width - 401 - ( maxG.ToString().Length * 7 ), 400 );

            var multiplier = 200 / maxG;
            foreach( var p in gpsPoints )
            {
                g.FillEllipse( Brushes.Black, (float)( width - 201 + ( multiplier * p.LatG ) - 3 ),
                                  (float)( 200 - ( multiplier * p.LongG ) - 3 ), 6, 6 );
            }
            bm.Save( "test.png", ImageFormat.Png );
            return;
            var q = new List<RunPoint>(10);
            
            var manager = new AviManager( "test.avi", false );
            var stream = manager.AddVideoStream(true, 25, new Bitmap( bm ));
            foreach( var p in gpsPoints )
            {
                q.Add(p);
                if ( q.Count > 10 )
                    q.RemoveAt(0);
                var newBM = new Bitmap(bm);
                var graphics = Graphics.FromImage(newBM);
                foreach ( var point in q )
                {
                    graphics.FillEllipse(Brushes.Black, (float) (width - 201 + (multiplier*point.LatG) - 3),
                                  (float) (200 - (multiplier*point.LongG) - 3), 6, 6);
                }
                var pp = q[0];
                for ( var i=1; i<q.Count; i++ )
                {
                    graphics.DrawLine( Pens.Gray, (float)( width - 201 + ( multiplier * pp.LatG ) ),
                                  (float)( 200 - ( multiplier * pp.LongG ) ),
                                  (float)( width - 201 + ( multiplier * q[i].LatG ) ),
                                  (float)( 200 - ( multiplier * q[i].LongG ) ) );
                    pp = q[i];
                }
                //for ( var i = 0; i < 3; i++ )
                    stream.AddFrame( newBM );
                
            }
            
            manager.Close();
            bm.Save( "test.png", ImageFormat.Png);
        }
    }
}
