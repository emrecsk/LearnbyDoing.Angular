using TaskApp.Application.Interfaces;
using TaskApp.Application.Models;
using TaskApp.Core.Enums;
using TaskApp.Core.Interfaces;
using TaskApp.Core.Models;

namespace TaskApp.Application.Services
{
    public class VocationService : IVocationService
    {
        private readonly IGenericRepository<Vocation> _vocationRepository;

        public VocationService(IGenericRepository<Vocation> vocationRepository)
        {
            _vocationRepository = vocationRepository;
        }

        public async Task<VocationDto> AddVocationAsync(VocationDto vocationDto)
        {
            Vocation vocation = new Vocation
            {
                Title = vocationDto.Title,
                Description = vocationDto.Description,
                CreatedAt = DateTime.Today,
                UpdatedAt = DateTime.Today,
                Status = Status.Pending
            };

            var addedVocation = await _vocationRepository.AddAsync(vocation);

            return vocationDto;
        }

        public async Task<bool> DeleteVocationAsync(int id)
        {
            var vocation = await _vocationRepository.GetByIdAsync(id);

            if (vocation == null)
            {
                return false;
            }

            await _vocationRepository.DeleteAsync(vocation);

            return true;
        }

        public async Task<VocationDto> GetVocationByIdAsync(int id)
        {
            VocationDto vocationDto = new() { Title = string.Empty, Description = string.Empty };

            var vocation = await _vocationRepository.GetByIdAsync(id);

            if (vocation == null)
            {
                return vocationDto;
            }

            vocationDto.Id = vocation.Id;
            vocationDto.Title = vocation.Title;
            vocationDto.Description = vocation.Description;
            vocationDto.StartDate = vocation.CreatedAt;
            vocationDto.EndDate = vocation.UpdatedAt;
            vocationDto.Status = vocation.Status;

            return vocationDto;
        }

        public async Task<IList<VocationDto>> GetVocationsAsync()
        {
            List<VocationDto> vocationDtos = new();

            var vocations = await _vocationRepository.ListAsync();

            foreach (var vocation in vocations)
            {
                VocationDto vocationDto = new()
                {
                    Id = vocation.Id,
                    Title = vocation.Title,
                    Description = vocation.Description,
                    StartDate = vocation.CreatedAt,
                    EndDate = vocation.UpdatedAt,
                    Status = vocation.Status
                };
                vocationDtos.Add(vocationDto);
            }

            return vocationDtos;
        }

        public async Task<bool> UpdateVocationAsync(VocationDto vocationDto)
        {
            var vocation = await _vocationRepository.GetByIdAsync(vocationDto.Id);

            if (vocation == null)
            {
                return false;
            }

            vocation.Title = vocationDto.Title;
            vocation.Description = vocationDto.Description;
            vocation.UpdatedAt = DateTime.Today;
            vocation.Status = vocationDto.Status;

            await _vocationRepository.UpdateAsync(vocation);

            return true;

        }
    }
}
