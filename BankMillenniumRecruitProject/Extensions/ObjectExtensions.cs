using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankMillenniumRecruitProject.Extensions
{
    public static class ObjectExtensions
    {
        public static void CheckIsNotNull<T>(this T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException($"Element {nameof(entity)} cannot be null");
            }
        }
    }
}
