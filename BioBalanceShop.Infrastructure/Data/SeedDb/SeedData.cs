using BioBalanceShop.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public class SeedData
{
    public IdentityRole AdminRole { get; set; }

    public IdentityRole CustomerRole { get; set; }

    public IdentityUser AdminUser { get; set; }

    public IdentityUser CustomerUser { get; set; }

    public IdentityUserRole<string> AdminUserRole { get; set; }

    public IdentityUserRole<string> CustomerUserRole { get; set; }


    public SeedData()
    {
        SeedRoles();
        SeedUsers();
        SeedUsersRoles();
    }

    private void SeedRoles()
    {
        AdminRole = new IdentityRole
        {
            Id = "03f649d4-5366-4680-97d0-a90777f42356",
            Name = "admin",
            NormalizedName = "ADMIN"
        };

        CustomerRole = new IdentityRole
        {
            Id = "ca7cd2a7-6e5f-4e74-9df1-3b6b5fb25r53",
            Name = "customer",
            NormalizedName = "CUSTOMER"
        };
    }

    private void SeedUsers()
    {
        var hasher = new PasswordHasher<IdentityUser>();

        AdminUser = new IdentityUser
        {
            Id = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            UserName = "admin@mail.com",
            NormalizedUserName = "ADMIN@MAIL.COM",
            Email = "admin@mail.com",
            NormalizedEmail = "ADMIN@MAIL.COM",
            EmailConfirmed = true
        };

        AdminUser.PasswordHash =
                 hasher.HashPassword(AdminUser, "AdminPassword123!");

        CustomerUser = new IdentityUser
        {
            Id = "c4f1530f-2727-4bc8-9de3-075fc7420586",
            UserName = "customer@mail.com",
            NormalizedUserName = "CUSTOMER@MAIL.COM",
            Email = "customer@mail.com",
            NormalizedEmail = "CUSTOMER@MAIL.COM",
            EmailConfirmed = true
        };

        CustomerUser.PasswordHash =
                 hasher.HashPassword(CustomerUser, "CustomerPassword123!");
    }

    private void SeedUsersRoles()
    {
        AdminUserRole = new IdentityUserRole<string>
        {
            RoleId = "03f649d4-5366-4680-97d0-a90777f42356",
            UserId = "02c32793-47c7-4f3b-9487-d91c2a0e4345"
        };

        CustomerUserRole = new IdentityUserRole<string>
        {
            RoleId = "ca7cd2a7-6e5f-4e74-9df1-3b6b5fb25r53",
            UserId = "c4f1530f-2727-4bc8-9de3-075fc7420586"
        };
    }


}
