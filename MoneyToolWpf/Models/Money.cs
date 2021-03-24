using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyToolWpf
{
    public class Money
    {
        public decimal Summa { get; set; }
        public Currency Currency { get; set; }

        public static bool operator ==(Money a, Money b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;

            if ((object)a == null)
                return (object)b == null;
            else if ((object)b == null) return false;

            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public static bool operator >(Money a, Money b)
        {
            if (System.Object.ReferenceEquals(a, b) || a == null || b == null)
                return false;
            return a.CompareTo(b) == 1;
        }

        public static bool operator <(Money a, Money b)
        {
            if (System.Object.ReferenceEquals(a, b) || a == null || b == null)
                return false;
            return a.CompareTo(b) == -1;
        }

        /// <summary>Возвращает сумму в рублях</summary>
        public static Money operator +(Money a, Money b)
        {
            if (a == null || b == null) return null;
            return new Money
            {
                Summa = Math.Round(a.Summa * CurrencyRate(a.Currency), 2) + Math.Round(b.Summa * CurrencyRate(b.Currency), 2),
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

        /// <summary>Вернёт 0, если this==money; вернёт -1, если this меньше money; вернёт 1, если this больше money</summary>
        public int CompareTo(Money money)
        {
            if (this == null || money == null)
                throw new Exception("Сравниваемые экземпляры типа Money не могут быть равны null!");

            decimal summaInRub = Math.Round(Summa * CurrencyRate(Currency), 2);
            decimal othersummaInRub = Math.Round(money.Summa * CurrencyRate(money.Currency), 2);

            return summaInRub > othersummaInRub ? 1 :
                summaInRub < othersummaInRub ? -1 : 0;
        }

        /// <summary>Возвращает курс в рублях для валюты, передаваемой как параметр</summary>
        public static decimal CurrencyRate(Currency currency) // по-хорошему нужен II параметр DateTime date
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
    }

    public static class MoneyExtentions
    {
        public static Money Add(Money a, Money b)
        {
            return a + b;
        }

        /// <summary>Вернёт 0, если a==b; вернёт -1, если a меньше b; вернёт 1, если a больше b</summary>
        public static int Compare(Money a, Money b)
        {
            return a.CompareTo(b);
        }
    }
}
