using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SetAPI.Data;
using SetAPI.Dtos;
using SetAPI.models;
using SetAPI.Services;

namespace SetAPI.Controllers
{
    [Route("api/sets")]
    [ApiController]
    public class SetsController : ControllerBase
    {
        private readonly ISetRepo _repository;
        private readonly IMapper _mapper;
        private readonly ISetService _setService;

        public SetsController(ISetRepo repository, IMapper mapper, ISetService setService)
        {
            _repository = repository;
            _mapper = mapper;
            _setService = setService;
        }

        [HttpGet("{gameId}")]
        public ActionResult<IEnumerable<SetReadDto>> GetSetsByGameId(int gameId)
        {
            // int counter = 0;
            var setItems = _repository.GetSetsByGameId(gameId);
            if (setItems != null)
            {
                return Ok (_mapper.Map<IEnumerable<SetReadDto>>(setItems));
                // foreach (SetReadDto setReadDto in setReadDtos)
                // {
                //     setReadDto.Cards = _repository.GetCardsById(setItems.ElementAt(counter).Cards).ToArray();
                //     counter++;
                // }
                // return Ok(setReadDtos);
            }
            return NotFound();
        }

        [HttpDelete("{gameId}")]
        public ActionResult DeleteSetsByGameId(int gameId)
        {
            var setsToDelete = _repository.GetSetsByGameId(gameId);
            foreach (Set set in setsToDelete)
            {
                _repository.DeleteSet(set);
            }
            _repository.SaveChanges();
            return NoContent();

        }

        [HttpPost]
        public ActionResult<SetReadDto> CreateSet(SetCreateDto setCreateDto)
        {
            var setModel = _mapper.Map<Set>(setCreateDto);
            var cards = new Card[3];
            for (int i = 0; i < 3; i++)
            {
                cards[i] = _repository.GetCardById(setModel.Cards[i]);
            }
            if (!_setService.ValidateSet(cards))
            {
                return BadRequest();
            }

            _repository.CreateSet(setModel);
            _repository.SaveChanges();

            var setReadDto = _mapper.Map<SetReadDto>(setModel);
            return CreatedAtRoute(nameof(GetSet), new { gameId = setReadDto.GameId, setNr = setReadDto.SetNr }, setReadDto);


        }

        [HttpGet(Name = "GetSet")]
        public ActionResult<SetReadDto> GetSet(int gameId, int setNr)
        {
            var setModel = _repository.GetSet(gameId, setNr);
            if (setModel != null)
            {
                return Ok(_mapper.Map<SetReadDto>(setModel));
            }
            return NotFound();
        }

    }
}
