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
    public async Task RegisterBusiness(string email, string password, string externalId)
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


    [Theory]
    [InlineData("p10f10@test.com", "p10f10@test.com", "4c730f1e-d036-435f-9ecb-3a4fbcbe1111", "p10 f10",
        "p10 f10 family", "Male", "2000-10-10", "0936123456789", "0936123456780",
        1, 2, "address1", "address2", "New York", "USA",
        "LA", "123456")]
    public async Task RegisterParent(string email, string password, string insuranceId, string firstName,
        string lastName, string gender, string dateOfBirth, string primaryPhone, string alternatePhone,
        decimal lat, decimal lng, string address1, string address2, string city, string country,
        string state, string zip)
    {
        SignUpParentInputDto input = new()
        {
            Email = email,
            Password = password,
            InsuranceId = Guid.Parse(insuranceId),
            DateOfBirth = DateTime.Parse(dateOfBirth),
            FirstName = firstName,
            LastName = lastName,
            Gender = gender,
            ContactInfo = new()
            {
                PrimaryPhone = primaryPhone,
                AlternatePhone = alternatePhone,
                Address = new()
                {
                    Address1 = address1,
                    Address2 = address2,
                    City = city,
                    Country = country,
                    Lat = lat,
                    Lng = lng,
                    State = state,
                    Zip = zip
                }
            }
        };

        var json = JsonConvert.SerializeObject(input);
        var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

        var response = await TestClient.PostAsync("/api/Account/RegisterParent", stringContent);

        response.EnsureSuccessStatusCode();

        var serializedResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<SingleResponse<AccessToken>>(serializedResponse);

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(ResponseStatus.Success, result.Status);
        Assert.True(result.Result.Token.Length > 10);
    }
}
