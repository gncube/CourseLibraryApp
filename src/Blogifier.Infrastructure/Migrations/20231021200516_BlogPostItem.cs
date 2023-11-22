using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogifier.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BlogPostItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "BlogId", "Content", "Description", "PublishedOnDate", "Slug", "Title" },
                values: new object[] { 1, 1, "In May 2012 in an extra-ordinary experience the Lord God woke me up from sleep asked me to open my bible to Genesis 17, verses one to eight and spoke to me a very fundamental message that I should send so that it reaches every single person on planet earth. \"Go tell my people I invite them to live their lives in My presence. To those who accept this invitation, I make five solemn promises to them. There are five things however they need to know, believe and experience\". Below are the five solemn promises and the five things you need to know, believe and experience (the needs).This message is sent to you backed by the transforming  power of the Almighty God. Understanding this message will transform your life!", "&lt;p&gt;This is your scripture for today, may it empower you. Please share widely and make someone&#39;s day.“But the fruit of the Spirit is love, joy, peace, longsuffering, gentleness, goodness, faith, Meekness, temperance: against such there is no law.”??Galatians? ?5:22-23? ?KJV??.&quot;So faith comes by hearing and hearing by  ...&lt;/p&gt;", new DateTime(2015, 9, 21, 22, 15, 0, 0, DateTimeKind.Unspecified), "faith-is-a-gift-of-God", "Faith Is A Gift Of God" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
