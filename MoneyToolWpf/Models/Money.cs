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
                Summa = Math.Round(a.Summa * CurrencyExtensions.CurrencyRateInRubles(a.Currency), 2)
                + Math.Round(b.Summa * CurrencyExtensions.CurrencyRateInRubles(b.Currency), 2),
                Currency = Currency.RUB
            };
        }

        public override bool Equals(object obj)
        {
            return (obj is Money && this == (obj as Money));
        }

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        /// <summary>Вернёт 0, если this==money; вернёт -1, если this меньше money; вернёт 1, если this больше money</summary>
        public int CompareTo(Money money)
        {
            if (money == null)
                throw new ArgumentNullException();

            decimal summaInRub = Math.Round(Summa * CurrencyExtensions.CurrencyRateInRubles(Currency), 2);
            decimal othersummaInRub = Math.Round(money.Summa * CurrencyExtensions.CurrencyRateInRubles(money.Currency), 2);

            return summaInRub > othersummaInRub ? 1 :
                summaInRub < othersummaInRub ? -1 : 0;
        }
    }

    public static class MoneyExtensions
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
