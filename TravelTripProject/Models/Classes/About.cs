using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class About
    {
        [Key]
        public int ID { get; set; }
        public string ImgUrl { get; set; }
        public string Aciklama { get; set; }

    }
}