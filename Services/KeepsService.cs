using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.GetAll();
    }
    internal IEnumerable<Keep> GetByUserId(string userId)
    {
      return _repo.GetKeepsByUserId(userId);
    }
    internal Keep GetById(int id)
    {
      Keep foundKeep = _repo.GetById(id);
      if (foundKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundKeep;
    }
    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }
    internal Keep Edit(Keep editKeep, string userId)
    {
      Keep foundKeep = GetById(editKeep.Id);
      if (foundKeep.Views < editKeep.Views)
      {
        if (_repo.EditKeepViews(editKeep))
        {
          foundKeep.Views = editKeep.Views;
          return foundKeep;
        }
        throw new Exception("didn't increas numbers");
      }
      if (foundKeep.Shares < editKeep.Shares)
      {
        if (_repo.EditKeepShares(editKeep))
        {
          foundKeep.Shares = editKeep.Shares;
          return foundKeep;
        }
        throw new Exception("didn't increas numbers");
      }
      if (foundKeep.Keeps < editKeep.Keeps)
      {
        if (_repo.EditKeepKeeps(editKeep))
        {
          foundKeep.Keeps = editKeep.Keeps;
          return foundKeep;
        }
        throw new Exception("didn't increase numbers");
      }
      if (foundKeep.UserId == userId && _repo.Edit(editKeep, userId))
      {
        return editKeep;
      }
      throw new Exception("you can't edit that, its not your keep");

    }


    internal string Delete(int id, string userId)
    {
      Keep foundKeep = GetById(id);
      if (foundKeep.UserId != userId)
      {
        throw new Exception("this is not your keep!");
      }
      if (_repo.Delete(id, userId))
      {
        return "Successfully Deleted";
      }
      throw new Exception("somehting has gone terribly wrong");
    }


  }
}
