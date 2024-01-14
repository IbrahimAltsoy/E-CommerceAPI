using E_CommerceAPI.Application.Features.Commands.AppUser.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using E_CommerceAPI.Application.Abstractions.Services;
using MimeKit;
using System.Net.Mail;
using MailKit.Net.Smtp;
using E_CommerceAPI.API.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IMailService _mailService;
        public UsersController(IMediator mediator, IMailService mailService)
        {
            _mediator = mediator;
            _mailService = mailService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpGet]
       
        public async Task<IActionResult> Get()
        {
           await _mailService.SendMailAsync("i.altsoy5@gmail.com", "Merhaba", "Veysel");
            return Ok();
        }



        

    }
}
