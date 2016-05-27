﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AssetHub.Models
{
    public partial class Room
    {
        public class Validator
        {
            public const string NAME_REQUIRED = "Room name is required";

            public const string NAME_DUPLICATE = "Duplicate room names found";

            public static string ValidateName(string name)
            {
                return string.IsNullOrWhiteSpace(name) ? NAME_REQUIRED : null;
            }

            public static string ValidateNames(ICollection<string> names)
            {
                var count = (from n in names
                             select n.ToLower()).Distinct().Count();

                return count != names.Count ? NAME_DUPLICATE : null;
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }

}