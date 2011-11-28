﻿namespace CustomAuthorizationPolicy.Tests.Unit.Handlers.AdvSectionMaps
{
    using System;
    using NUnit.Framework;
    using AdvSectionMaps = CustomAuthorizationPolicy.Web.Handlers.AdvSectionMaps;

    [TestFixture]
    public class GetHandlerTests
    {
        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var handler = new AdvSectionMaps.GetHandler();
            Assert.IsNotNull(handler.Execute());
        }
    }
}
