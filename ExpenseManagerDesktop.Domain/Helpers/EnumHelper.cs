using ExpenseManagerDesktop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Domain.Helpers
{
    public static class EnumHelper
    {
        public static List<DataItem<TKey>> GetEnumList<T, TKey>() where T : Enum
        {
            List<DataItem<TKey>> enumList = new List<DataItem<TKey>>();

            var values = Enum.GetValues(typeof(T));
            foreach (T value in values)
            {
                var key = Convert.ChangeType(value, typeof(TKey));

                var displayAttribute = value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DisplayAttribute), false)
                    .FirstOrDefault() as DisplayAttribute;

                string displayName = displayAttribute?.Name ?? value.ToString();

                enumList.Add(new DataItem<TKey>
                {
                    Key = (TKey)key,
                    Value = displayName
                });
            }

            return enumList;
        }
    }
}
