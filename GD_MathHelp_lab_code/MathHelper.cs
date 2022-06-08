using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_MathHelp_lab_code
{
	public delegate void SetTextDelegate(string text);
	public class Class1
	{
		private StringBuilder solutionHistory;
		int format = 200; // после 200q записи будет выполняться перенос строки
		static Class1()
		{

		}

		public double Func1(double end, SetTextDelegate setText)
		{
			solutionHistory = new StringBuilder();

			if (end == 1)
			{
				solutionHistory.Append("1");
				setText(solutionHistory.ToString());
				return 1;
			}

			double n = 1;
			double result = 1;
			solutionHistory.Append("1");

			while (n < end)
			{
				if (n % 2 == 0)
				{
					result += (n + 1);
					solutionHistory.Append($" + {n + 1}");
				}
				else
				{
					result -= Math.Sqrt(n + 1);
					solutionHistory.Append($" - sqrt({n + 1})");
				}

				if (n > format) // небольшое форматирование для сохранения в текстовый файл
				{
					solutionHistory.AppendLine();
					format += format;
				}

				n++;
			}

			setText(solutionHistory.ToString());
			return Math.Round(result, 5);
		}

		//public int Func2(int n, SetTextDelegate setText) // рекурсия, долго работает
		//{
		//	if (n == 1)
		//	{
		//		setText("1^1");
		//		return 1;
		//	}
		//	setText($"{n}^{n} + ");

		//	return (int)Math.Pow(n, n) + Func2(n - 1, setText);
		//}

		public int Func2(int end, SetTextDelegate setText) // без рекурсии
		{
			solutionHistory = new StringBuilder();

			if (end == 1)
			{
				solutionHistory.Append("1^1");
				setText(solutionHistory.ToString());
				return 1;
			}

			int n = 1;
			int result = 0;

			while (n <= end)
			{
				result += (int)Math.Pow(n, n);

				if (n != 1)
				{
					solutionHistory.Append($" + ");
				}
				solutionHistory.Append($"{n}^{n}");

				if (n > format) // форматирование для сохранения в текстовый файл
				{
					solutionHistory.AppendLine();
					format += format;
				}

				n++;
			}

			setText(solutionHistory.ToString());
			return result;
		}

		//      public double Func3(double n, SetTextDelegate setText)// рекурсия, долго работает
		//{
		//	if (n == 1)
		//	{
		//		setText("1/1");
		//		return 1;
		//	}
		//	setText($"{1}/{n} + ");

		//	return Math.Round(1 / n + Func3(n - 1, setText), 5);
		//}

		public double Func3(double end, SetTextDelegate setText) // без рекурсии
		{
			solutionHistory = new StringBuilder();

			if (end == 1)
			{
				solutionHistory.Append("1/1");
				setText(solutionHistory.ToString());
				return 1;
			}

			double n = 1;
			double result = 0;

			while (n <= end)
			{
				result += 1 / n;

				if (n != 1)
				{
					solutionHistory.Append($" + ");
				}
				solutionHistory.Append($"{1}/{n}");

				if (n > format) // форматирование для сохранения в текстовый файл
				{
					solutionHistory.AppendLine();
					format += format;
				}

				n++;
			}

			setText(solutionHistory.ToString());
			return Math.Round(result, 5);
		}
	}
}
