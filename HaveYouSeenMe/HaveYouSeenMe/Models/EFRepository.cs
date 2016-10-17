using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaveYouSeenMe.Models
{
    public class EFRepository : IRepository
    {
        public Pet GetPetByName(string name)
        {
            Pet p = null;
            using (var db = new EntitiesConnection())
            {
                p = db.Pets.SingleOrDefault(x => x.PetName.Contains(name));
            }

            return p;
        }
    }
}