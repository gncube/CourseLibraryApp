﻿// <auto-generated />
using System;
using Blogifier.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blogifier.Infrastructure.Migrations
{
    [DbContext(typeof(BlogifierDbContext))]
    [Migration("20231021195759_TheMessageBlog")]
    partial class TheMessageBlog
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("Blogifier.Domain.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The invitation from the almighty God to walk before Him: In May 2012 in an extra-ordinary experience the Lord God woke me up from sleep asked me to open my bible to Genesis 17, verses one to eight and spoke to me a very fundamental message that I should send so that it reaches every single person on planet earth. \"Go tell my people I invite them to live their lives in My presence. To those who accept this invitation, I make five solemn promises to them. There are five things however they need to know, believe and experience\". Below are the five solemn promises and the five things you need to know, believe and experience (the needs).This message is sent to you backed by the transforming  power of the Almighty God. Understanding this message will transform your life!",
                            SubTitle = "The Daily Message",
                            Title = "The Message"
                        });
                });

            modelBuilder.Entity("Blogifier.Domain.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BlogId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishedOnDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("Blogifier.Domain.BlogPost", b =>
                {
                    b.HasOne("Blogifier.Domain.Blog", null)
                        .WithMany("BlogPosts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogifier.Domain.Blog", b =>
                {
                    b.Navigation("BlogPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
