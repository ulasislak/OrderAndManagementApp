using BusinnesLogic.AllDto.CostumerDto;
using BusinnesLogic.AllDto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.AbstractServices
{
    public interface ICostumerService
    {
        Task AddCostumer(CostumerDto costumerDto);
        Task DeleteCostumer(string Id);
        Task UpdateCostumer(CostumerDto costumerDto, string Id);
        Task<List<CostumerDto>> GetAllCostumer();
    }
}
