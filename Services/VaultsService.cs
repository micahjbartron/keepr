using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Vault> GetByUserId(string userId)
    {
      return _repo.GetVaultsByUserId(userId);
    }

    internal Vault GetById(int id)
    {
      Vault foundVault = _repo.GetById(id);
      if (foundVault == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundVault;
    }

    internal IEnumerable<Vault> Get()
    {
      return _repo.GetAll();
    }

    internal object Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    // internal object Edit(Vault vaultToUpdate, string userId)
    // {
    //   Vault foundVault = GetById(vaultToUpdate.Id);
    //   if(foundVault.)
    // }

    internal object Delete(int id, string userId)
    {
      Vault foundVault = GetById(id);
      if (foundVault.UserId != userId)
      {
        throw new Exception("This is not your Vault!");
      }
      if (_repo.Delete(id, userId))
      {
        return "Successfully Deleted";
      }
      throw new Exception("Something has gone wrong");
    }
  }
}