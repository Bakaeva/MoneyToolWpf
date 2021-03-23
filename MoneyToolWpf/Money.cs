using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyTool
{
    public enum Currency { EUR, USD, RUB }

    public class Money
    {
        public decimal Summa { get; set; }
        public Currency Currency { get; set; }

        // Возвращает курс в рублях для валюты, передаваемой как параметр
        static decimal currencyRate(Currency currency) // по-хорошему нужен II параметр DateTime date
                                                // и, в зависимости от даты, динамический расчёт курса (на основе БД курсов валют)
        {
            switch (currency)
            {
                case Currency.EUR: return 88.1173M;
                case Currency.USD: return 73.6582M;
                case Currency.RUB: return 1;
                default: return 1;
            }
        }

        public static bool operator ==(Money a, Money b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;

            if ((object)a == null) return (object)b == null;

            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public static bool operator >(Money a, Money b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return false;

            if (a == null) return false;

            return a.CompareTo(b) == 1;
        }

        public static bool operator <(Money a, Money b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return false;

            if (a == null) return b != null;

            return a.CompareTo(b) == -1;
        }

        public int CompareTo(Money money)
        {
            if (money == null) return 1;

            decimal summaInRub = Math.Round(Summa * currencyRate(Currency), 2);
            decimal othersummaInRub = Math.Round(money.Summa * currencyRate(money.Currency), 2);

            return summaInRub > othersummaInRub ? 1 :
                summaInRub < othersummaInRub ? -1 : 0;
        }

        /// <summary>Возвращает сумму в рублях</summary>
        public static Money operator +(Money a, Money b)
        {
            return new Money
            {
                Summa = Math.Round(a.Summa * currencyRate(a.Currency), 2) + Math.Round(b.Summa * currencyRate(b.Currency), 2),
                Currency = Currency.RUB
            };
        }

        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    }
}
