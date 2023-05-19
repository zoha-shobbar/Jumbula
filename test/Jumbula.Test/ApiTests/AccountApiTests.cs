using Jumbula.Application.Dtos;
using Jumbula.Application.Dtos.Jwt;
using Jumbula.Application.Responses;
using Jumbula.Test.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumbula.Test.ApiTests;
public class AccountApiTests : BaseTest
{
    [Theory]
    [InlineData("b10@test.com", "b1@test.com", "a0762acd-8f24-417e-86e0-41d70e9d6b7d")]
    public async Task RegisterParent(string email, string password, string externalId)
    {
        SignUpBusinessInputDto input = new()
        {
            Email = email,
            ExternalId = Guid.Parse(externalId),
            Password = password
        };

        var json = JsonConvert.SerializeObject(input);
        var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

        var response = await TestClient.PostAsync("/api/Account/RegisterBusiness", stringContent);

        response.EnsureSuccessStatusCode();

        var serializedResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<SingleResponse<AccessToken>>(serializedResponse);

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(ResponseStatus.Success, result.Status);
        Assert.True(result.Result.Token.Length > 10);
    }


    //[Theory]
    //[InlineData("p1f1@test.com", "p1f1@test.com", "a0762acd-8f24-417e-86e0-41d70e9d6b7d")]
    //public async Task RegisterBusiness(string email, string password, string externalId)
    //{
    //    SignUpBusinessInputDto input = new()
    //    {
    //        Email = email,
    //        ExternalId = Guid.Parse(externalId),
    //        Password = password
    //    };

    //    var json = JsonConvert.SerializeObject(input);
    //    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

    //    var response = await TestClient.PostAsync("/api/Account/RegisterBusiness", stringContent);

    //    response.EnsureSuccessStatusCode();

    //    var serializedResponse = await response.Content.ReadAsStringAsync();
    //    var result = JsonConvert.DeserializeObject<SingleResponse<AccessToken>>(serializedResponse);

    //    Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    //    Assert.Equal(ResponseStatus.Success, result.Status);
    //    Assert.True(result.Result.Token.Length > 10);
    //}
}
