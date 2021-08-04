using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankMillenniumRecruitProject.Data.Dto;
using BankMillenniumRecruitProject.Extensions;
using BankMillenniumRecruitProject.Services.Factories;
using BankMillenniumRecruitProject.Services.Repositories;

namespace BankMillenniumRecruitProject.Services
{
    public class SampleItemService : ISampleItemService
    {
        private readonly ISampleItemRepository _repository;
        private readonly SampleItemFactory _sampleItemFactory;

        public SampleItemService(ISampleItemRepository repository, SampleItemFactory sampleItemFactory)
        {
            _repository = repository;
            _sampleItemFactory = sampleItemFactory;
        }

        public Task<IEnumerable<SampleItemInfo>> GetAllSampleItems()
        {
            return Task.FromResult(
                _repository.GetAll()
                    .Select(s => _sampleItemFactory.Create(s))
                    .AsEnumerable());
        }

        public async Task<SampleItemInfo> GetSampleItem(long id)
        {
            return _sampleItemFactory.Create(await _repository.Get(id));
        }

        public async Task UpdateSampleItem(SampleItemInfo dto)
        {
            dto.CheckIsNotNull();
            await _repository.Update(_sampleItemFactory.Create(dto));
        }

        public async Task<SampleItemInfo> AddSampleItem(SampleItemInfo sampleItem)
        {
            sampleItem.CheckIsNotNull();
            return _sampleItemFactory.Create(
                await _repository.Add(
                    _sampleItemFactory.Create(sampleItem)));
        }

        public async Task RemoveSampleItem(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<bool> IsSampleItemExists(long id)
        {
            return await _repository.IsExists(id);
        }
    }
}
