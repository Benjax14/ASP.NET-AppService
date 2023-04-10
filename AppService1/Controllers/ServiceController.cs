using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using AppService.Api.Tables;
using AppService.Api.RequestResponse.Requests;
using AppService.Api.RequestResponse.Response;

namespace AppService1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {

        private readonly ILogger<Request> _logger;
        public ServiceController(ILogger<Request> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Response Get()
        {
            var books = new List<Book>
            {
                new AppService.Api.Tables.Book() { Name = "Libro 1", PublicationDate = DateTime.Now, EditorialId = 1, Pages = 50, Type = AppService.Api.Tables.Enums.SpecialtyType.Chemistry, AuthorId = 2, OnlineAvailable= true},
                new AppService.Api.Tables.Book() { Name = "Libro 2", PublicationDate = DateTime.Now, EditorialId = 1, Pages = 150, Type = AppService.Api.Tables.Enums.SpecialtyType.Literature, AuthorId = 2, OnlineAvailable= true}
            };

            return new Response() { Items = { { "Records", books } } };

        }

        [HttpPost]
        public Response Post(Request request)
        {

            var books = new List<Book>
            {
                new AppService.Api.Tables.Book() { Name = "Libro A", PublicationDate = DateTime.Now, EditorialId = 1, Pages = 50, Type = AppService.Api.Tables.Enums.SpecialtyType.Chemistry},
                new AppService.Api.Tables.Book() { Name = "Libro B", PublicationDate = DateTime.Now, EditorialId = 1, Pages = 150, Type = AppService.Api.Tables.Enums.SpecialtyType.Literature}
            };


            // Aqui procesaremos los requests
            return new Response() { Items = { { "Records", books } } };
        }

    }
}
