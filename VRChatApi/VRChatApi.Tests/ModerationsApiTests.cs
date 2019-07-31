using System;
using System.Linq;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using VRChatApi.Endpoints;
using VRChatApi.Tests.Mocks;
using Xunit;

namespace VRChatApi.Tests
{
    public class ModerationsApiTests
    {
        [Fact]
        public void CanHandleValidPlayerModerationsResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some id"),
                    new JProperty("type", "some type"),
                    new JProperty("sourceUserId", "my user id"),
                    new JProperty("sourceDisplayname", "my display name"),
                    new JProperty("targetUserId", "target user id"),
                    new JProperty("targetDisplayName", "target display name"),
                    new JProperty("created", "some timestamp"))));

            var api = new ModerationsApi();
            var result = api.GetPlayerModerations().Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some id");
            result[0].type.Should().Be("some type");
            result[0].sourceUserId.Should().Be("my user id");
            result[0].sourceDisplayName.Should().Be("my display name");
            result[0].targetUserId.Should().Be("target user id");
            result[0].targetDisplayName.Should().Be("target display name");
            result[0].created.Should().Be(new DateTime());
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusPlayerModerationsResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new ModerationsApi();
            var result = api.GetPlayerModerations().Result;
            result.Should().BeNull();
        }

        [Fact]
        public void CanHandleValidPlayerModeratedResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some id"),
                    new JProperty("type", "some type"),
                    new JProperty("sourceUserId", "source user id"),
                    new JProperty("sourceDisplayname", "source display name"),
                    new JProperty("targetUserId", "my user id"),
                    new JProperty("targetDisplayName", "my display name"),
                    new JProperty("created", "some timestamp"))));

            var api = new ModerationsApi();
            var result = api.GetPlayerModerated().Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some id");
            result[0].type.Should().Be("some type");
            result[0].sourceUserId.Should().Be("source user id");
            result[0].sourceDisplayName.Should().Be("source display name");
            result[0].targetUserId.Should().Be("my user id");
            result[0].targetDisplayName.Should().Be("my display name");
            result[0].created.Should().Be(new DateTime());
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusPlayerModeratedResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new ModerationsApi();
            var result = api.GetPlayerModerated().Result;
            result.Should().BeNull();
        }
    }
}
