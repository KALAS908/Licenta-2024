﻿#nullable disable
using OnlineStore.Common;
using System;
using System.Collections.Generic;

namespace OnlineStore.Entities.Entities
{
    public partial class Country : IEntity
    {
        public Country()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}