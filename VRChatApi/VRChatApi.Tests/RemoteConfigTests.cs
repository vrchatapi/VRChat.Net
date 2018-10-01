using System;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using VRChatApi.Endpoints;
using VRChatApi.Tests.Mocks;
using Xunit;

namespace VRChatApi.Tests
{
    public class RemoteConfigTests
    {
        [Fact]
        public void SetsGlobalApiKey()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("clientApiKey", "some api key")));
            var api = new RemoteConfig();
            var response = api.Get().Result;

            response.clientApiKey.Should().Be("some api key");
            Global.ApiKey.Should().Be("some api key");
        }
    }
}
