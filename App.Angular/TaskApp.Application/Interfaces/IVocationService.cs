using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Application.Models;

namespace TaskApp.Application.Interfaces
{
    public interface IVocationService
    {
        Task<IList<VocationDto>> GetVocationsAsync();
        Task<VocationDto> GetVocationByIdAsync(int id);
        Task<VocationDto> AddVocationAsync(VocationDto vocationDto);
        Task<bool> UpdateVocationAsync(VocationDto vocationDto);
        Task<bool> DeleteVocationAsync(int id);
    }
}
