﻿// <auto-generated />
using System;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20230613114415_AddBookPrice")]
    partial class AddBookPrice
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<Guid>("AuthorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BooksId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("BookAuthor", (string)null);
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenresId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BooksId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("BookGenre", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Model.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Infrastructure.Model.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<int>("BookStatus")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Infrastructure.Model.BookRecommendation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecommendationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("BookRecommendations");
                });

            modelBuilder.Entity("Infrastructure.Model.BookReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("BookReviews");
                });

            modelBuilder.Entity("Infrastructure.Model.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Infrastructure.Model.Interaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookReviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("Infrastructure.Model.Moderation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookReviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookReviewId");

                    b.ToTable("Moderations");
                });

            modelBuilder.Entity("Infrastructure.Model.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Infrastructure.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusRequest")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Infrastructure.Model.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BorrowedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRetrieved")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Infrastructure.Model.ReadingList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("ReadingLists");
                });

            modelBuilder.Entity("Infrastructure.Model.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookReviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Massage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Infrastructure.Model.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Infrastructure.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSlot")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Infrastructure.Model.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Model.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("Infrastructure.Model.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Model.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Model.BookRecommendation", b =>
                {
                    b.HasOne("Infrastructure.Model.Book", "Book")
                        .WithOne("BookRecommendation")
                        .HasForeignKey("Infrastructure.Model.BookRecommendation", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Model.User", "User")
                        .WithMany("BookRecommendations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Model.BookReview", b =>
                {
                    b.HasOne("Infrastructure.Model.Book", "Book")
                        .WithMany("BookReviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Model.User", "User")
                        .WithMany("BookReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Model.Interaction", b =>
                {
                    b.HasOne("Infrastructure.Model.BookReview", "BookReview")
                        .WithMany("Interactions")
                        .HasForeignKey("BookReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Model.User", "User")
                        .WithMany("Interactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookReview");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Model.Moderation", b =>
                {
                    b.HasOne("Infrastructure.Model.BookReview", "BookReview")
                        .WithMany("Moderations")
                        .HasForeignKey("BookReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookReview");
                });

            modelBuilder.Entity("Infrastructure.Model.Notification", b =>
                {
                    b.HasOne("Infrastructure.Model.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Model.Order", b =>
                {
                    b.HasOne("Infrastructure.Model.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Model.OrderItem", b =>
                {
                    b.HasOne("Infrastructure.Model.Book", "Book")
                        .WithMany("OrderItems")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Model.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Infrastructure.Model.ReadingList", b =>
                {
                    b.HasOne("Infrastructure.Model.Book", "Book")
                        .WithMany("ReadingLists")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Model.User", "User")
                        .WithMany("ReadingLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Model.Report", b =>
                {
                    b.HasOne("Infrastructure.Model.BookReview", "BookReview")
                        .WithMany("Reports")
                        .HasForeignKey("BookReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Model.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookReview");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Model.User", b =>
                {
                    b.OwnsMany("Infrastructure.Model.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("CreatedOn")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("ExpiresOn")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime?>("RevokedOn")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Token")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId", "Id");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Infrastructure.Model.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Model.Book", b =>
                {
                    b.Navigation("BookRecommendation")
                        .IsRequired();

                    b.Navigation("BookReviews");

                    b.Navigation("OrderItems");

                    b.Navigation("ReadingLists");
                });

            modelBuilder.Entity("Infrastructure.Model.BookReview", b =>
                {
                    b.Navigation("Interactions");

                    b.Navigation("Moderations");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Infrastructure.Model.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Infrastructure.Model.User", b =>
                {
                    b.Navigation("BookRecommendations");

                    b.Navigation("BookReviews");

                    b.Navigation("Interactions");

                    b.Navigation("Notifications");

                    b.Navigation("Orders");

                    b.Navigation("ReadingLists");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
