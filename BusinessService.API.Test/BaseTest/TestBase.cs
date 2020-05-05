
using BusinessService.API.Controllers;
using BusinessService.API.DBContext;
using BusinessService.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace BusinessService.API.Test.BaseTest
{
    public class TestBase
    {
        protected Mock<HttpRequest> request;
        protected Mock<HttpResponse> response;
        protected Mock<HttpContext> context;

        [OneTimeSetUp]
        public void Init()
        {
            request = new Mock<HttpRequest>();
            response = new Mock<HttpResponse>();
            context = new Mock<HttpContext>();
        }

        [OneTimeTearDown]
        public void Finish()
        {
            request = null;
            response = null;
            context = null;
        }

        protected IConfiguration GetAppConfigInstance()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.test.json");
            var appConfig = configBuilder.AddJsonFile(path);
            IConfiguration configuration = appConfig.Build();
            return configuration;
        }

        protected T GetControllerContext<T>() where T : ControllerBase
        {
           
            context.SetupGet(x => x.Request).Returns(request.Object);

            IConfiguration config = GetAppConfigInstance();
           
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("IBOConnection"));
            var repositoryContext = new RepositoryContext(optionsBuilder.Options);

            IRepositoryHelper repositoryHelper = new RepositoryHelper(repositoryContext);

            var controller = Activator.CreateInstance(typeof(T), repositoryHelper) as T;
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = context.Object
            };

            return controller;
        }
    }
}
