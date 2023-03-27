using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NiceaBurger.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Kullanici class
public class Kullanici : IdentityUser
{
    public List<SiparisUrun> SiparisUrunler { get; set; } = new List<SiparisUrun>();

}

