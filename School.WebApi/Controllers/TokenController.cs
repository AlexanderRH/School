using Microsoft.AspNetCore.Mvc;
using School.UnitOfWork;
using School.Models;
using School.WebApi.Authentication;
using System;

namespace School.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unit;

        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unit)
        {
            _tokenProvider = tokenProvider;
            _unit = unit;
        }

        [HttpPost]
        public JsonWebToken Post([FromBody] Person personLogin)
        {
            var user = GetUserByCredentials(personLogin.Email, personLogin.Password);

            if (user == null) throw new UnauthorizedAccessException("No!");

            var lifeInHours = 8;
            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(lifeInHours)),
                Expires_In = lifeInHours * 60
            };

            return token;
        }

        private Person GetUserByCredentials(string email, string password)
        {
            return _unit.Person.ValidaterPerson(email, password);
        }
    }
}
