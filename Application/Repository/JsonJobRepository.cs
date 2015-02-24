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
            if (File.Exists(FileStore)) return;
            //File.Delete(FileStore);
            SeedFileWithData();
        }



        public List<Job> SelectAll()
        {
            string json;
            using (var sr = new StreamReader(FileStore))
            {
                json = sr.ReadToEnd();
            }

            var jobs = JsonConvert.DeserializeObject<List<JenkinsJob>>(json);
            return jobs.Select(x => (Job) x).ToList();
        }

        public Job Select(int jobId)
        {
          return  SelectAll().First(x=> x.Id.Equals(jobId.ToString()));
        }

        private void SeedFileWithData()
        {
            var seedData = JsonConvert.SerializeObject(new FakeJobRepository().SelectAll());
            using (var sw = new StreamWriter(FileStore))
            {
                sw.Write(seedData);
            }
        }
    }
}