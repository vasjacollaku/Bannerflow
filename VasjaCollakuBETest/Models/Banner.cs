using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VasjaCollakuBETest.Models
{
  public class Banner
    {
     public int Id { get; set; }
     [AllowHtml]
     public string Html { get; set; }
     public DateTime Created { get; set; }
     public DateTime? Modified { get; set; }
    }

    public class BannerDBContext : DbContext
    {
        public DbSet<Banner> Banners { get; set; }
    }
}


