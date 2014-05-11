using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GGMaker
{
    public class RunPoint
    {
        public RunPoint( string time, string x, string y, string speed, string latG, string longG )
        {
            Time = decimal.Parse( time );
            X = decimal.Parse( x );
            Y = decimal.Parse( y );
            Speed = decimal.Parse( speed );
            LatG = decimal.Parse( latG );
            LongG = decimal.Parse( longG );
        }

        public decimal Time { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Speed { get; set; }
        public decimal LatG { get; set; }
        public decimal LongG { get; set; }
    }
}
