﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using OnlineStore.Common;
using System;
using System.Collections.Generic;

namespace OnlineStore.Entities.Entities
{
    public partial class ProductMeasureView : IEntity
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int MeasureId { get; set; }
    }
}