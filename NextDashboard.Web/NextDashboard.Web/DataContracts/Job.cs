using System.Runtime.Serialization;

namespace NextDashboard.Web.DataContracts
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