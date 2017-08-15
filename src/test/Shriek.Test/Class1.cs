﻿using Shriek.ConfigCenter.Domain.Aggregates;
using System;
using Shriek.ConfigCenter.Domain.Commands;
using Shriek.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shriek.Storage;

namespace Shriek.Test
{
    [TestClass]
    public class TestDI
    {
        [TestMethod]
        public void BootstrapperTest()
        {
            var services = new ServiceCollection();

            services.AddShriek();
            services.AddScoped<IRepository<ConfigItemAggregateRoot>, Repository<ConfigItemAggregateRoot>>();

            var bus = services.BuildServiceProvider().GetService<ICommandBus>();

            Assert.IsNotNull(bus);

            bus.Send(new CreateConfigItemCommand(Guid.NewGuid())
            {
                Name = "ysj",
                Value = "very good"
            });
        }
    }
}