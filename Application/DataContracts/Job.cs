using System.Runtime.Serialization;

namespace NextDashboard.Application.DataContracts
{
    [DataContract]
    public class Job
    {
        public Job()
        {
        }

        public Job(string name, string status)
        {
            Name = name;
            Status = status;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Type { get; set; }
    }
}