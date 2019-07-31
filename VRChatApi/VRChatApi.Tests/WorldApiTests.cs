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
    public class WorldApiTests
    {
        [Fact]
        public void CanHandleValidGetWorldByIdResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("id", "some world id"),
                new JProperty("name", "some world name"),
                new JProperty("description", "some world description"),
                new JProperty("featured", false),
                new JProperty("authorId", "some author id"),
                new JProperty("authorName", "some author name"),
                new JProperty("totalLikes", 420),
                new JProperty("totalVisits", 1337),
                new JProperty("capacity", (short)42),
                new JProperty("tags", new JArray("tag 1", "tag 2")),
                new JProperty("releaseStatus", "public"),
                new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                new JProperty("assetUrl", "https://unit.test/assetUrl.asset"),
                new JProperty("pluginUrl", "https://unit.test/pluginUrl.plugin"),
                new JProperty("unityPackageUrl", "https://unit.test/unityPackageUrl.unityPackage"),
                new JProperty("namespace", "some namespace presumably"),
                new JProperty("unityPackageUpdated", false),
                new JProperty("unityPackages", new JArray(
                    new JObject(
                        new JProperty("id", "some unity package id"),
                        new JProperty("assetUrl", "https://unit.test/1/assetUrl.asset"),
                        new JProperty("pluginUrl", "https://unit.test/1/pluginUrl.plugin"),
                        new JProperty("unityVersion", "7"),
                        new JProperty("unitySortNumber", 9001),
                        new JProperty("assetVersion", 1),
                        new JProperty("platform", "some platform"),
                        new JProperty("created_at", "some date")))),
                new JProperty("isSecure", false),
                new JProperty("isLockdown", false),
                new JProperty("version", 2),
                new JProperty("organization", "some organization"),
                new JProperty("instances", new List<JArray> { new JArray("some instance id", 2) }),
                new JProperty("occupants", 4)));

            var api = new WorldApi();
            var result = api.Get("some world id").Result;

            result.id.Should().Be("some world id");
            result.name.Should().Be("some world name");
            result.description.Should().Be("some world description");
            result.featured.Should().BeFalse();
            result.authorId.Should().Be("some author id");
            result.authorName.Should().Be("some author name");
            result.totalLikes.Should().Be(420);
            result.totalVisits.Should().Be(1337);
            result.capacity.Should().Be(42);
            result.tags.Should().HaveCount(2);
            result.tags[0].Should().Be("tag 1");
            result.tags[1].Should().Be("tag 2");
            result.releaseStatus.Should().Be(ReleaseStatus.Public);
            result.imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result.thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result.assetUrl.Should().Be("https://unit.test/assetUrl.asset");
            result.pluginUrl.Should().Be("https://unit.test/pluginUrl.plugin");
            result.unityPackageUrl.Should().Be("https://unit.test/unityPackageUrl.unityPackage");
            result.nameSpace.Should().Be("some namespace presumably");
            result.unityPackageUpdated.Should().BeFalse();
            result.unityPackages.Should().HaveCount(1);
            result.unityPackages[0].id.Should().Be("some unity package id");
            result.unityPackages[0].assetUrl.Should().Be("https://unit.test/1/assetUrl.asset");
            result.unityPackages[0].unityVersion.Should().Be("7");
            result.unityPackages[0].unitySortNumber.Should().Be(9001);
            result.unityPackages[0].assetVersion.Should().Be(1);
            result.unityPackages[0].platform.Should().Be("some platform");
            result.unityPackages[0].created_at.Should().Be(new DateTime());
            result.isSecure.Should().BeFalse();
            result.isLockdown.Should().BeFalse();
            result.version.Should().Be(2);
            result.organization.Should().Be("some organization");
            result.instances.Should().HaveCount(1);
            result.instances[0].id.Should().Be("some instance id");
            result.instances[0].occupants.Should().Be(2);
            result.occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusGetWorldByIdResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new WorldApi();
            var result = api.Get("some world id").Result;
            result.Should().BeNull();
        }

        [Fact]
        public void CanHandleValidListAnyWorldsResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search().Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListAnyWorldsSortedPopularityResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(sort: SortOptions.Popularity).Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListAnyWorldsByUserOptionsResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(user: UserOptions.Friends).Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListAnyWorldsByUserIdResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(userId: "some user id").Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListAnyWorldsByKeywordResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(keyword: "some keyword").Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListAnyWorldsByTagsResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(tags: "some tag").Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListAnyWorldsByExcludedTagsResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(excludeTags: "some tag").Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListAnyWorldsByPublicReleaseStatusResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(releaseStatus: ReleaseStatus.Public).Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListAnyFeaturedWorldsResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(featured: true).Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListActiveWorldsResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(endpoint: WorldGroups.Active).Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListFavoriteWorldsResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(endpoint: WorldGroups.Favorite).Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleValidListRecentWorldsResponse()
        {
            MockHttpMessageHandler.SetResponse(new JArray(
                new JObject(
                    new JProperty("id", "some world id"),
                    new JProperty("name", "some world name"),
                    new JProperty("authorName", "some author name"),
                    new JProperty("totalLikes", 420),
                    new JProperty("totalVisits", 1337),
                    new JProperty("imageUrl", "https://unit.test/imageUrl.jpg"),
                    new JProperty("thumbnailImageUrl", "https://unit.test/thumbnailImageUrl.jpg"),
                    new JProperty("isSecure", false),
                    new JProperty("releaseStatus", "public"),
                    new JProperty("organization", "some organization"),
                    new JProperty("occupants", 4))));

            var api = new WorldApi();
            var result = api.Search(endpoint: WorldGroups.Recent).Result;

            result.Should().HaveCount(1);
            result[0].id.Should().Be("some world id");
            result[0].name.Should().Be("some world name");
            result[0].authorName.Should().Be("some author name");
            result[0].favorites.Should().Be(420);
            result[0].visits.Should().Be(1337);
            result[0].imageUrl.Should().Be("https://unit.test/imageUrl.jpg");
            result[0].thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl.jpg");
            result[0].releaseStatus.Should().Be(ReleaseStatus.Public);
            result[0].organization.Should().Be("some organization");
            result[0].occupants.Should().Be(4);
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusListWorldsResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new WorldApi();
            var result = api.Search().Result;
            result.Should().BeNull();
        }

        [Fact]
        public void CanHandleValidWorldMetadataResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("id", "some world id"),
                new JProperty("metadata", new JObject())));

            var api = new WorldApi();
            var result = api.GetMetadata("some world id").Result;

            result.id.Should().Be("some world id");
            result.metadata.Should().Be(new Metadata());
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusWorldMetadataResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new WorldApi();
            var result = api.GetMetadata("some world id").Result;
            result.Should().BeNull();
        }

        [Fact]
        public void CanHandleValidWorldInstanceResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("id", "some instance id"),
                new JProperty("private", new JArray(
                    new JObject(
                        new JProperty("id", "some private user id"),
                        new JProperty("username", "some private username"),
                        new JProperty("displayName", "some private display name"),
                        new JProperty("currentAvatarImageUrl", "https://unit.test/privateAvatarImageUrl.jpg"),
                        new JProperty("currentAvatarThumbnailImageUrl", "https://unit.test/privateAvatarThumbnailImageUrl.jpg"),
                        new JProperty("tags", new JArray("tag 1", "tag 2")),
                        new JProperty("developerType", "some private developer type"),
                        new JProperty("status", "some private status"),
                        new JProperty("statusDescription", "some private status description"),
                        new JProperty("networkSessionId", "some private network session id")))),
                new JProperty("friends", new JArray(
                    new JObject(
                        new JProperty("id", "some friend user id"),
                        new JProperty("username", "some friend username"),
                        new JProperty("displayName", "some friend display name"),
                        new JProperty("currentAvatarImageUrl", "https://unit.test/friendAvatarImageUrl.jpg"),
                        new JProperty("currentAvatarThumbnailImageUrl", "https://unit.test/friendAvatarThumbnailImageUrl.jpg"),
                        new JProperty("tags", new JArray("tag 1", "tag 2")),
                        new JProperty("developerType", "some friend developer type"),
                        new JProperty("status", "some friend status"),
                        new JProperty("statusDescription", "some friend status description"),
                        new JProperty("networkSessionId", "some friend network session id")))),
                new JProperty("users", new JArray(
                    new JObject(
                        new JProperty("id", "some user id"),
                        new JProperty("username", "some username"),
                        new JProperty("displayName", "some display name"),
                        new JProperty("currentAvatarImageUrl", "https://unit.test/currentAvatarImageUrl.jpg"),
                        new JProperty("currentAvatarThumbnailImageUrl", "https://unit.test/currentAvatarThumbnailImageUrl.jpg"),
                        new JProperty("tags", new JArray("tag 1", "tag 2")),
                        new JProperty("developerType", "some developer type"),
                        new JProperty("status", "some status"),
                        new JProperty("statusDescription", "some status description"),
                        new JProperty("networkSessionId", "some network session id")))),
                new JProperty("name", "some name")));

            var api = new WorldApi();
            var result = api.GetInstance("some world id", "some instance id").Result;

            result.id.Should().Be("some instance id");
            result.privateUsers.Should().HaveCount(1);
            result.privateUsers[0].id.Should().Be("some private user id");
            result.privateUsers[0].username.Should().Be("some private username");
            result.privateUsers[0].displayName.Should().Be("some private display name");
            result.privateUsers[0].currentAvatarImageUrl.Should().Be("https://unit.test/privateAvatarImageUrl.jpg");
            result.privateUsers[0].currentAvatarThumbnailImageUrl.Should().Be("https://unit.test/privateAvatarThumbnailImageUrl.jpg");
            result.privateUsers[0].tags.Should().HaveCount(2);
            result.privateUsers[0].tags[0].Should().Be("tag 1");
            result.privateUsers[0].tags[1].Should().Be("tag 2");
            result.privateUsers[0].developerType.Should().Be("some private developer type");
            result.privateUsers[0].status.Should().Be("some private status");
            result.privateUsers[0].statusDescription.Should().Be("some private status description");
            result.privateUsers[0].networkSessionId.Should().Be("some private network session id");
            result.friends.Should().HaveCount(1);
            result.friends[0].id.Should().Be("some friend user id");
            result.friends[0].username.Should().Be("some friend username");
            result.friends[0].displayName.Should().Be("some friend display name");
            result.friends[0].currentAvatarImageUrl.Should().Be("https://unit.test/friendAvatarImageUrl.jpg");
            result.friends[0].currentAvatarThumbnailImageUrl.Should().Be("https://unit.test/friendAvatarThumbnailImageUrl.jpg");
            result.friends[0].tags.Should().HaveCount(2);
            result.friends[0].tags[0].Should().Be("tag 1");
            result.friends[0].tags[1].Should().Be("tag 2");
            result.friends[0].developerType.Should().Be("some friend developer type");
            result.friends[0].status.Should().Be("some friend status");
            result.friends[0].statusDescription.Should().Be("some friend status description");
            result.friends[0].networkSessionId.Should().Be("some friend network session id");
            result.users.Should().HaveCount(1);
            result.users[0].id.Should().Be("some user id");
            result.users[0].username.Should().Be("some username");
            result.users[0].displayName.Should().Be("some display name");
            result.users[0].currentAvatarImageUrl.Should().Be("https://unit.test/currentAvatarImageUrl.jpg");
            result.users[0].currentAvatarThumbnailImageUrl.Should().Be("https://unit.test/currentAvatarThumbnailImageUrl.jpg");
            result.users[0].tags.Should().HaveCount(2);
            result.users[0].tags[0].Should().Be("tag 1");
            result.users[0].tags[1].Should().Be("tag 2");
            result.users[0].developerType.Should().Be("some developer type");
            result.users[0].status.Should().Be("some status");
            result.users[0].statusDescription.Should().Be("some status description");
            result.users[0].networkSessionId.Should().Be("some network session id");
            result.name.Should().Be("some name");
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusWorldInstanceResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new WorldApi();
            var result = api.GetInstance("some world id", "some instance id").Result;
            result.Should().BeNull();
        }
    }
}
