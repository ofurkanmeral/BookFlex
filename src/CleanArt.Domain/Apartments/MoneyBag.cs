using CleanArt.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Domain.Apartments
{
    public record MoneyBag
    {
        private readonly List<Money> _items = [];

        public void Add(Money money)
        {
            _items.Add(money);
        }

        public IReadOnlyCollection<Money> TotalByCurrency()
        {
            return _items
                .GroupBy(x => x.Currency)
                .Select(x=>new Money(x.Sum(x=>x.Amount),x.Key))
                .ToList();
        }
    }
}
