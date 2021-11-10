using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StringCalculator
{
	public class Calculator
	{
		private readonly char[]? _delimiters;
		private static int? _ignoreValuesOver;

		public Calculator(char[]? delimiters = null, int ignoreValuesOver = 1000)
		{
			_delimiters = delimiters ?? new char[] {','};
			_ignoreValuesOver = ignoreValuesOver;
		}

		public int Add(string numbersInString)
		{
			if(string.IsNullOrEmpty(numbersInString)) return 0;

			numbersInString = numbersInString.Trim().Replace("\n", ",");
			
			if (_delimiters.Any(x=>numbersInString.Contains(x)))
			{
				var individualNumbers = numbersInString.Split(_delimiters);
				return individualNumbers.Sum(x => CleansedNumber(x));
			}

			return int.Parse(numbersInString);
		}

		private static int CleansedNumber(string x)
		{
			int cleanNumber  = 0;
			
			if (string.IsNullOrEmpty(x)) return cleanNumber;

			if (int.TryParse(x, out cleanNumber))
			{
				if (cleanNumber < 0) throw new Exception($"negatives not allowed: input = {cleanNumber}");

				if (cleanNumber > _ignoreValuesOver) return 0;

				return cleanNumber;
			}

			return cleanNumber;
		}
	}
}