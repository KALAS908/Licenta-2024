﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using OnlineStore.Common;
using System;
using System.Collections.Generic;

namespace OnlineStore.Entities.Entities
{
    public partial class ProductMeasure : IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public int MeasureId { get; set; }

        public virtual Measure Measure { get; set; }
        public virtual Product Product { get; set; }
    }
}