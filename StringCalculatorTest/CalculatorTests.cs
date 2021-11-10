using NUnit.Framework;
using System;
using StringCalculator;

namespace StringCalculatorTest
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}
		/*1. Create a simple String calculator with a method int Add(string numbers)
				1. The method can take 0, 1 or 2 numbers, and will return their sum(for an empty string it will
				return 0) for example "" or "1" or "1,2"
				2. Start with the simplest test case of an empty string, then move to one and two numbers
		2. Allow the Add method to handle an unknown amount of numbers
		
		3. Allow the Add method to handle new lines between numbers(in addition to commas).
				1. the following input is ok: "1\n2,3" (will equal 6)
			   2. the following input DOES NOT need to be handled: "1,\n" (not need to prove it - just clarifying)
		4. Support different delimiters
				1. To change a delimiter, the beginning of the string will contain a separate line specifying the
				custom delimiter.This input looks like this: "//{delimiter}\n{numbers...}" (Note that the curly
				braces are representing the sections of the input and are not input formatting).
				2. For example: "//;\n1;2" should return a result of 3 because the delimiter is now ‘;’.
				3. The first line is optional(all existing scenarios should still be supported).
				4. Do not worry about supporting the specification of ‘\n’ as an explicit custom delimiter. New lines
				should always be supported as delimiters in your number string.
				5. Calling Add with a negative number will throw an exception "negatives not allowed" - and the negative
				that was passed, if there are multiple negatives, show all of them in the exception message
				6. Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2*/

		
		[Test]
		public void CreateASimpleStringCalculator_AStringCalculatorIsCreated()
		{
			var stringCalculator = new Calculator();

			Assert.IsTrue(stringCalculator is Calculator);
		}

		[Test]
		[TestCase("")]
		public void CreateASimpleStringCalculatorThatCanAddUpto3Numbers_ReturnsZeroForEmptyString(string numbersInString)
		{
			//1.1
			int expectedResult = 0;
						
			//Arrange 
			var stringCalculator = new Calculator();

			var result = stringCalculator.Add(numbersInString);


			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		[TestCase("1")]
		public void CreateASimpleStringCalculatorThatCanAddUpto3Numbers_ReturnsNumberForSingleNumber(string numbersInString)
		{
			//1.2
			int expectedResult = 1;

			//Arrange 
			var stringCalculator = new Calculator();

			var result = stringCalculator.Add(numbersInString);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		[TestCase("1,2")]
		public void CreateASimpleStringCalculatorThatCanAddUpto3Numbers_ReturnsSumForXNumbers(string numbersInString)
		{
			//2.
			int expectedResult = 3;

			//Arrange 
			var stringCalculator = new Calculator();

			var result = stringCalculator.Add(numbersInString);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}


		/*3. Allow the Add method to handle new lines between numbers(in addition to commas).
			1. the following input is ok: "1\n2,3" (will equal 6)
			2. the following input DOES NOT need to be handled: "1,\n" (not need to prove it - just clarifying)*/

		[Test]
		[TestCase("1\n2, 3")]
		public void StringCalculatorHandlesNewLines_ReturnsSumForNumber(string numbersInString)
		{
			//3.1 and 3.2
			int expectedResult = 6;

			//Arrange 
			var stringCalculator = new Calculator();

			var result = stringCalculator.Add(numbersInString);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		/*	4. Support different delimiters
			1. To change a delimiter, the beginning of the string will contain a separate line specifying the
			custom delimiter.This input looks like this: "//{delimiter}\n{numbers...}" (Note that the curly
			braces are representing the sections of the input and are not input formatting).
			2. For example: "//;\n1;2" should return a result of 3 because the delimiter is now ‘;’.
			3. The first line is optional(all existing scenarios should still be supported).
			4. Do not worry about supporting the specification of ‘\n’ as an explicit custom delimiter. New lines
			should always be supported as delimiters in your number string.
			5. Calling Add with a negative number will throw an exception "negatives not allowed" - and the negative
			that was passed, if there are multiple negatives, show all of them in the exception message
			6. Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2*/


		[Test]
		[TestCase("//;\n1;2")]
		public void StringCalculatorHandlesMultipleDelimiters_ReturnsSumForNumbers(string numbersInString)
		{
			//4.1
			int expectedResult = 3;

			//Arrange 
			var stringCalculator = new Calculator(new char[] { '/', ',', ';' }) ;

			var result = stringCalculator.Add(numbersInString);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}


		[Test]
		[TestCase("//;\n-1;2;-4")]
		public void StringCalculatorHandlesNegativeNumbers_ThrowsExceptionForNegativeNumbers(string numbersInString)
		{
			//4.1
			int expectedResult = 3;

			//Arrange 
			var stringCalculator = new Calculator(new char[] { '/', ',', ';' });

			//Assert
			Assert.Throws<Exception>(() =>stringCalculator.Add(numbersInString));
		}

		[Test]
		[TestCase("//;\n1;2;4000")]
		public void StringCalculatorIgnoresNumbersOver1000_NumbersOver1000Ignored(string numbersInString)
		{
			//4.6
			int expectedResult = 3;

			//Arrange 
			var stringCalculator = new Calculator(new char[] { '/', ',', ';' });
			var result = stringCalculator.Add(numbersInString);


			//Assert
			Assert.AreEqual(expectedResult, result);
		}
	}
}