using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogifier.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TheMessageBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Description", "SubTitle", "Title" },
                values: new object[] { 1, "The invitation from the almighty God to walk before Him: In May 2012 in an extra-ordinary experience the Lord God woke me up from sleep asked me to open my bible to Genesis 17, verses one to eight and spoke to me a very fundamental message that I should send so that it reaches every single person on planet earth. \"Go tell my people I invite them to live their lives in My presence. To those who accept this invitation, I make five solemn promises to them. There are five things however they need to know, believe and experience\". Below are the five solemn promises and the five things you need to know, believe and experience (the needs).This message is sent to you backed by the transforming  power of the Almighty God. Understanding this message will transform your life!", "The Daily Message", "The Message" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
