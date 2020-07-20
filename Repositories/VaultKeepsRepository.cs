

using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal DTOVaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id";
      return _db.QueryFirstOrDefault<DTOVaultKeep>(sql, new { id });
    }
    internal IEnumerable<VaultKeepViewModel> GetByUser(string userId)
    {
      string sql = @"
       SELECT
       k.*,
       vk.id as vaultkeepId
       FROM vaultkeeps vk
       INNER JOIN keeps k on k.id = vk.keepId
       WHERE(vk.vaultId = @userId;";
      return _db.Query<VaultKeepViewModel>(sql, new { userId });
    }

    internal bool hasRelationship(DTOVaultKeep newVaultKeep)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE keepId = @KeepId AND userId = @UserId";
      var found = _db.QueryFirstOrDefault<DTOVaultKeep>(sql, newVaultKeep);
      return found != null;
    }

    internal DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (userid, vaultid, keepid)
      VALUES 
      (@UserId, VaultId, KeepId);
      SELECT LAST_INSERT_ID();";
      newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }



    internal bool Delete(int id, string user)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id AND user = @user LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, user });
      return affectedRows == 1;
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT
        k.*,
        vk.id as vaultkeepId
      FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE(vk.vaultId = @id)
      ";
      return _db.Query<VaultKeepViewModel>(sql, new { id });
    }
  }
}