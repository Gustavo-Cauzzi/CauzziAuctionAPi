using CauzziAuction.API.Contracts;
using CauzziAuction.API.Repositories;
using CauzziAuction.API.Repositories.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CauzziAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly IUserRepository _userRepository;
    public AuthenticationUserAttribute(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64String(token);

            var userExists = _userRepository.ExistsUserWithEmail(email);

            if (userExists == false)
            {
                throw new Exception("E-mail not valid");
            }
        }
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string TokenOnRequest (HttpContext context)
    {
        var authorization = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authorization))
        {
            throw new Exception("Invalid Token");
        }

        return authorization["Bearer ".Length..];
    }

    private string FromBase64String (string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
