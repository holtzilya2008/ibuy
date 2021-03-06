﻿using System;
using System.Collections.Generic;
using IBuyServer.Infrastructure.DataAccess;

namespace IBuyServer.Domain.Models.Entities
{
    public class PurchaseRecord : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
