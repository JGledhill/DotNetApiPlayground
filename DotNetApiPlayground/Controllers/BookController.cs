using DotNetApiPlayground.DAL;
using DotNetApiPlayground.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApiPlayground.Controllers
{
    /* This is a controller class.
     * It is responsible for handling HTTP requests.
     * https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/actions?view=aspnetcore-7.0
     *
     * These two lines are called attributes.
     * They are used to configure the controller.
     */
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> _repository;
        private readonly ILogger<BookController> _logger;
        
        /* This is a constructor.
         * It is used to inject dependencies.
         * This controller has a dependency on IRepository<Book> and ILogger<T>.
         */
        public BookController(IRepository<Book> repository, ILogger<BookController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /* This is an action method.
         * It is responsible for handling HTTP requests.
         */
        [HttpGet(Name = "GetBooks")]
        public ActionResult<List<Book>> Get()
        {
            return Ok(_repository.GetAll());
        }
    }
}