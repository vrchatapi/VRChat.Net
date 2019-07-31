using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using VRChatApi.Classes;
using VRChatApi.Endpoints;
using VRChatApi.Tests.Mocks;
using Xunit;

namespace VRChatApi.Tests
{
    public class UserApiTests
    {
        [Fact]
        public void ExposesProvidedUsernameAndPasswordAsProperties()
        {
            var api = new UserApi("my username", "my password");

            api.Username.Should().Be("my username");
            api.Password.Should().Be("my password");
        }

        [Fact]
        public void CanHandleValidCurrentUserDetailsResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("id", "my id"),
                new JProperty("username", "my username"),
                new JProperty("displayName", "my display name"),
                new JProperty("pastDisplayNames", new JArray(
                    new JObject(
                        new JProperty("displayName", "my old display name"),
                        new JProperty("updated_at", "some date")))),
                new JProperty("hasEmail", true),
                new JProperty("hasPendingEmail", false),
                new JProperty("obfuscatedEmail", "some obfuscated email"),
                new JProperty("obfuscatedPendingEmail", "some obfuscated pending email"),
                new JProperty("emailVerified", true),
                new JProperty("hasBirthday", true),
                new JProperty("unsubscribe", false),
                new JProperty("friends", new JArray("friend 1", "friend 2")),
                new JProperty("friendGroupName", "some friend group name"),
                new JProperty("blueprints", new JObject()),
                new JProperty("currentAvatarBlueprint", new JObject()),
                new JProperty("currentAvatar", "some current user avatar ID"),
                new JProperty("currentAvatarImageUrl", "https://unit.test/currentAvatarImageUrl.jpg"),
                new JProperty("currentAvatarAssetUrl", "https://unit.test/currentAvatarAssetUrl.jpg"),
                new JProperty("currentAvatarThumbnailImageUrl", "https://unit.test/currentAvatarThumbnailImageUrl.jpg"),
                new JProperty("status", "some status"),
                new JProperty("statusDescription", "some status description"),
                new JProperty("acceptedTOSVersion", 6),
                new JProperty("steamDetails", new JObject()),
                new JProperty("hasLoggedInFromClient", true),
                new JProperty("homeLocation", "some home location"),
                new JProperty("tags", new JArray("tag 1", "tag 2")),
                new JProperty("developerType", "none")
            ));

            var api = new UserApi("my username", "my password");
            var result = api.Login().Result;

            result.id.Should().Be("my id");
            result.username.Should().Be("my username");
            result.displayName.Should().Be("my display name");
            result.pastDisplayNames.Should().HaveCount(1);
            //result.pastDisplayNames[0].displayName.Should().Be("my old display name");
            //result.pastDisplayNames[0].updated_at.Should().Be("some date");
            result.hasEmail.Should().BeTrue();
            //result.hasPendingEmail.Should().BeFalse();
            result.obfuscatedEmail.Should().Be("some obfuscated email");
            //result.obfuscatedPendingEmail.Should().Be("some obfuscated pending email");
            result.emailVerified.Should().BeTrue();
            result.hasBirthday.Should().BeTrue();
            result.unsubscribe.Should().BeFalse();
            result.friends.Should().HaveCount(2);
            result.friends[0].Should().Be("friend 1");
            result.friends[1].Should().Be("friend 2");
            //result.friendGroupName.Should().Be("some friend group name");
            result.currentAvatar.Should().Be("some current user avatar ID");
            result.currentAvatarImageUrl.Should().Be("https://unit.test/currentAvatarImageUrl.jpg");
            result.currentAvatarAssetUrl.Should().Be("https://unit.test/currentAvatarAssetUrl.jpg");
            result.currentAvatarThumbnailImageUrl.Should().Be("https://unit.test/currentAvatarThumbnailImageUrl.jpg");
            result.status.Should().Be("some status");
            result.statusDescription.Should().Be("some status description");
            result.acceptedTOSVersion.Should().Be(6);
            result.steamDetails.Should().Be(new SteamDetails());
            result.hasLoggedInFromClient.Should().BeTrue();
            result.tags.Should().HaveCount(2);
            result.tags[0].Should().Be("tag 1");
            result.tags[1].Should().Be("tag 2");
            result.developerType.Should().Be("none");
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusCurrentUserDetailsResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new UserApi("my username", "my password");
            var result = api.Login().Result;
            result.Should().BeNull();
        }

        [Fact]
        public void CanHandleValidRegisterNewUserResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("id", "my id"),
                new JProperty("username", "my username"),
                new JProperty("displayName", "my display name"),
                new JProperty("pastDisplayNames", new JArray(
                    new JObject(
                        new JProperty("displayName", "my old display name"),
                        new JProperty("updated_at", "some date")))),
                new JProperty("hasEmail", true),
                new JProperty("hasPendingEmail", false),
                new JProperty("obfuscatedEmail", "some obfuscated email"),
                new JProperty("obfuscatedPendingEmail", "some obfuscated pending email"),
                new JProperty("emailVerified", true),
                new JProperty("hasBirthday", true),
                new JProperty("unsubscribe", false),
                new JProperty("friends", new JArray("friend 1", "friend 2")),
                new JProperty("friendGroupName", "some friend group name"),
                new JProperty("blueprints", new JObject()),
                new JProperty("currentAvatarBlueprint", new JObject()),
                new JProperty("currentAvatar", "some current user avatar ID"),
                new JProperty("currentAvatarImageUrl", "https://unit.test/currentAvatarImageUrl.jpg"),
                new JProperty("currentAvatarAssetUrl", "https://unit.test/currentAvatarAssetUrl.jpg"),
                new JProperty("currentAvatarThumbnailImageUrl", "https://unit.test/currentAvatarThumbnailImageUrl.jpg"),
                new JProperty("status", "some status"),
                new JProperty("statusDescription", "some status description"),
                new JProperty("acceptedTOSVersion", 6),
                new JProperty("steamDetails", new JObject()),
                new JProperty("hasLoggedInFromClient", true),
                new JProperty("homeLocation", "some home location"),
                new JProperty("tags", new JArray("tag 1", "tag 2")),
                new JProperty("developerType", "none")
            ));

            var api = new UserApi("my username", "my password");
            var result = api.Register("some username", "some password", "some email", "some birthday", "6").Result;

            result.id.Should().Be("my id");
            result.username.Should().Be("my username");
            result.displayName.Should().Be("my display name");
            result.pastDisplayNames.Should().HaveCount(1);
            //result.pastDisplayNames[0].displayName.Should().Be("my old display name");
            //result.pastDisplayNames[0].updated_at.Should().Be("some date");
            result.hasEmail.Should().BeTrue();
            //result.hasPendingEmail.Should().BeFalse();
            result.obfuscatedEmail.Should().Be("some obfuscated email");
            //result.obfuscatedPendingEmail.Should().Be("some obfuscated pending email");
            result.emailVerified.Should().BeTrue();
            result.hasBirthday.Should().BeTrue();
            result.unsubscribe.Should().BeFalse();
            result.friends.Should().HaveCount(2);
            result.friends[0].Should().Be("friend 1");
            result.friends[1].Should().Be("friend 2");
            //result.friendGroupName.Should().Be("some friend group name");
            result.currentAvatar.Should().Be("some current user avatar ID");
            result.currentAvatarImageUrl.Should().Be("https://unit.test/currentAvatarImageUrl.jpg");
            result.currentAvatarAssetUrl.Should().Be("https://unit.test/currentAvatarAssetUrl.jpg");
            result.currentAvatarThumbnailImageUrl.Should().Be("https://unit.test/currentAvatarThumbnailImageUrl.jpg");
            result.status.Should().Be("some status");
            result.statusDescription.Should().Be("some status description");
            result.acceptedTOSVersion.Should().Be(6);
            result.steamDetails.Should().Be(new SteamDetails());
            result.hasLoggedInFromClient.Should().BeTrue();
            result.tags.Should().HaveCount(2);
            result.tags[0].Should().Be("tag 1");
            result.tags[1].Should().Be("tag 2");
            result.developerType.Should().Be("none");
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusRegisterNewUserResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new UserApi("my username", "my password");
            var result = api.Register("some username", "some password", "some email", "some birthday", "6").Result;
            result.Should().BeNull();
        }

        [Fact]
        public void CanHandleValidGetUserByIdResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("id", "my id"),
                new JProperty("username", "my username"),
                new JProperty("displayName", "my display name"),
                new JProperty("currentAvatarImageUrl", "https://unit.test/currentAvatarImageUrl.jpg"),
                new JProperty("currentAvatarThumbnailImageUrl", "https://unit.test/currentAvatarThumbnailImageUrl.jpg"),
                new JProperty("developerType", "none"),
                new JProperty("tags", new JArray("tag 1", "tag 2")),
                new JProperty("status", "some status"),
                new JProperty("statusDescription", "some status description"),
                new JProperty("location", "some location"),
                new JProperty("worldId", "some world id"),
                new JProperty("instanceId", "some instance id")
            ));

            var api = new UserApi("my username", "my password");

            api.Username.Should().Be("my username");
            api.Password.Should().Be("my password");

            var result = api.GetById("some user id").Result;

            result.id.Should().Be("my id");
            result.username.Should().Be("my username");
            result.displayName.Should().Be("my display name");
            result.currentAvatarImageUrl.Should().Be("https://unit.test/currentAvatarImageUrl.jpg");
            result.currentAvatarThumbnailImageUrl.Should().Be("https://unit.test/currentAvatarThumbnailImageUrl.jpg");
            result.developerType.Should().Be("none");
            result.tags.Should().HaveCount(2);
            result.tags[0].Should().Be("tag 1");
            result.tags[1].Should().Be("tag 2");
            result.status.Should().Be("some status");
            result.statusDescription.Should().Be("some status description");
            result.location.Should().Be("some location");
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusGetUserByIdResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new UserApi("my username", "my password");
            var result = api.GetById("some user id").Result;
            result.Should().BeNull();
        }

        [Fact]
        public void CanHandleValidUpdateUserInfoResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("id", "my id"),
                new JProperty("username", "my username"),
                new JProperty("displayName", "my display name"),
                new JProperty("pastDisplayNames", new JArray(
                    new JObject(
                        new JProperty("displayName", "my old display name"),
                        new JProperty("updated_at", "some date")))),
                new JProperty("hasEmail", true),
                new JProperty("hasPendingEmail", false),
                new JProperty("obfuscatedEmail", "some obfuscated email"),
                new JProperty("obfuscatedPendingEmail", "some obfuscated pending email"),
                new JProperty("emailVerified", true),
                new JProperty("hasBirthday", true),
                new JProperty("unsubscribe", false),
                new JProperty("friends", new JArray("friend 1", "friend 2")),
                new JProperty("friendGroupName", "some friend group name"),
                new JProperty("blueprints", new JObject()),
                new JProperty("currentAvatarBlueprint", new JObject()),
                new JProperty("currentAvatar", "some current user avatar ID"),
                new JProperty("currentAvatarImageUrl", "https://unit.test/currentAvatarImageUrl.jpg"),
                new JProperty("currentAvatarAssetUrl", "https://unit.test/currentAvatarAssetUrl.jpg"),
                new JProperty("currentAvatarThumbnailImageUrl", "https://unit.test/currentAvatarThumbnailImageUrl.jpg"),
                new JProperty("status", "some status"),
                new JProperty("statusDescription", "some status description"),
                new JProperty("acceptedTOSVersion", 6),
                new JProperty("steamDetails", new JObject()),
                new JProperty("hasLoggedInFromClient", true),
                new JProperty("homeLocation", "some home location"),
                new JProperty("tags", new JArray("tag 1", "tag 2")),
                new JProperty("developerType", "none")
            ));

            var api = new UserApi("my username", "my password");
            var result = api.UpdateInfo("some user id", "some email", "some birthday", "6", new List<string> {"tag 1", "tag 2" }).Result;

            result.id.Should().Be("my id");
            result.username.Should().Be("my username");
            result.displayName.Should().Be("my display name");
            result.pastDisplayNames.Should().HaveCount(1);
            //result.pastDisplayNames[0].displayName.Should().Be("my old display name");
            //result.pastDisplayNames[0].updated_at.Should().Be("some date");
            result.hasEmail.Should().BeTrue();
            //result.hasPendingEmail.Should().BeFalse();
            result.obfuscatedEmail.Should().Be("some obfuscated email");
            //result.obfuscatedPendingEmail.Should().Be("some obfuscated pending email");
            result.emailVerified.Should().BeTrue();
            result.hasBirthday.Should().BeTrue();
            result.unsubscribe.Should().BeFalse();
            result.friends.Should().HaveCount(2);
            result.friends[0].Should().Be("friend 1");
            result.friends[1].Should().Be("friend 2");
            //result.friendGroupName.Should().Be("some friend group name");
            result.currentAvatar.Should().Be("some current user avatar ID");
            result.currentAvatarImageUrl.Should().Be("https://unit.test/currentAvatarImageUrl.jpg");
            result.currentAvatarAssetUrl.Should().Be("https://unit.test/currentAvatarAssetUrl.jpg");
            result.currentAvatarThumbnailImageUrl.Should().Be("https://unit.test/currentAvatarThumbnailImageUrl.jpg");
            result.status.Should().Be("some status");
            result.statusDescription.Should().Be("some status description");
            result.acceptedTOSVersion.Should().Be(6);
            result.steamDetails.Should().Be(new SteamDetails());
            result.hasLoggedInFromClient.Should().BeTrue();
            result.tags.Should().HaveCount(2);
            result.tags[0].Should().Be("tag 1");
            result.tags[1].Should().Be("tag 2");
            result.developerType.Should().Be("none");
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusUpdateUserInfoResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new UserApi("my username", "my password");
            var result = api.UpdateInfo("some user id", "some email", "some birthday", "6", new List<string> { "tag 1", "tag 2" }).Result;
            result.Should().BeNull();
        }
    }
}
