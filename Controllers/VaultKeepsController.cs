using System;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _service;
    public VaultKeepsController(VaultKeepsService service)
    {
      _service = service;
    }
    [HttpPost]
    [Authorize]
    public ActionResult<DTOVaultKeep> post([FromBody] DTOVaultKeep newDTOVaultKeep)
    {
      try
      {
        return Ok(_service.Create(newDTOVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<DTOVaultKeep> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}