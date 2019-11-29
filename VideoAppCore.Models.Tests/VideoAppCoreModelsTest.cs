using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace VideoAppCore.Models.Tests
{
    [TestClass]
    public class VideoAppCoreModelsTest
    {
        private readonly VideoRepositoryAdoNet _repository;

        public VideoAppCoreModelsTest()
        {
            var connectionString =
                "server=(localdb)\\mssqllocaldb;" +
                "database=VideoAppcore;integrated security=true;";
            _repository = new VideoRepositoryAdoNet(connectionString);
        }

        [TestMethod]
        public async Task AddVideoAsyncTest()
        {
            //Video video = new Video { Title = "ADO.NET", Url = "URL", Name = "Park", Company = "VisualAcademy", CreatedBy = "Park" };
            Video video = new Video { Title = "Dapper", Url = "URL", Name = "Park", Company = "VisualAcademy", CreatedBy = "Park" };

            Video newVideo = await _repository.AddVideoAsync(video);

            Assert.AreEqual(1, newVideo.Id);
        }

        [TestMethod]
        public async Task GetVideosAsyncTest()
        {
            var videos = await _repository.GetVideosAsync();

            foreach (var video in videos)
            {
                Console.WriteLine($"{video.Id} - {video.Title}");
            }
        }
    }
}
