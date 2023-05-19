using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Domain.ValueObjects
{
    public class DataItem<T>
    {
        public T Key { get; set; }
        public string Value { get; set; }
    }
}
