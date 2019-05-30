using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    
    public class Project1 : DbContext
    {
        public DbSet<DictCities> DictCities { get; set; }
    }
    [Table("DictCities", Schema = "public")]
    public class DictCities : DbContext
    {
        [Column("Title")]
        public string Title { get; set; }
        [Column("Code")]
        public string Code { get; set; }
        [Column("id")]
        public Guid ID { get; set; }
    }

}