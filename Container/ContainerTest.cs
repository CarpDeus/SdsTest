using System;
using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }

        [Fact]
        public void CanBindAndGetMultipleService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            container.Bind(typeof(ITestFactorial), typeof(TestFactorial));
            var testInstance = container.Get<IContainerTestInterface>();
            var testFactorial = container.Get<ITestFactorial>();
            Assert.Equal(24, testFactorial.Factorial(4));
        }
        [Fact]
        public void CanBindAndGetMultipleServiceButCannotGetFactorialNegative()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            container.Bind(typeof(ITestFactorial), typeof(TestFactorial));
            var testInstance = container.Get<IContainerTestInterface>();
            var testFactorial = container.Get<ITestFactorial>();
            Assert.Throws<ArgumentOutOfRangeException>(() => testFactorial.Factorial(-1));
        }

    }
}