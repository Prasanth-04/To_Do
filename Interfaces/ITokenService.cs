using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do.Entity;

namespace To_Do.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
