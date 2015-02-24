using System.Runtime.Serialization;
using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application.DataContracts
{
    [DataContract]
    public class Job
    {
        public Job()
        {
        }

        public Job(string id, string name, string statusDetail, JobStatus status)
        {
            Name = name;
            StatusDetail = statusDetail;
            Id = id;
            Status = status;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string StatusDetail { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public JobStatus Status { get; set; }
    }
}