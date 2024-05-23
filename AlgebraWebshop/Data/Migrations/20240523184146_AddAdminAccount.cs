using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace AlgebraWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminAccount : Migration
    {
        const string ADMIN_USER_GUID = "ec7aac13-536c-4273-8cc0-9309c1152e93";
        const string ADMIN_ROLE_GUID = "20ad3ff5-6892-4520-a0a4-2c3953cac330";
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                INSERT INTO AspNetRoles (Id, Name, NormalizedName)
                VALUES ('{ADMIN_ROLE_GUID}', 'Admin', 'ADMIN');");

            StringBuilder sb = new StringBuilder();

            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<ApplicationUser>();
            var passwordhash = hasher.HashPassword(null, "Admin123");

            sb.Append("INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, Address, FirstName, LastName, OIB) ");
            sb.Append("VALUES(");
            sb.Append($"'{ADMIN_USER_GUID}',");
            sb.Append($"'admin@admin.com'");
            sb.Append($",'ADMIN@ADMIN.COM'");
            sb.Append($",'admin@admin.com'");
            sb.Append($",'ADMIN@ADMIN.COM'");
            sb.Append($",1");
            sb.Append($",'{passwordhash}'");
            sb.Append($",''");
            sb.Append($",''");
            sb.Append($",'0981234567'");
            sb.Append($",1");
            sb.Append($",0");
            sb.Append($",NULL");
            sb.Append($",0");
            sb.Append($",0");
            sb.Append($",'HQ'");
            sb.Append($",'Admin'");
            sb.Append($",'Admin'");
            sb.Append($",'12345678901');");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($@"
                INSERT INTO AspNetUserRoles (UserId, RoleId) 
                VALUES ('{ADMIN_USER_GUID}', '{ADMIN_ROLE_GUID}')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DELETE FROM AspNetUsersRoles WHERE UserId='{ADMIN_USER_GUID}' AND RoleId='{ADMIN_ROLE_GUID}';");

            migrationBuilder.Sql($@"DELETE FROM AspNetUsers WHERE Id='{ADMIN_USER_GUID}';");

            migrationBuilder.Sql($@"DELETE FROM AspNetRoles WHERE Id='{ADMIN_ROLE_GUID}';");
        }
    }
}
