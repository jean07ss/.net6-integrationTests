using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace ForecastsTests.Integration;

[TestFixture]
public class GoodWeatherForecastController
{
    private HttpClient _httpClient;
    public GoodWeatherForecastController()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }
    
    [Test]
    public async Task GetDefaultForecast()
    {
        // Arrange
        var request = "/GoodWeatherForecast/default-forecast";
        
        // Act
        var response = await _httpClient.GetAsync(request);
        var stringResult = await response.Content.ReadAsStringAsync();
            
        // Assert
        Assert.AreEqual("Good weather forecast", stringResult);
        Assert.AreEqual(200, (int)response.StatusCode);
        Assert.AreEqual("OK", response.ReasonPhrase);
    }
    
    [Test]
    public async Task GetDefaultTemperature()
    {
        // Arrange
        var request = "/GoodWeatherForecast/temperature";
        
        // Act
        var response = await _httpClient.GetAsync(request);
        var stringResult = await response.Content.ReadAsStringAsync();
            
        // Assert
        Assert.AreEqual(77, int.Parse(stringResult));
        Assert.AreEqual(200, (int)response.StatusCode);
        Assert.AreEqual("OK", response.ReasonPhrase);
    }
    
    [Test]
    public async Task MethodName_WithWhat_ShouldDoWhat()
    {
        // Arrange
        var request = "/GoodWeatherForecast/temperature?n1=1&n2=2";
        
        // Act
        var response = await _httpClient.GetAsync(request);
        var stringResult = await response.Content.ReadAsStringAsync();
            
        // Assert
        Assert.AreEqual(3, int.Parse(stringResult));
        Assert.AreEqual(200, (int)response.StatusCode);
        Assert.AreEqual("OK", response.ReasonPhrase);
    }
}