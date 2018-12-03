using AngularASPNETCore2WebApiAuth.Data;
using AngularASPNETCore2WebApiAuth.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularASPNETCore2WebApiAuth.Repository
{
  public class ClientsRepository : IClientsRepository
  {
    ApplicationDbContext _context;
    public ClientsRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task Add(Clients item)
    {
      await _context.Clients.AddAsync(item);
      await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Clients>> GetAll()
    {
      return await _context.Clients.ToListAsync();
    }

    public bool CheckValidUserKey(string reqkey)
    {
      var userkeyList = new List<string>
            {
                "28236d8ec201df516d0f6472d516d72d",
                "38236d8ec201df516d0f6472d516d72c",
                "48236d8ec201df516d0f6472d516d72b"
            };

      if (userkeyList.Contains(reqkey))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public async Task<Clients> Find(string key)
    {
      return await _context.Clients
          .Where(e => e.Phone.Equals(key))
          .SingleOrDefaultAsync();
    }

    public async Task Remove(string Id)
    {
      var itemToRemove = await _context.Clients.SingleOrDefaultAsync(r => r.Phone == Id);
      if (itemToRemove != null)
      {
        _context.Clients.Remove(itemToRemove);
        await _context.SaveChangesAsync();
      }
    }

    public async Task Update(Clients item)
    {
      var itemToUpdate = await _context.Clients.SingleOrDefaultAsync(r => r.Phone == item.Phone);
      if (itemToUpdate != null)
      {
        itemToUpdate.FirstName = item.FirstName;
        itemToUpdate.LastName = item.LastName;
        itemToUpdate.IsOwnerMember = item.IsOwnerMember;
        itemToUpdate.Company = item.Company;
        itemToUpdate.JobTitle = item.JobTitle;
        itemToUpdate.Email = item.Email;
        itemToUpdate.Phone = item.Phone;
        itemToUpdate.TransDate = item.TransDate;
        itemToUpdate.MaturityDate = item.MaturityDate;
        await _context.SaveChangesAsync();
      }
    }
  }
}
