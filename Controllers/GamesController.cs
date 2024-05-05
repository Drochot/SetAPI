using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SetAPI.Data;
using SetAPI.Dtos;
using SetAPI.models;
using SetAPI.Services;

namespace SetAPI.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ISetRepo _repository;
        private readonly IMapper _mapper;
        private readonly ISetService _setSetvice;

        public GamesController(ISetRepo repository, IMapper mapper, ISetService setService)
        {
            _repository = repository;
            _mapper = mapper;
            _setSetvice = setService;
        }

        [HttpGet("{id:int}", Name = "GetGameById")]
        public ActionResult<GameReadDto> GetGameById(int id)
        {
            var gameItem = _repository.GetGameById(id);
            if (gameItem != null)
            {
                return Ok(_mapper.Map<GameReadDto>(gameItem));
            }
            return NotFound();

        }

        [HttpGet("{user}")]
        public ActionResult<IEnumerable<GameReadDto>> GetGamesByUser(string user)
        {
            var gameItems = _repository.GetGamesByUser(user);
            if (gameItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<GameReadDto>>(gameItems));
            }
            return NotFound();

        }

        [HttpPost("{user}")]
        public ActionResult<GameReadDto> CreateNewGame(string user)
        {
            //TODO: shuffle cards


            var cardItems = _repository.GetAllCards();
            cardItems = cardItems.OrderBy(x => Random.Shared.Next()).ToArray();
            var cardIds = new int[cardItems.Count()];

            for (int i = 0; i < cardItems.Count(); i++)
            {
                int id = cardItems.ElementAt(i).Id;
                cardIds[i] = id;
            }

            var gameModel = new Game
            {
                CardsOnBoard = 12,
                User = user,
                Deck = cardIds,
            };

            gameModel.SetsOnBoard = _setSetvice.CountSetsOnBoard((Card[])cardItems, gameModel.CardsOnBoard);

            while (gameModel.SetsOnBoard == 0)
            {
                gameModel.CardsOnBoard += 3;
                gameModel.SetsOnBoard = _setSetvice.CountSetsOnBoard((Card[])cardItems, gameModel.CardsOnBoard);
            }


            _repository.CreateGame(gameModel);
            _repository.SaveChanges();

            var gameReadDto = _mapper.Map<GameReadDto>(gameModel);
            return CreatedAtRoute(nameof(GetGameById), new { id = gameReadDto.GameId }, gameReadDto);
        }

        [HttpPatch("{id}")]
        public ActionResult<GameReadDto> PartialGameUpdate(int id, JsonPatchDocument<GameUpdateDto> patchDoc)
        {
            var gameModelFromRepo = _repository.GetGameById(id);
            if (gameModelFromRepo == null)
            {
                return NotFound();
            }
            var gameToPatch = _mapper.Map<GameUpdateDto>(gameModelFromRepo);
            patchDoc.ApplyTo(gameToPatch, ModelState);

            if (!TryValidateModel(gameToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(gameToPatch, gameModelFromRepo);

            var cardItems = _repository.GetCardsById(gameModelFromRepo.Deck).ToArray();
            cardItems = cardItems.OrderBy(x => Array.IndexOf(gameModelFromRepo.Deck, x.Id)).ToArray();

            if (gameModelFromRepo.CardsOnBoard > 12)
            {
                gameModelFromRepo.CardsOnBoard -= 3;
            }

            if (gameModelFromRepo.CardsOnBoard > gameModelFromRepo.Deck.Length)
            {
                gameModelFromRepo.CardsOnBoard = gameModelFromRepo.Deck.Length;
            }

            gameModelFromRepo.SetsOnBoard = _setSetvice.CountSetsOnBoard(cardItems, gameModelFromRepo.CardsOnBoard);

            while (gameModelFromRepo.SetsOnBoard == 0 && gameModelFromRepo.CardsOnBoard + 3 <= gameModelFromRepo.Deck.Length)
            {
                gameModelFromRepo.CardsOnBoard += 3;
                gameModelFromRepo.SetsOnBoard = _setSetvice.CountSetsOnBoard(cardItems, gameModelFromRepo.CardsOnBoard);
            }            

            _repository.UpdateGame(gameModelFromRepo);

            _repository.SaveChanges();

            var gameDto = _mapper.Map<GameReadDto>(gameModelFromRepo);

            return Ok(gameDto);

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id)
        {
            var gameModelFromRepo = _repository.GetGameById(id);
            if (gameModelFromRepo == null)
            {
                return NotFound();
            }

            var sets = _repository.GetSetsByGameId(gameModelFromRepo.GameId);
            
            foreach (var set in sets){
                _repository.DeleteSet(set);
            }

             _repository.SaveChanges();

            _repository.DeleteGame(gameModelFromRepo);            

            _repository.SaveChanges();

            return NoContent();
        }


    }
}