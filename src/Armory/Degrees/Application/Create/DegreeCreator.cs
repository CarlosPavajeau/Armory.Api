using System.Threading.Tasks;
using Armory.Degrees.Domain;
using AutoMapper;

namespace Armory.Degrees.Application.Create
{
    public class DegreeCreator
    {
        private readonly IMapper _mapper;
        private readonly IDegreesRepository _repository;

        public DegreeCreator(IDegreesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CreateDegreeCommand command)
        {
            var degree = _mapper.Map<Degree>(command);
            await _repository.Save(degree);
        }
    }
}
