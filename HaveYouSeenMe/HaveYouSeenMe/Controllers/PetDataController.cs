using HaveYouSeenMe.Models;
using HaveYouSeenMe.Models.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HaveYouSeenMe.Controllers
{
    public class PetDataController : ApiController
    {
        [HttpGet]
        public Pet Info(string name)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(name));
            var pm = new PetManagement();
            var pet = pm.GetByName(name);
            return pet;
        }
    }
}
