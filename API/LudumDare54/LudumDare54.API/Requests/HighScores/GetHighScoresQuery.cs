using AutoMapper;
using LudumDare54.API.Database;
using LudumDare54.API.Extensions;
using LudumDare54.API.Models;
using LudumDare54.API.Models.DTO;
using MediatR;

namespace LudumDare54.API.Requests.HighScores;

public record GetHighScoresQuery (string Id) : IRequest<IReadOnlyCollection<IHighScore>>
{
    public class Handler : IRequestHandler<GetHighScoresQuery, IReadOnlyCollection<IHighScore>>
    {
        private readonly IMapper _mapper;
        private readonly HighScoreRepository _highScoreRepository;
        
        public Handler(IMapper mapper, HighScoreRepository playerRepository)
        {
            _mapper = mapper;
            _highScoreRepository = playerRepository;
        }
        
        public async Task<IReadOnlyCollection<IHighScore>> Handle(GetHighScoresQuery request, CancellationToken cancellationToken)
        {
            var query = await _highScoreRepository.Get();
            
            return await query
                .Select(x => _mapper.Map<HighScoreModel>(x))
                .ToArrayAsync();
        }
    }
}