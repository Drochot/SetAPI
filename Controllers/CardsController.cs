using AutoMapper;
using SetAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using SetAPI.Data;
using SetAPI.models;

namespace SetAPI.Controllers
{
    [Route("api/cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ISetRepo _repository;
        private readonly IMapper _mapper;

        public CardsController(ISetRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CardReadDto>> GetCardsById([FromQuery(Name = "ids") ]int[] ids )
        {
            var cardItems = _repository.GetCardsById(ids);
            cardItems = cardItems.OrderBy(x => Array.IndexOf(ids, x.Id));
            if(cardItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CardReadDto>>(cardItems));
            }

            return NotFound();
            
        }
        // [HttpPost]
        // public ActionResult<IEnumerable<CardReadDto>> CreateCards()
        // {

        //     foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
        //     {
        //         foreach (CardShape shape in Enum.GetValues(typeof(CardShape)))
        //         {
        //             foreach (CardFill fill in Enum.GetValues(typeof(CardFill)))
        //             {
        //                 foreach (CardNumber number in Enum.GetValues(typeof(CardNumber)))
        //                 {
        //                     Card cardItem = new Card
        //                     {
        //                         Number = number,
        //                         Fill = fill,
        //                         Shape = shape,
        //                         Color = color
        //                     };
        //                     // Console.WriteLine(cardItem.Color);
        //                     // Console.WriteLine(cardItem.Shape);
        //                     // Console.WriteLine(cardItem.Fill);
        //                     // Console.WriteLine(cardItem.Number);


        //                     _repository.CreateCard(cardItem);
        //                     _repository.SaveChanges();
        //                 }

        //             }
        //         }
        //     }

        //     return Ok(_mapper.Map<IEnumerable<CardReadDto>>(_repository.GetAllCards()));

        // }
    }
}