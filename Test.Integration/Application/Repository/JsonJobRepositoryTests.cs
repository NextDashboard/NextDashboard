using System.IO;
using FluentAssertions;
using NextDashboard.Application.Repository;
using NUnit.Framework;

namespace NextDashboard.Test.Integration.Application.Repository
{
    [TestFixture]
    public class JsonJobRepositoryTests
    {
        const string FileStore = "dataStore.json";
        [Test]
        public void Initializing_A_JsonRepo_When_No_File_Exists_Creates_A_File()
        {
            //Arrange
        
            if(File.Exists(FileStore))
                File.Delete(FileStore);
            
            //Act
            // ReSharper disable once UnusedVariable
            var jsonJobRepository = new JsonJobRepository();
            
            //Assert
            File.Exists(FileStore).Should().BeTrue();

        }

        [Test]
        public void Selecting_Jobs_From_A_Newly_Created_Repo_Returns_A_List_Of_Jobs()
        {
            //Arrange

            if (File.Exists(FileStore))
                File.Delete(FileStore);

            //Act
            var jsonJobRepository = new JsonJobRepository();

            //Assert
            jsonJobRepository.SelectAll().Count.Should().BeGreaterThan(0);

        }

        [TearDown]
        public void TearDown()
        {
           // File.Delete(FileStore);
        }
    }
}