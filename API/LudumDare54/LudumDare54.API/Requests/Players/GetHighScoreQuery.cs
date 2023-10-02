using AutoMapper;
using LudumDare54.API.Database;
using LudumDare54.API.Extensions;
using LudumDare54.API.Models;
using LudumDare54.API.Models.DTO;
using MediatR;

namespace LudumDare54.API.Requests.Players;

public record GetHighScoreQuery(string Id) : IRequest<IHighScore>
{
    public class Handler : IRequestHandler<GetHighScoreQuery, IHighScore>
    {
        private readonly IMapper _mapper;
        private HighScoreRepository _highScoreRepository;
        
        public Handler(IMapper mapper, HighScoreRepository playerRepository)
        {
            _mapper = mapper;
            _highScoreRepository = playerRepository;
        }
        
        public async Task<IHighScore> Handle(GetHighScoreQuery request, CancellationToken cancellationToken)
        {
            var query = await _highScoreRepository.Get();
            var result =  await query
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();
            
            return result != null
                ? _mapper.Map<HighScoreModel>(result)
                : null;
        }
    }
}