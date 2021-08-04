using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankMillenniumRecruitProject.Data;
using BankMillenniumRecruitProject.Data.Dto;

namespace BankMillenniumRecruitProject.Services.Factories
{
    public class SampleItemFactory
    {
        public SampleItemInfo Create(SampleItem item) => item is not null
            ? new()
            {
                Id = item.Id,
                Description = item.Description,
                InsertTime = item.InsertTime,
            }
            : null;

        public SampleItem Create(SampleItemInfo info) => info is not null
            ? new()
            {
                Id = info.Id,
                Description = info.Description,
                InsertTime = info.InsertTime,
            }
            : null;
    }
}
