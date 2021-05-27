using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Price { get; set; }
    }
}
