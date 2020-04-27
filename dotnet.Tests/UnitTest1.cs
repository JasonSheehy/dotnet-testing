using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using dotnet.Controllers;
using dotnet.Models;
using dotnet;
using Xunit;
using Moq;

namespace dotnet.Tests
{

    public abstract class AbstractLogger<T> : ILogger<T>
    {
        public IDisposable BeginScope<TState>(TState state)
            => throw new NotImplementedException();

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            => Log(logLevel, exception, formatter(state, exception));

        public abstract void Log(LogLevel logLevel, Exception ex, string information);
    }

    public class UnitTest1
    {
        [Fact]
        public async Task Get_ReturnsAList_WithSignupInfosList()
        {
            // Arrange
            var mock = new Mock<AbstractLogger<SignupInfoController>>();
            var controller = new SignupInfoController(mock.Object);

            // Act
            var actionResult = await controller.Get();

            // Assert
            var result = actionResult.Value as IEnumerable<SignupInfo>;
            Assert.Equal(2, ((ICollection<SignupInfo>)result).Count);
        }
    }
}
