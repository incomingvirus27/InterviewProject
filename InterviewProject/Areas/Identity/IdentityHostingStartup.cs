﻿using System;
using InterviewProject.Areas.Identity.Data;
using InterviewProject.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//[assembly: HostingStartup(typeof(InterviewProject.Areas.Identity.IdentityHostingStartup))]
//namespace InterviewProject.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        //public void Configure(IWebHostBuilder builder)
//        //{
//        //    builder.ConfigureServices((context, services) => {
//        //        services.AddDbContext<ApplicationDbContext>(options =>
//        //            options.UseSqlServer(
//        //                context.Configuration.GetConnectionString("ApplicationDbContextConnection")));

//        //        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//        //            .AddEntityFrameworkStores<ApplicationDbContext>();
//        //    });
//        //}
//    }
//}