using System;
using System.Collections.Concurrent;
using System.Linq;
using Xunit;
using Zeebe.Client.Api.Worker;
using ZeebeBscProj.Models.WorkerModels;
using ZeebeBscProj.Repositories.Implementations.ZBClient.WorkerService;

namespace ZeebeBscProj.API.Tests.UnitTests.Repositories
{
    public class WorkerRepoTest : UnitTestBase
    {
        [Fact]
        public void DeployWorker_throws_exception_upwards()
        {
            //Arrange
            var workerServiceMock = Mock<IZeebeWorkerService>();
            workerServiceMock.Setup(service =>
                                        service.DeployWorker(Any<ZeebeWorkerModel>(),Any<string>()))
                             .Throws<Exception>();
                                               
            var dictionary = new ConcurrentDictionary<string, JobAndWorker>();
            var uut = new WorkerRepo(dictionary,workerServiceMock.Object);

            //Act & Assert
            Assert.Throws<Exception>(()=> uut.DeployWorker(Create<ZeebeWorkerModel>()));
        }
        [Fact]
        public void DeployWorker_throws_ArgumentException_upwards_when_adding_worker_with_same_name_twice()
        {
            //Arrange
            var workerServiceMock = Mock<IZeebeWorkerService>();
            var worker = Create<ZeebeWorkerModel>();
            var dictionary = new ConcurrentDictionary<string, JobAndWorker>();
            dictionary[worker.Name] = new JobAndWorker(Mock<IJobWorker>().Object,worker);
            var uut = new WorkerRepo(dictionary, workerServiceMock.Object);

            //Act & Assert
            Assert
                .Throws<ArgumentException>(() => uut.DeployWorker(worker));
        }
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void DeployWorker_adds_worker_to_Dictionary_The_number_of_elements_in_the_dictionary_matches_the_number_of_added_workers(int numberOfWorkers)
        {
            //Arrange
            var workerServiceMock = Mock<IZeebeWorkerService>();
            var dictionary = new ConcurrentDictionary<string, JobAndWorker>();
            var workers = Enumerable.Range(0, numberOfWorkers).Select(_=> Create<ZeebeWorkerModel>());
            var uut = new WorkerRepo(dictionary, workerServiceMock.Object);

            //Act
            foreach(var worker in workers)
                uut.DeployWorker(worker);

            //Assert
            Assert.Equal(numberOfWorkers,dictionary.Count);
            Assert.Equal(dictionary.Count,uut.GetWorkers().Count());
        }
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void RemoveWorker_removes_worker_from_the_dictionary(int numberOfWorkers)
        {
            //Arrange
            var workerServiceMock = Mock<IZeebeWorkerService>();
            workerServiceMock
                .Setup(service =>
                           service.DeployWorker(Any<ZeebeWorkerModel>(), Any<string>()))
                .Returns(()=>Mock<IJobWorker>().Object);
            var dictionary = new ConcurrentDictionary<string, JobAndWorker>();
            var workers = Enumerable.Range(0, numberOfWorkers).Select(_ => Create<ZeebeWorkerModel>()).ToList();
            var uut = new WorkerRepo(dictionary, workerServiceMock.Object);
            workers.ForEach(worker => uut.DeployWorker(worker));
            //Act
            workers.ForEach(worker => uut.RemoveWorker(worker.Name));
            //Assert
            Assert.Equal(0,uut.GetWorkers().Count());

        }


    }
}
