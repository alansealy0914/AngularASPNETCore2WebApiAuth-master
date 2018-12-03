using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularASPNETCore2WebApiAuth.Models.Entities
{
  public class Clients
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsOwnerMember { get; set; }
    public string Company { get; set; }
    public string Email { get; set; }
    public string NAICS { get; set; }
    public string JobTitle { get; set; }
    public string Phone { get; set; }
    public string TaxId { get; set; }
    public DateTime TransDate { get; set; }
    public DateTime MaturityDate { get; set; }
  }
}

