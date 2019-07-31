using System;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using VRChatApi.Classes;
using VRChatApi.Endpoints;
using VRChatApi.Tests.Mocks;
using Xunit;

namespace VRChatApi.Tests
{
    public class FriendsApiTests
    {
        [Fact]
        public void CanHandleValidFriendsOfCurrentUserResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some id"),
                    new JProperty("username", "some username"),
                    new JProperty("displayName", "some display name"),
                    new JProperty("currentAvatarImageUrl", "https://some.url/currentAvatarImageUrl.jpg"),
                    new JProperty("currentAvatarThumbnailImageUrl", "https://some.url/currentAvatarThumbnailImageUrl.jpg"),
                    new JProperty("tags", new JArray("tag 1", "tag 2")),
                    new JProperty("developerType", "some developer type"),
                    new JProperty("location", "some location"))));

            var api = new FriendsApi();
            var result = api.Get(0, 20, false).Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some id");
            result[0].username.Should().Be("some username");
            result[0].displayName.Should().Be("some display name");
            result[0].currentAvatarImageUrl.Should().Be("https://some.url/currentAvatarImageUrl.jpg");
            result[0].currentAvatarThumbnailImageUrl.Should().Be("https://some.url/currentAvatarThumbnailImageUrl.jpg");
            result[0].tags.Should().HaveCount(2).And.ContainInOrder("tag 1", "tag 2");
            result[0].developerType.Should().Be("some developer type");
            result[0].location.Should().Be("some location");
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusFriendsOfCurrentUserResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new FriendsApi();
            var result = api.Get().Result;
            result.Should().BeNull();
        }

        [Fact]
        public void CanHandleSendFriendRequestResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("id", "some id"),
                new JProperty("type", "friendrequest"),
                new JProperty("senderUserId", "some sender user id"),
                new JProperty("receiverUserId", "some receiver user id"),
                new JProperty("message", "some message"),
                new JProperty("details", new JObject()),
                new JProperty("jobName", "some job name"),
                new JProperty("jobColor", "some job color")));

            var api = new FriendsApi();
            var result = api.SendRequest("some user id", "my username").Result;

            result.id.Should().Be("some id");
            result.type.Should().Be("friendrequest");
            result.senderUserId.Should().Be("some sender user id");
            result.receiverUserId.Should().Be("some receiver user id");
            result.message.Should().Be("some message");
            result.details.Should().Be(new Details());
            result.jobName.Should().Be("some job name");
            result.jobColor.Should().Be("some job color");
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusSendFriendRequestResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new FriendsApi();
            var result = api.SendRequest("some user id", "my username").Result;
            result.Should().BeNull();
        }

        [Fact]
        public void CanHandleAcceptFriendRequestResponse()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void CanHandleSuccessfulDeleteFriendRequestResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("success", new JObject(
                    new JProperty("message", "some message"),
                    new JProperty("status_code", 200)))));
            var api = new FriendsApi();
            var result = api.DeleteFriend("some user id").Result;

            result.Should().BeTrue();
        }

        [Fact]
        public void CanHandleUnsuccessfulDeleteFriendRequestResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("error", new JObject(
                    new JProperty("message", "some message"),
                    new JProperty("status_code", 400)))));
            var api = new FriendsApi();
            var result = api.DeleteFriend("some user id").Result;

            result.Should().BeFalse();
        }
    }
}
