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
	}
}
