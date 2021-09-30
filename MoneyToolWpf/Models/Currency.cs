namespace MoneyToolWpf
{
	public enum Currency { EUR = 0, USD = 1, RUB = 2, Неопределен = 3 }
	public static class CurrencyExtensions
	{
		//public static string GetString(this Currency type)
		//{
		//	switch (type)
		//	{
		//		case Currency.EUR: return "€";
		//		case Currency.USD: return "$";
		//		case Currency.RUB: return "₽";
		//		default: return type.ToString();
		//	}
		//}

		//public static Currency SetString(string name)
		//{
		//	switch (name)
		//	{
		//		case "€": return Currency.EUR;
		//		case "$": return Currency.USD;
		//		case "₽": return Currency.RUB;
		//		default: return Currency.Неопределен;
		//	}
		//}

		/// <summary>Возвращает курс в рублях для одной единицы валюты, передаваемой как параметр</summary>
		public static decimal CurrencyRateInRubles(Currency currency) // по-хорошему, нужен II параметр DateTime date
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
}
