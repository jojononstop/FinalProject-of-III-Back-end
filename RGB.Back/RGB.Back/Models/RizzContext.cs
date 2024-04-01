﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RGB.Back.Models;

public partial class RizzContext : DbContext
{
    public RizzContext(DbContextOptions<RizzContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AttachedComment> AttachedComments { get; set; }

    public virtual DbSet<BanGame> BanGames { get; set; }

    public virtual DbSet<BanMember> BanMembers { get; set; }

    public virtual DbSet<Board> Boards { get; set; }

    public virtual DbSet<BonusItem> BonusItems { get; set; }

    public virtual DbSet<BonusProduct> BonusProducts { get; set; }

    public virtual DbSet<BonusProductType> BonusProductTypes { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<Collection> Collections { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountItem> DiscountItems { get; set; }

    public virtual DbSet<Dlc> Dlcs { get; set; }

    public virtual DbSet<EcpayOrder> EcpayOrders { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameTag> GameTags { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<LinepayOrder> LinepayOrders { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberTag> MemberTags { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TransferMethod> TransferMethods { get; set; }

    public virtual DbSet<TransferPayment> TransferPayments { get; set; }

    public virtual DbSet<TransferRefund> TransferRefunds { get; set; }

    public virtual DbSet<WishListe> WishListes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.Property(e => e.Account)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<AttachedComment>(entity =>
        {
            entity.ToTable("AttachedComment");

            entity.Property(e => e.Comment).IsRequired();
            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MainComment).WithMany(p => p.AttachedComments)
                .HasForeignKey(d => d.MainCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttachedComment_Comments");

            entity.HasOne(d => d.Member).WithMany(p => p.AttachedComments)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttachedComment_Members");
        });

        modelBuilder.Entity<BanGame>(entity =>
        {
            entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.StatusTime).HasColumnType("datetime");

            entity.HasOne(d => d.Admin).WithMany(p => p.BanGames)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK_BanGames_Admins");

            entity.HasOne(d => d.Game).WithMany(p => p.BanGames)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BanGames_Games");

            entity.HasOne(d => d.Member).WithMany(p => p.BanGames)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BanGames_Members");
        });

        modelBuilder.Entity<BanMember>(entity =>
        {
            entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.StatusTime).HasColumnType("datetime");

            entity.HasOne(d => d.Admin).WithMany(p => p.BanMembers)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK_BanMembers_Admins");

            entity.HasOne(d => d.Member1).WithMany(p => p.BanMemberMember1s)
                .HasForeignKey(d => d.Member1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BanMembers_Members");

            entity.HasOne(d => d.Member2).WithMany(p => p.BanMemberMember2s)
                .HasForeignKey(d => d.Member2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BanMembers_Members1");
        });

        modelBuilder.Entity<Board>(entity =>
        {
            entity.Property(e => e.Text)
                .IsRequired()
                .HasMaxLength(1000);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.Boards)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Boards_Members");
        });

        modelBuilder.Entity<BonusItem>(entity =>
        {
            entity.HasOne(d => d.Bonus).WithMany(p => p.BonusItems)
                .HasForeignKey(d => d.BonusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BonusItems_BonusProducts");

            entity.HasOne(d => d.Member).WithMany(p => p.BonusItems)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BonusItems_Members");
        });

        modelBuilder.Entity<BonusProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Products");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(3000)
                .HasColumnName("URL");

            entity.HasOne(d => d.ProductType).WithMany(p => p.BonusProducts)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductTypes");
        });

        modelBuilder.Entity<BonusProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductTypes");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.CartItem)
                .HasForeignKey<CartItem>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartItems_Games");

            entity.HasOne(d => d.Member).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartItems_Members");
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.Isread).HasColumnName("isread");
            entity.Property(e => e.ReceiveId).HasColumnName("Receive_id");
            entity.Property(e => e.SenderId).HasColumnName("Sender_id");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");
        });

        modelBuilder.Entity<Collection>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Game).WithMany(p => p.Collections)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Collections_Games");

            entity.HasOne(d => d.Member).WithMany(p => p.Collections)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Collections_Members");

            entity.HasOne(d => d.MemberTag).WithMany(p => p.Collections)
                .HasForeignKey(d => d.MemberTagId)
                .HasConstraintName("FK_Collections_MemberTags");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.Comment1).HasColumnName("Comment");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Game).WithMany(p => p.Comments)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Games");

            entity.HasOne(d => d.Member).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Members");
        });

        modelBuilder.Entity<Developer>(entity =>
        {
            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.BanTime).HasColumnType("datetime");
            entity.Property(e => e.ConfirmCode).HasMaxLength(256);
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("EMail");
            entity.Property(e => e.EncryptedPassword).HasMaxLength(1000);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerDiscounts");

            entity.Property(e => e.Desciption).HasMaxLength(500);
            entity.Property(e => e.DiscountType)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Image)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Developer).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.DeveloperId)
                .HasConstraintName("FK_Discounts_Developers");
        });

        modelBuilder.Entity<DiscountItem>(entity =>
        {
            entity.ToTable("DiscountItem");

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountItems)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscountItem_Discounts");

            entity.HasOne(d => d.Game).WithMany(p => p.DiscountItems)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscountItem_Games");
        });

        modelBuilder.Entity<Dlc>(entity =>
        {
            entity.ToTable("DLCs");

            entity.HasOne(d => d.DlcNavigation).WithMany(p => p.DlcDlcNavigations)
                .HasForeignKey(d => d.DlcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DLCs_Games");

            entity.HasOne(d => d.MainGame).WithMany(p => p.DlcMainGames)
                .HasForeignKey(d => d.MainGameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DLCs_Games1");
        });

        modelBuilder.Entity<EcpayOrder>(entity =>
        {
            entity.HasKey(e => e.MerchantTradeNo).HasName("PK_EcpayOrders_1");

            entity.Property(e => e.MerchantTradeNo).HasMaxLength(50);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.PaymentTypeChargeFee).HasMaxLength(50);
            entity.Property(e => e.RtnMsg).HasMaxLength(50);
            entity.Property(e => e.TradeDate).HasMaxLength(50);
            entity.Property(e => e.TradeNo).HasMaxLength(50);

            entity.HasOne(d => d.Member).WithMany(p => p.EcpayOrders)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_EcpayOrders_Members");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.Property(e => e.Relationship)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Member1).WithMany(p => p.FriendMember1s)
                .HasForeignKey(d => d.Member1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friends_Members");

            entity.HasOne(d => d.Member2).WithMany(p => p.FriendMember2s)
                .HasForeignKey(d => d.Member2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friends_Members1");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.Property(e => e.Cover)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(1000);
            entity.Property(e => e.Introduction)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Video)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.Developer).WithMany(p => p.Games)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_Developers");
        });

        modelBuilder.Entity<GameTag>(entity =>
        {
            entity.HasOne(d => d.Game).WithMany(p => p.GameTags)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameTags_Games");

            entity.HasOne(d => d.Tag).WithMany(p => p.GameTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameTags_Tags");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.DisplayImage)
                .IsRequired()
                .HasMaxLength(3000);

            entity.HasOne(d => d.Game).WithMany(p => p.Images)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Images_Games");
        });

        modelBuilder.Entity<LinepayOrder>(entity =>
        {
            entity.Property(e => e.Currency)
                .IsRequired()
                .HasMaxLength(500);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.Account)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(200)
                .HasColumnName("AvatarURL");
            entity.Property(e => e.BanTime).HasColumnType("datetime");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.ConfirmCode).HasMaxLength(256);
            entity.Property(e => e.Google).HasMaxLength(256);
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.Mail)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NickName).HasMaxLength(50);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MemberTag>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Member).WithMany(p => p.MemberTags)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberTags_Members");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.Text)
                .IsRequired()
                .HasMaxLength(1000);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Board).WithMany(p => p.Messages)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Boards");

            entity.HasOne(d => d.Member).WithMany(p => p.Messages)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Members");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Orders_1");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Game).WithMany(p => p.Orders)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Games");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Order)
                .HasForeignKey<Order>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Members");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.Property(e => e.Image)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.Board).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pictures_Boards");

            entity.HasOne(d => d.Member).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pictures_Members");

            entity.HasOne(d => d.Message).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pictures_Messages");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TransferMethod>(entity =>
        {
            entity.Property(e => e.PaymentMethod)
                .IsRequired()
                .HasMaxLength(500);
        });

        modelBuilder.Entity<TransferPayment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Info)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("info");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TransferPayment)
                .HasForeignKey<TransferPayment>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferPayments_TransferMethods");
        });

        modelBuilder.Entity<TransferRefund>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TransferRefund)
                .HasForeignKey<TransferRefund>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferRefunds_TransferMethods");

            entity.HasOne(d => d.Id1).WithOne(p => p.TransferRefund)
                .HasForeignKey<TransferRefund>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferRefunds_TransferPayments");
        });

        modelBuilder.Entity<WishListe>(entity =>
        {
            entity.HasOne(d => d.Game).WithMany(p => p.WishListes)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WishListes_Games");

            entity.HasOne(d => d.Member).WithMany(p => p.WishListes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WishListes_Members");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}