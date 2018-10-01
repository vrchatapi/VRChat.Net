using System;
using System.Linq;
using System.Text;
using FluentAssertions;
using VRChatApi.Endpoints;
using Xunit;

namespace VRChatApi.Tests
{
    public class VRChatApiTests
    {
        [Fact]
        public void SetsBaseAddressForHttpClient()
        {
            // Force set HttpClient to null, since other unit tests will have this set this to the mocked version
            Global.HttpClient = null;
            var api = new VRChatApi("some username", "some password");
            Global.HttpClient.BaseAddress.Should().Be("https://api.vrchat.cloud/api/1/");
        }

        [Fact]
        public void SetsCorrectDefaultAuthorizationHeader()
        {
            var api = new VRChatApi("some username", "some password");
            Global.HttpClient.DefaultRequestHeaders.Authorization.Should().NotBeNull();
            Global.HttpClient.DefaultRequestHeaders.Authorization.Scheme.Should().Be("Basic");
            Global.HttpClient.DefaultRequestHeaders.Authorization.Parameter.Should().Be(Convert.ToBase64String(Encoding.UTF8.GetBytes("some username:some password")));
        }

        [Fact]
        public void InstantiatesDependencies()
        {
            var api = new VRChatApi("some username", "some password");
            api.AvatarApi.Should().NotBeNull();
            api.FriendsApi.Should().NotBeNull();
            api.ModerationsApi.Should().NotBeNull();
            api.RemoteConfig.Should().NotBeNull();
            api.UserApi.Should().NotBeNull();
            api.WorldApi.Should().NotBeNull();
        }
    }
}
