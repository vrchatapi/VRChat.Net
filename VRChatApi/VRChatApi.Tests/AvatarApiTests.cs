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
    public class AvatarApiTests
    {
        [Fact]
        public void CanHandleValidAvatarResponse()
        {
            MockHttpMessageHandler.SetResponse(new JObject(
                new JProperty("id", "avtr_652ecc45-e561-4617-806f-4bfe9188f6e1"),
                new JProperty("name", "Unit Test"),
                new JProperty("description", "Unit Test 2"),
                new JProperty("authorId", "usr_03eb24fe-0e42-4fac-b734-1e0beaea0309"),
                new JProperty("authorName", "Unit Tester"),
                new JProperty("tags", new JArray()),
                new JProperty("assetUrl",
                    "https://unit.test/assetUrl"),
                new JProperty("assetUrlObject", new JObject()),
                new JProperty("imageUrl",
                    "https://unit.test/imageUrl"),
                new JProperty("thumbnailImageUrl",
                    "https://unit.test/thumbnailImageUrl"),
                new JProperty("releaseStatus", "public"),
                new JProperty("version", 4),
                new JProperty("featured", false),
                new JProperty("unityPackages",
                    new JArray(
                        new JObject(
                            new JProperty("id", "unp_6e3fd8ac-cbc1-454b-97ca-af2f7d62e88e"),
                            new JProperty("assetUrl",
                                "https://unit.test/assetUrl"),
                            new JProperty("unityVersion", "5.6.3p1"),
                            new JProperty("unitySortNumber", 50603010),
                            new JProperty("assetVersion", 1),
                            new JProperty("platform", "standalonewindows"),
                            new JProperty("created_at", "2018-07-23T16:35:24.397Z")))),
                new JProperty("unityPackageUpdated", false),
                new JProperty("unityPackageUrl", ""),
                new JProperty("unityPackageUrlObject", new JObject()),
                new JProperty("created_at", "2018-01-30T00:43:37.452Z"),
                new JProperty("updated_at", "2018-07-23T16:35:24.482Z")));

            var api = new AvatarApi();
            var result = api.GetById("avtr_652ecc45-e561-4617-806f-4bfe9188f6e1").Result;
            result.id.Should().Be("avtr_652ecc45-e561-4617-806f-4bfe9188f6e1");
            result.assetUrl.Should()
                .Be("https://unit.test/assetUrl");
            result.authorId.Should().Be("usr_03eb24fe-0e42-4fac-b734-1e0beaea0309");
            result.authorName.Should().Be("Unit Tester");
            result.description.Should().Be("Unit Test 2");
            result.featured.Should().BeFalse();
            result.imageUrl.Should()
                .Be("https://unit.test/imageUrl");
            result.name.Should().Be("Unit Test");
            result.releaseStatus.Should().Be("public");
            result.tags.Should().BeEmpty();
            result.thumbnailImageUrl.Should().Be("https://unit.test/thumbnailImageUrl");
            result.unityPackageUpdated.Should().BeFalse();
            result.unityPackageUrl.Should().BeEmpty();
            result.unityPackages.Should().HaveCount(1);
            result.unityPackages[0].assetUrl.Should().Be("https://unit.test/assetUrl");
            result.unityPackages[0].assetVersion.Should().Be(1);
            result.unityPackages[0].created_at.Should().Be(new DateTime());
            result.unityPackages[0].id.Should().Be("unp_6e3fd8ac-cbc1-454b-97ca-af2f7d62e88e");
            result.unityPackages[0].platform.Should().Be("standalonewindows");
            result.unityPackages[0].unitySortNumber.Should().Be(50603010);
            result.unityPackages[0].unityVersion.Should().Be("5.6.3p1");
            result.version.Should().Be(4);
        }

        [Fact]
        public void CanHandleInternalServerErrorHttpStatusAvatarResponse()
        {
            MockHttpMessageHandler.SetResponse(string.Empty, HttpStatusCode.InternalServerError);
            var api = new AvatarApi();
            var result = api.GetById("avtr_652ecc45-e561-4617-806f-4bfe9188f6e1").Result;
            result.Should().BeNull();
        }
    }
}
