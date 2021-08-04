using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankMillenniumRecruitProject.Data.Dto;

namespace BankMillenniumRecruitProject.Services
{
    public interface ISampleItemService
    {
        public Task<IEnumerable<SampleItemInfo>> GetAllSampleItems();

        public Task<SampleItemInfo> GetSampleItem(long id);

        public Task UpdateSampleItem(SampleItemInfo dto);

        public Task<SampleItemInfo> AddSampleItem(SampleItemInfo sampleItem);

        public Task RemoveSampleItem(long id);

        public Task<bool> IsSampleItemExists(long id);
    }
}
