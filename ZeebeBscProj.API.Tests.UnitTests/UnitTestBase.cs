using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;

namespace ZeebeBscProj.API.Tests.UnitTests
{

    public abstract class UnitTestBase
    {
        protected  IFixture Fixture { get; }

        public UnitTestBase()
        {
            Fixture = new Fixture();
        }
        
        protected Mock<T> Mock<T>() where T : class
            => new Mock<T>();
        protected T Any<T>() where T : class
            => It.IsAny<T>();
        protected T Create<T>() where T : class
            => Fixture.Create<T>();

    }
}
