﻿#nullable disable
using OnlineStore.Common;
using System;
using System.Collections.Generic;

namespace OnlineStore.Entities.Entities
{
    public partial class ShoppingCart : IEntity
    {
        public int MeasureId { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Measure Measure { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}