using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    [DataContract]
    public  class MousEvent
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string eventName { get; set; }

        [DataMember]
        public ushort? mousX_pos { get; set; }
        [DataMember]
        public ushort? mousY_pos { get; set; }

        [DataMember]
        public DateTime eventTime { get; set; }


    }
}
