using System.Runtime.Serialization;

namespace NextDashboard.Application.DataContracts
{
    [DataContract]
    public class Job
    {
        public Job(string name)
        {
            Name = name;
        }

        [DataMember]
        public string Name { get; set; }
    }
}