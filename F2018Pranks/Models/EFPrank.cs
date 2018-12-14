using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F2018Pranks.Models
{
    public class EFPrank : IMockPrank
    {
        public DbModel db = new DbModel();

        public IQueryable<Prank> Pranks { get { return db.Pranks; } }

        public Prank Save(Prank prank)
        {
            throw new NotImplementedException();
        }
    }
}