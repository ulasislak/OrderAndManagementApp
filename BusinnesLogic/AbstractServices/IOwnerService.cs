using BusinnesLogic.AllDto.OrderDto;
using BusinnesLogic.AllDto.OwnerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.AbstractServices
{
    public interface IOwnerService
    {
        Task AddUser(OwnerDto ownerDto);

        Task DeleteUser(string Id);
       
    }
}
