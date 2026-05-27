using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Domain.Shared
{
    public record Currency
    {
        internal static readonly Currency None = new("");
        public static readonly Currency USD = new Currency("USD");
        public static readonly Currency EUR = new Currency("EUR");
        public string Code { get; init; }

        private Currency(string code) => Code = code;

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code) ??
                throw new ApplicationException("The currency code is invalid");
        }

        public static readonly IReadOnlyCollection<Currency> All = new[]
        {
            USD, EUR
        };
    }
}
