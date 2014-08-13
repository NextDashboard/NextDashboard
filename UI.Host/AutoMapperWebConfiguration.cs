using AutoMapper;
using NextDashboard.Application.DataContracts;

namespace UI.Host
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureJobMapping();
        }

        private static void ConfigureJobMapping()
        {
            Mapper.CreateMap<NextDashboard.Application.DomainObjects.Job, Job>();
        }

    }
}