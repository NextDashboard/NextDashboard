using System.Runtime.Serialization;

namespace NextDashboard.Application.DataContracts
{
    [DataContract]
    public class Job
    {
        public Job()
        {
        }

        public Job(string id, string name, string status)
        {
            Name = name;
            Status = status;
            Id = id;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Id { get; set; }
    }
}