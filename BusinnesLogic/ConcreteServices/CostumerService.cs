using AutoMapper;
using BusinnesLogic.AbstractServices;
using BusinnesLogic.AllDto.CostumerDto;
using DataAccess.AbstractRepository;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.ConcreteServices
{
    public class CostumerService : ICostumerService
    {
        private readonly IGenericRepository<Costumer> _genericRepository;
        private readonly IMapper _mapper;

        public CostumerService(IGenericRepository<Costumer> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task AddCostumer(CostumerDto costumerDto)
        {
            await _genericRepository.AddAsync(_mapper.Map<Costumer>(costumerDto));
        }

        public async Task DeleteCostumer(string Id)
        {
            await _genericRepository.DeleteAsync(Id);
        }

        public async Task<List<CostumerDto>> GetAllCostumer()
        {
           return _mapper.Map<List<CostumerDto>>(await _genericRepository.GetAllAsync());
        }

        public async Task UpdateCostumer(CostumerDto costumerDto, string Id)
        {
            await _genericRepository.UpdateAsync(_mapper.Map<Costumer>(costumerDto), Id);
        }
    }
}
