using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    // internal IEnumerable<Keep> Get()
    // {
    //   string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
    //   return _db.Query<Keep>(sql);
    // }

    internal IEnumerable<Keep> GetAll()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal IEnumerable<Keep> GetKeepsByUserId(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @userId";
      return _db.Query<Keep>(sql, new { userId });
    }

    internal Keep GetById(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    internal bool EditKeepViews(Keep editKeep)
    {
      string sql = @"
      UPDATE keeps
      SET
      views = @Views
      WHERE id = @Id";
      int affectedRows = _db.Execute(sql, editKeep);
      return affectedRows == 1;
    }

    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (userId, name, description, img,
      isPrivate, views, shares, keeps)
      VALUES
      (@UserId, @Name, @Description, @Img, 
      @IsPrivate, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID()";
      newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
      return newKeep;
    }

    internal bool EditKeepShares(Keep editKeep)
    {
      string sql = @"
      UPDATE keeps
      SET
      shares = @Shares
      WHERE id = @Id";
      int affectedRows = _db.Execute(sql, editKeep);
      return affectedRows == 1;
    }

    internal bool EditKeepKeeps(Keep editKeep)
    {
      string sql = @"
      UPDATE keeps
      SET
      keeps = @Keeps
      WHERE id = @Id";
      int affectedRows = _db.Execute(sql, editKeep);
      return affectedRows == 1;
    }

    // internal bool EditKeepStats(Keep keepToUpdate)
    // {
    //   string sql = @"
    //   UPDATE keeps
    //   SET
    //   views = @Views,
    //   shares = @Shares,
    //   keeps = @Keeps
    //   WHERE id = @Id";
    //   int affectedRows = _db.Execute(sql, keepToUpdate);
    //   return affectedRows == 1;
    // }

    // internal bool Edit(Keep foundKeep, string userId)
    // {
    //   string sql = @"
    //   UPDATE keeps
    //   SET
    //     name = @Name,
    //     description = @Description,
    //     img = @Img,
    //     isPrivate = @IsPrivate,
    //     views = @Views,
    //     shares = @Shares,
    //     keeps = @Keeps
    //   WHERE id = @Id
    //   AND userId = @UserId;";
    //   int affectedRows = _db.Execute(sql, foundKeep);
    //   return affectedRows == 1;
    // }

    internal bool Edit(Keep foundKeep, string userId)
    {
      foundKeep.UserId = userId;
      string sql = @"
      UPDATE keeps
      SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = @IsPrivate,
        views = @Views,
        shares = @Shares,
        keeps = @Keeps
      WHERE id = @Id
      AND userId = @UserId;";
      int affectedRows = _db.Execute(sql, foundKeep);
      return affectedRows == 1;
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM keeps WHERE id = @id AND userId = @userId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }
  }
}