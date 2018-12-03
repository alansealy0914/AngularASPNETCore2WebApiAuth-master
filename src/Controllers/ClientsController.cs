using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AngularASPNETCore2WebApiAuth.Data;
using AngularASPNETCore2WebApiAuth.Models.Entities;
using AngularASPNETCore2WebApiAuth.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AngularASPNETCore2WebApiAuth.Controllers
{
  [Route("api/[controller]")]
  public class ClientsController : Controller
  {
    public IClientsRepository ClientsRepo { get; set; }

    public ClientsController(IClientsRepository _repo)
    {
      ClientsRepo = _repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var clientList = await ClientsRepo.GetAll();
      return Ok(clientList);
    }

    [HttpGet("{id}", Name = "GetClients")]
    public async Task<IActionResult> GetById(string id)
    {
      var item = await ClientsRepo.Find(id);
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Clients item)
    {
      if (item == null)
      {
        return BadRequest();
      }
      await ClientsRepo.Add(item);
      return CreatedAtRoute("GetClients", new { Controller = "Clients", id = item.Phone }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Clients item)
    {
      if (item == null)
      {
        return BadRequest();
      }
      var clientObj = await ClientsRepo.Find(id);
      if (clientObj == null)
      {
        return NotFound();
      }
      await ClientsRepo.Update(item);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
      await ClientsRepo.Remove(id);
      return NoContent();
    }
  }
}

