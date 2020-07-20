using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<VaultKeepViewModel> Get(string userId)
    {
      return _repo.GetByUser(userId);
    }
    // public DTOVaultKeep Get(int Id)
    // {
    //   DTOVaultKeep exists = _repo.GetById(Id);
    //   if (exists == null)
    //   {
    //     throw new Exception("Invalid vaultkeep");
    //   }
    //   return exists;
    // }
    public DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
    {
      if (_repo.hasRelationship(newVaultKeep))
      {
        throw new Exception("That's already in your vault");
      }
      return _repo.Create(newVaultKeep);
    }

    private DTOVaultKeep GetById(int id)
    {
      var found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    public DTOVaultKeep Delete(string user, int id)
    {
      var found = GetById(id);
      if (found.UserId != user)
      {
        throw new UnauthorizedAccessException("this is not your keep");
      }
      if (_repo.Delete(id, user))
      {
        return found;
      }
      throw new Exception("oops");
    }



    public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }
  }
}