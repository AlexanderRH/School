using Microsoft.IdentityModel.Tokens;
using School.Models;
using System;

namespace School.WebApi.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(Person person, DateTime expiry);

        TokenValidationParameters GetValidatorParameters();
    }
}
