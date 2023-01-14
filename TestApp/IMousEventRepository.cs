using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public interface IMousEventRepository
    {
        List<MousEvent> GetMousEvents();

        MousEvent GetMousEventById(int id);

        bool AddNewMousEvent(MousEvent mousEvent);

        bool RemoveNewMousEvent(MousEvent mousEvent);

        bool UpdateMousEvent(int id, MousEvent mousEvent);
    }
}
