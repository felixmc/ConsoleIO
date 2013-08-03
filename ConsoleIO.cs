using System;

namespace com.felixmc.ConsoleTools
{
    public static class ConsoleIO
    {
        public static string GetLine ()
        {
            return Console.ReadLine();
        }

		public static void Print (string message)
		{
			Console.Write(message);
		}

		public static void PrintLine (string message)
		{
			Console.WriteLine(message);
		}

		private static void PrintError (string message)
		{
			Console.WriteLine("Error: " + message);
		}

		private static T ParseString<T> (string input)
		{
			return (T)Convert.ChangeType(input, typeof(T));
		}

		public static T PromptForValue<T> (string message)
		{
			T value;

			do
			{
				Print(message);
				string input = GetLine();
				try
				{
					value = ParseString<T>(input);
					return value;
				}
				catch (FormatException e)
				{
					PrintError("Input string is not valid.");
				}
				catch (OverflowException e)
				{
					PrintError("The parsed input value is too large for a(n) " + typeof(T).Name + ".");
				}
			} while (true);
		}

		private static T PromptBoundedValue<T> (string message, T min, T max) where T : IComparable
		{
			T input;
			bool isFirst = true;
			do
			{
				if (!isFirst) PrintError("Input needs to be between " + min + " and " + max + ".");
				else isFirst = false;

				input = PromptForValue<T>(message);
			} while (input.CompareTo(min) == -1 || input.CompareTo(max) == 1);
			return input;
		}

		public static int GetInt (string message, int min = Int32.MinValue, int max = Int32.MaxValue)
		{
			return PromptBoundedValue(message, min, max);
		}

		public static double GetDouble (string message, double min = Double.MinValue, double max = Double.MaxValue)
		{
			return PromptBoundedValue(message, min, max);
		}

		public static short GetShort (string message, short min = Int16.MinValue, short max = Int16.MaxValue)
		{
			return PromptBoundedValue(message, min, max);
		}

		public static float GetFloat (string message, float min = Single.MinValue, float max = Single.MaxValue)
		{
			return PromptBoundedValue(message, min, max);
		}

		public static decimal GetDecimal (string message, decimal min = Decimal.MinValue, decimal max = Decimal.MaxValue)
		{
			return PromptBoundedValue(message, min, max);
		}

		public static long GetLong (string message, long min = Int64.MinValue, long max = Int64.MaxValue)
		{
			return PromptBoundedValue(message, min, max);
		}

		public static char GetChar (string message, char min = Char.MinValue, char max = Char.MaxValue)
		{
			return PromptBoundedValue(message, min, max);
		}

		public static bool GetBool (string message)
		{
			return PromptForValue<bool>(message);
		}

		public static string GetString (string message)
		{
			Print(message);
			return GetLine();
		}
    }
}