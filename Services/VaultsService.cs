using System;
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

    internal object GetByUserId(string userId)
    {
      throw new NotImplementedException();
    }

    internal object GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal object Create(Vault newVault)
    {
      throw new NotImplementedException();
    }

    internal object Edit(Vault vaultToUpdate, string userId)
    {
      throw new NotImplementedException();
    }
  }
}