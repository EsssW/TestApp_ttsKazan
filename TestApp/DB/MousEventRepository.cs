using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class MousEventRepository : IMousEventRepository
    {
        private List<MousEvent> mousEvents = new List<MousEvent>();

        private int counter = 1;

        public MousEventRepository()
        {
            mousEvents.Add(new MousEvent { Id = 1, eventName = "клик правой", mousX_pos = 1, mousY_pos = 1, eventTime = DateTime.Now });
            mousEvents.Add(new MousEvent { Id = 2, eventName = "сдвиг мыши по оси x", mousX_pos = 11, mousY_pos = 5, eventTime = DateTime.Now });
            mousEvents.Add(new MousEvent { Id = 3, eventName = "клик левой", mousX_pos = 1, mousY_pos = 1, eventTime = DateTime.Now });
        }

        public bool AddNewMousEvent(MousEvent mousEvent)
        {
            throw new NotImplementedException();
        }

        public MousEvent GetMousEventById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MousEvent> GetMousEvents()
        {
            throw new NotImplementedException();
        }

        public bool RemoveNewMousEvent(MousEvent mousEvent)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMousEvent(int id, MousEvent mousEvent)
        {
            throw new NotImplementedException();
        }
    }
}
