using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace WebApplication02.Tests;

public class WebApplicationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public WebApplicationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetRoot_ReturnsExpectedMessage()
    {
        var response = await _client.GetAsync("/");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();

        Assert.Equal(
            "Hello World!.. This is a new feature.",
            content);
    }
}
