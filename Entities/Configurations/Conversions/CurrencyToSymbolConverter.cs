using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreMovies.Entities.Configurations.Conversions
{
    public class CurrencyToSymbolConverter : ValueConverter<Currency, string>
    {
        public CurrencyToSymbolConverter() : base(value => MappingCurrencyToString(value), value => MappingStringToCurrency(value))
        {
            
        }

        private static string MappingCurrencyToString(Currency value)
        {
            return value switch
            {
                Currency.ColonCR => "₡",
                Currency.USDollar => "$",
                Currency.Euro => "€",
                _ => "",
            };
        }

        private static Currency MappingStringToCurrency(string value)
        {
            return value switch
            {
                "₡" => Currency.ColonCR,
                "$" => Currency.USDollar,
                "€" => Currency.Euro,
                _ => Currency.Unknown
            };
        }
    }
}
