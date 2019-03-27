using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using DigitalParadoxCLI.Configuration;
using Xunit;
using Xunit.Sdk;

namespace DigitalParadoxCLI.Tests
{
    public class ConfigurationTests
    {

        [Fact]
        public void TestLogicShouldFailWithMissingType()
        {
            Assert.Throws<TrueException>(() => IConfigurationImplementsExpectedInterfaces(typeof(IContainer)));
            Assert.Throws<TrueException>(() => ConfigurationImplementsExpectedInterfaces(typeof(IContainer)));
        }

        [Theory]
        [InlineData(typeof(IConfiguration))]
        [InlineData(typeof(IConnectionStrings))]
        [InlineData(typeof(IAppSettings))]
        public void ConfigurationImplementsExpectedInterfaces(Type type)
        {
            var testtype = typeof(Configuration.Configuration);

            var isImplemented = testtype.GetInterfaces().Contains(type);

            Assert.True(isImplemented);
        }

        [Theory]
        [InlineData(typeof(IConnectionStrings))]
        [InlineData(typeof(IAppSettings))]
        // ReSharper disable once InconsistentNaming
        public void IConfigurationImplementsExpectedInterfaces(Type type)
        {
            var testtype = typeof(IConfiguration);

            bool isImplemented = testtype.GetInterfaces().Contains(type);

            Assert.True(isImplemented);
        }

    }
}
