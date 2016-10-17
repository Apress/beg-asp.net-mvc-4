using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaveYouSeenMe.Models
{
    public interface IRepository
    {
        Pet GetPetByName(string name);
    }
}