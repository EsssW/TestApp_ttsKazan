using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientInterface
{
    internal class Mous
    {
        public int Id { get; set; }

        private ushort x;
        private ushort y;

        private ushort prev_X = 0;
        private ushort prev_Y = 0;

        public string msg { get; set; }

        public ushort X
        {
            get { return x; }

            set
            {
                prev_X = x;
                y = value;
                
                if(Math.Abs(y - prev_X) >= 100)
                {
                    msg = $"{prev_X} --> {x}";
                }
            }
        }

        public ushort Y
        {
            get { return prev_Y; }

            set
            {
                prev_Y = y;
                y = value;

                if (Math.Abs(y - prev_Y) >= 100)
                {
                    msg = $"{prev_Y} --> {y}";
                }
            }
        } 
    }
}
