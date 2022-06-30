using ArtMuseum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtMuseums.Controllers
{
    [Route("api/museums")]
    [ApiController]
    public class MuseumController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public MuseumController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetMuseums()
        {
            var museums = _repository.ArtMuseumRepository.GetAllMuseums(trackChanges: false);

            return Ok(museums);
        }
    }
}
