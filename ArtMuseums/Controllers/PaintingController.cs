using ArtMuseum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtMuseums.Controllers
{
    [Route("api/paintings")]
    [ApiController]
    public class PaintingController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public PaintingController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetPaintings()
        {
            var paintigs = _repository.PaintingRepository.GetAllPaintings(trackChanges: false);

            return Ok(paintigs);
        }
    }
}
