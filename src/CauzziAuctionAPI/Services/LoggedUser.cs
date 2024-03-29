﻿using CauzziAuction.API.Contracts;
using CauzziAuction.API.Entities;

namespace CauzziAuction.API.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUserRepository _userRepository;

    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository userRepository)
    {
        _contextAccessor = httpContext;
        _userRepository = userRepository;
    }
    public User User()
    {
        var token = TokenOnRequest();
        var email = FromBase64String(token);
        return _userRepository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var authorization = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authorization["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
