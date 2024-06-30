using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CS_Player_Info_API.Models
{
    public class PlayerInfoModel
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Role { get; set; } = string.Empty;
        public Nullable<double> Rating { get; set; }
        public string PrimaryWeapon { get; set; } = string.Empty;
    }
}