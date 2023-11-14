using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.API.DTOs.Ticket;
using TicketSystem.Core.Entities;
using TicketSystem.Core.Services;
using TicketSystem.Core.Services.Interfaces;

namespace TicketSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        protected readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        
        [HttpGet]
        [Authorize(Policy = "CanRead")]
         public async Task<IActionResult>Get()
         {
             var tickets = await _ticketService.GetAllTickets();
             var ticketsDto = tickets.Select(t => new TicketResponseDto
             {
                 Id = t.Id,
                 Subject = t.Subject,
                 Description = t.Description,
                 CreationDate = t.CreationDate,
                 Status = t.Status,
                 CategoryId = t.CategoryId,
                 UserId = t.UserId
             });

             return Ok(ticketsDto);
         }

         [HttpGet("{id}")]
         [Authorize(Policy = "CanRead")]
         public async Task<IActionResult> Get(Guid id)
         {
             var ticket = await _ticketService.GetById(id);

             if (ticket == null)
                 return BadRequest($"the ticket with id: {id} could not be found");

             var ticketDto = new TicketResponseDto
             {
                 Id = ticket.Id,
                 Subject = ticket.Subject,
                 Description = ticket.Description,
                 CreationDate = ticket.CreationDate,
                 Status = ticket.Status,
                 CategoryId = ticket.CategoryId,
                 UserId = ticket.UserId

             };

             return Ok(ticketDto);
         }

         [HttpPost]
         [Authorize(Policy = "CanEdit")]
         public async Task<IActionResult> Add(TicketResponseDto ticketDto)
         {
             if (!ModelState.IsValid)
                 return BadRequest(ModelState.Values);

             var ticket = new Ticket
             {
                 Id = ticketDto.Id,
                 Subject = ticketDto.Subject,
                 Description = ticketDto.Description,
                 CreationDate = ticketDto.CreationDate,
                 Status = ticketDto.Status,
                 CategoryId = ticketDto.CategoryId,
                 UserId = ticketDto.UserId
             };

             await _ticketService.AddTicket(ticket);
             return Ok(ticket);
         }
         
         [HttpPut()]
         [Authorize(Policy = "CanUpdate")]
         public async Task<IActionResult> Update(TicketResponseDto ticketDto)
         {
             if (!ModelState.IsValid)
                 return BadRequest(ModelState.Values);

             var ticket = await _ticketService.GetById(ticketDto.Id);
             
             if(ticket == null)
                 return BadRequest($"the ticket with id: {ticketDto.Id} could not be found");

             ticket.Id = ticketDto.Id;
             ticket.Description = ticketDto.Description;
             ticket.CategoryId = ticketDto.CategoryId;
             ticket.UserId = ticketDto.UserId;
             ticket.Status = ticketDto.Status;
             ticket.Subject = ticketDto.Subject;
             ticket.CreationDate = ticketDto.CreationDate;
             
             await _ticketService.UpdateTicket(ticket);
             return Ok(ticket);
         }

         [HttpDelete("{id}")]
         [Authorize(Policy = "CanDelete")]
         public async Task<IActionResult> Delete(Guid id)
         {
             if (!ModelState.IsValid)
                 return BadRequest(ModelState.Values);
             
             var ticket = await _ticketService.GetById(id);
             
             if(ticket == null)
                 return BadRequest($"the ticket with id: {id} could not be found");

             await _ticketService.DeleteTicket(ticket);
             return Ok(ticket);

         }
    }
}
