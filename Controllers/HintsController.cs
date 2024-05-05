using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SetAPI.Data;
using SetAPI.Dtos;
using SetAPI.models;
using SetAPI.Services;

namespace SetAPI.Controllers
{
    [Route("api/hints")]
    [ApiController]
    public class HintsController : ControllerBase
    {
        private readonly ISetRepo _repository;
        private readonly IMapper _mapper;
        private readonly ISetService _setSetvice;

        public HintsController(ISetRepo repository, IMapper mapper, ISetService setService)
        {
            _repository = repository;
            _mapper = mapper;
            _setSetvice = setService;
        }

        [HttpGet]
        public ActionResult<Card[]> GetHint([FromQuery(Name = "ids")] int[] ids)
        {
            var cardItems = _repository.GetCardsById(ids);
            if (cardItems != null)
            {
                var set = _setSetvice.FindHint(cardItems.ToArray(), 0);
                return Ok(set.Take(2));
                
            }
            return BadRequest();
        }
    }
}