using ArtMuseum;
using Microsoft.AspNetCore.Mvc;

namespace ArtMuseums.Controllers
{
    [Route("api/exhibitions")]
    [ApiController]
    public class ExhibitionController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ExhibitionController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetExhibitions()
        {
            var exhibitions = _repository.ExhibitionRepository.GetAllExhibitions(trackChanges: false);

            return Ok(exhibitions);
        }
    }
}
