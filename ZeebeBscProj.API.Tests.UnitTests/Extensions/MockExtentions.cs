using System;
using System.Linq.Expressions;
using Moq;

namespace ZeebeBscProj.API.Tests.UnitTests.Extensions
{
    internal static class MockExtentions
    {
        internal static Mock<S> ThatReturns<T, S>(this Mock<T> mock
            , Expression<Func<T, S>> method) where T : class where S : class
        {
            var newMock = new Mock<S>();
            mock.Setup(method).Returns(newMock.Object);

            return newMock;
        }
    }
}
