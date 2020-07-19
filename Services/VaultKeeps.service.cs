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
    public DTOVaultKeep Get(int Id)
    {
      DTOVaultKeep exists = _repo.GetById(Id);
      if (exists == null) { throw new Exception("Invalid VaultKeep"); }
      return exists;
    }
    public DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
    {
      int id = _repo.Create(newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }

    public DTOVaultKeep Delete(int id)
    {
      DTOVaultKeep exists = Get(id);
      _repo.Delete(id);
      return exists;
    }
    public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }
  }
}