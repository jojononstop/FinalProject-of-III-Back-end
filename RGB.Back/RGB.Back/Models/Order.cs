﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace RGB.Back.Models;

public partial class Order
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public string PaymentMethod { get; set; }

    public int TotalAmount { get; set; }

    public string Status { get; set; }

    public int? DiscountAmount { get; set; }

    public string Message { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual OderDetail OderDetail { get; set; }
}