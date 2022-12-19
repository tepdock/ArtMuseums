using ArtMuseum;
using ArtMuseums.ActionFilters;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtMuseums.Controllers
{
    [Route("api/{username}/cart")]
    [ApiController]
    [Authorize]
    public class PurchaseController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PurchaseController(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCardByUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                _logger.Info($"user with username: {username} doesn't exist");
                return NotFound();
            }

            var card = await _repository.PurchaseRepository.GetPurchasesByUser(username, trackChanges: false);

            var cardDto = _mapper.Map<IEnumerable<PurchaseDto>>(card);

            return Ok(cardDto);
        }

        [HttpGet("{id}", Name = "GetPurchaseById")]
        public async Task<IActionResult> GetPurchase(string username, string purchaseId)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                _logger.Info($"user with username: {username} doesn't exist");
                return NotFound();
            }

            var purchase = await _repository.PurchaseRepository.GetPurchase(purchaseId, trackChanges: false);
            if (purchase == null)
            {
                _logger.Info($"purchase with id: {purchaseId} doesn't exist");
                return NotFound();
            }
            else
            {
                var purchaseDto = _mapper.Map<IEnumerable<PurchaseDto>>(purchase);
                return Ok(purchaseDto);
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePurchase([FromBody] PurchaseDto purchaseDto)
        {
            var user = await _userManager.FindByNameAsync(purchaseDto.UserName);
            if (user == null)
            {
                _logger.Info($"user with username: {purchaseDto.UserName} doesn't exist");
                return NotFound();
            }
            purchaseDto.Id = Guid.NewGuid().ToString();
            var purchase = _mapper.Map<Purchase>(purchaseDto);
            _repository.PurchaseRepository.CreatePurchase(purchase);
            var tour = await _repository.TourRepository.GetTourByDescr(purchase.TourName, true);
            tour.TourPlaces--;
            await _repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(string id)
        {
            var purchase = await _repository.PurchaseRepository.GetPurchase(id, trackChanges: false);
            if (purchase == null)
            {
                _logger.Info($"purchase with id: {id} doesn't exist");
                return NotFound();
            }

            _repository.PurchaseRepository.DeletePurchase(purchase);
            var tour = await _repository.TourRepository.GetTourByDescr(purchase.TourName, true);
            tour.TourPlaces++;
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePurchase(string id, [FromBody] PurchaseDto purchaseDto)
        {
            var user = await _userManager.FindByNameAsync(purchaseDto.UserName);
            if (user == null)
            {
                _logger.Info($"user with username: {purchaseDto.UserName} doesn't exist");
                return NotFound();
            }

            var purchEntity = await _repository.PurchaseRepository.GetPurchase(id, trackChanges: true);
            if (purchEntity == null)
            {
                _logger.Info($"purch with id: {id} doesn't exist");
                return NotFound();
            }

            _mapper.Map(purchaseDto, purchEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
