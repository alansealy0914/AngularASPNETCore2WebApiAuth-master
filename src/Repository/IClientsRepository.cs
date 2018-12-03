using AngularASPNETCore2WebApiAuth.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularASPNETCore2WebApiAuth.Repository
{
  public interface IClientsRepository
  {
    Task Add(Clients item);
    Task<IEnumerable<Clients>> GetAll();
    Task<Clients> Find(string key);
    Task Remove(string Id);
    Task Update(Clients item);

    bool CheckValidUserKey(string reqkey);
  }
}
