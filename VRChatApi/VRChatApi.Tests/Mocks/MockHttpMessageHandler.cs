using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VRChatApi.Tests.Mocks
{
    static class MockHttpMessageHandler
    {
        public static void SetResponse(string content, HttpStatusCode statusCode)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content)
                });
            Global.HttpClient = new HttpClient(mockMessageHandler.Object);
            Global.HttpClient.BaseAddress = new Uri("https://unit.test");
        }

        public static void SetResponse(string content) => SetResponse(content, HttpStatusCode.OK);

        public static void SetResponse(JToken mockedResponse) => SetResponse(mockedResponse.ToString(Formatting.Indented), HttpStatusCode.OK);
    }
}
