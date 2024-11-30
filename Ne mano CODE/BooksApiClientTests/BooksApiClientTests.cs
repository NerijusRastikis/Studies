using Moq;
using Moq.Protected;
using System.Net.Http;
using System.Net;
using AutoFixture.Xunit2;
using System.Runtime.CompilerServices;
using Castle.Core.Logging;
using P103_ExternalApi.Services;
using Microsoft.Extensions.Logging;
using P103_ExternalApi.Dtos;
using System.Text.Json;

namespace BooksApiClientTests
{
    public class BooksApiClientTests
    {
        [Theory, AutoData]
        public async void BooksApiClient_GetBooks_200_Success(IEnumerable<BookApiResult> books, string connectionId)
        {
            var loggerMock = new Mock<ILogger<BooksApiClient>>();

            //Arange
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            var httpclient = new HttpClient(httpMessageHandlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
            var sut = new BooksApiClient(loggerMock.Object, httpclient);


            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = (HttpStatusCode)200, //HttpStatusCode.OK
                    Content = new StringContent(JsonSerializer.Serialize(books))
                });
            //Act
            var result = await sut.GetBooks(connectionId);

            //Assert
            Assert.NotNull(result);
        }
    }
}