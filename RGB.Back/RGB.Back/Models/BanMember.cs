﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace RGB.Back.Models;

public partial class BanMember
{
    public int Id { get; set; }

    public int Member1Id { get; set; }

    public int Member2Id { get; set; }

    public string Content { get; set; }

    public DateOnly Date { get; set; }

    public int? AdminId { get; set; }

    public DateTime? StatusTime { get; set; }

    public bool? Status { get; set; }

    public virtual Admin Admin { get; set; }

    public virtual Member Member1 { get; set; }

    public virtual Member Member2 { get; set; }
}