using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Jobs.Jenkins;

namespace NextDashboard.Application.Repository
{
    public class JsonJobRepository : IJobRepository
    {
        private const string FileStore = "dataStore.json";

        public JsonJobRepository()
        {
            if (File.Exists(FileStore))
                File.Delete(FileStore);
            SeedFileWithData();
        }



        public List<Job> SelectAll()
        {
            string json = File.ReadAllText(FileStore);
            var jobs = JsonConvert.DeserializeObject<List<JenkinsJob>>(json);
            return jobs.Select(x => (Job) x).ToList();
        }

        public Job Select(int jobId)
        {
            string json = File.ReadAllText(FileStore);
            var jobs = JsonConvert.DeserializeObject<List<JenkinsJob>>(json);
            return jobs[jobId];
        }

        private void SeedFileWithData()
        {
            string seedData = JsonConvert.SerializeObject(new FakeJobRepository().SelectAll());
            File.WriteAllText(FileStore, seedData);
        }
    }
}