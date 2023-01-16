using ClientInterface.MyService;
using System;

namespace ClientInterface
{
    public enum MousEventType
    {
        LeftClick, RightClick, MidleClick, OffsetX, OffsetY
    }
    public class Mous
    {
        public int Id { get; set; }

        private ushort x;
        private ushort y;

        private ushort prev_X { get; set; }
        private ushort prev_Y { get;set; }

        public string msg { get; set; }
        public int UserId { get; set; }

        private MousEventType mousEventType { get; set; }

        public ushort X
        {
            get { return x; }

            set
            {
                prev_X = x;
                x = value;
                
                if(Math.Abs(prev_X - x) >= 100)
                {
                    ChangeMousEventType(MousEventType.OffsetX);
                }
            }
        }

        public ushort Y
        {
            get { return y; }

            set
            {
                prev_Y = y;
                y = value;

                if (Math.Abs(prev_Y - y) >= 100)
                {
                    ChangeMousEventType(MousEventType.OffsetY);
                }
            }
        }

        public void ChangeMousEventType(MousEventType type)
        {
            var obj = new MouseEventContractClient();
            mousEventType = type;
            obj.AddNewMousEventAsync(new MousEvent()
            {
                UserId = this.UserId,
                eventName = type.ToString(),
                mousX_pos = this.x,
                mousY_pos = this.y,
                eventTime = DateTime.Now.ToString()
            });
        }
    }
}
