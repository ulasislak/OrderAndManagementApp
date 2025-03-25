using AutoMapper;
using BusinnesLogic.AbstractServices;
using BusinnesLogic.AllDto.OwnerDto;
using DataAccess.AbstractRepository;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.ConcreteServices
{
    public class OwnerService : IOwnerService
    {
        private readonly IGenericRepository<Owner> _genericRepository;
        private readonly IMapper _mapper;

        public OwnerService(IGenericRepository<Owner> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task AddUser(OwnerDto ownerDto)
        {
            await _genericRepository.AddAsync(_mapper.Map<Owner>(ownerDto));
        }

        public async Task DeleteUser(string Id)
        {
            await _genericRepository.DeleteAsync(Id);
        }
    }
}
