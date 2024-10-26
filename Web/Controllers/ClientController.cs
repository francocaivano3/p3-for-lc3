using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Repositories;
using Infrastructure;
using Application.Services;


namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("client/{clientId}/events/{eventId}/buy-ticket")]
        public IActionResult BuyTicket(int clientId, int eventId)
        {
           var result = _clientService.BuyTicket(clientId, eventId);

            if (result == true) //arreglo temporal
            {
                return Ok($"Ticket purchased succesfully, {result}");
            }
            else
            {
                return BadRequest($"Failed to purchase ticket, {result}");
            }
        }

        [HttpGet("client/{clientId}/get-tickets")]
        public IActionResult GetMyTickets(int clientId)
        {
            var tickets = _clientService.GetAllMyTickets(clientId);

            if (tickets == null)
            {
                return NotFound("No tickets found for the client");
            }

            return Ok(tickets);
        }

        [HttpGet("client/{clientId}/get-client")]
        public IActionResult GetClientById(int clientId) 
        {
            var client = _clientService.GetClientById(clientId);
            if (client == null)
            {
                return NotFound("Client not found");
            }
            return Ok(client);
        }

    }
}
