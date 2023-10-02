using AutoMapper;
using LudumDare54.API.Database;
using LudumDare54.API.Extensions;
using LudumDare54.API.Models;
using LudumDare54.API.Models.DTO;
using MediatR;

namespace LudumDare54.API.Requests.HighScores;

public record CreateHighScoreCommand(string Id, HighScoreModel HighScore) : IRequest<IHighScore>
{
    public class Handler : IRequestHandler<CreateHighScoreCommand, IHighScore>
    {
        private readonly IMapper _mapper;
        private readonly HighScoreRepository _highScoreRepository;
        
        public Handler(IMapper mapper, HighScoreRepository playerRepository)
        {
            _mapper = mapper;
            _highScoreRepository = playerRepository;
        }
        
        public async Task<IHighScore> Handle(CreateHighScoreCommand request, CancellationToken cancellationToken)
        {
            var highScore = _mapper.Map<HighScore>(request.HighScore);
            var createdResource = await _highScoreRepository.Create(highScore);
            
            return createdResource != null
                ? _mapper.Map<HighScoreModel>(createdResource)
                : null;
        }
    }
}