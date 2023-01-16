
using System.Runtime.Serialization;

namespace TestApp
{
    [DataContract]
    public  class MousEvent
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string eventName { get; set; }

        [DataMember]
        public ushort? mousX_pos { get; set; }
        [DataMember]
        public ushort? mousY_pos { get; set; }

        [DataMember]
        public string eventTime { get; set; }

        [DataMember]
        public ServerUser user { get; set; }

    }
}
