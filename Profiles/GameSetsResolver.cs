using AutoMapper;
using SetAPI.Data;
using SetAPI.Dtos;
using SetAPI.models;

namespace SetAPI.Profiles
{
    public class GameSetsResolver : IValueResolver<Game, GameReadDto, SetReadDto[]>
    {
        private readonly ISetRepo _repository;
        private readonly IMapper _mapper;

        public GameSetsResolver(ISetRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public SetReadDto[] Resolve(Game source, GameReadDto destination, SetReadDto[] destMember, ResolutionContext context)
        {
            var sets = _repository.GetSetsByGameId(source.GameId);
            return _mapper.Map<IEnumerable<SetReadDto>>(sets).ToArray();

        }
    }
}