﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace RGB.Back.Models;

public partial class Game
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Introduction { get; set; }

    public string Description { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public int? Price { get; set; }

    public string Cover { get; set; }

    public int DeveloperId { get; set; }

    public int? MaxPercent { get; set; }

    public string Video { get; set; }

    public virtual ICollection<BanGame> BanGames { get; set; } = new List<BanGame>();

    public virtual CartItem CartItem { get; set; }

    public virtual CartItem CartItem { get; set; }

    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Developer Developer { get; set; }

    public virtual ICollection<DiscountItem> DiscountItems { get; set; } = new List<DiscountItem>();

    public virtual ICollection<Dlc> DlcDlcNavigations { get; set; } = new List<Dlc>();

    public virtual ICollection<Dlc> DlcMainGames { get; set; } = new List<Dlc>();

    public virtual ICollection<GameTag> GameTags { get; set; } = new List<GameTag>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual OderDetail OderDetail { get; set; }

    public virtual ICollection<WishListe> WishListes { get; set; } = new List<WishListe>();
}