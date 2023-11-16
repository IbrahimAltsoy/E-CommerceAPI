﻿using U=E_CommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Google.Apis.Auth;
using E_CommerceAPI.Application.Abstractions.Token;
using E_CommerceAPI.Application.DTOs;
using E_CommerceAPI.Application.Abstractions.Services;

namespace E_CommerceAPI.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly IAuthService _authService;
        readonly ITokenHandler _tokenHandler;


        public GoogleLoginCommandHandler(ITokenHandler tokenHandler, IAuthService authService)
        {
           
            _authService = authService;
            _tokenHandler = tokenHandler;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
           var token = await _authService.GoogleLoginAsync(request.IdToken, 300);
            return new()
            {
                Token = token
            };
        }
    }
}
