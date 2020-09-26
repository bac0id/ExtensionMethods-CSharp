using System;

public static class RandomExtension
{
	/// <summary>
	///		Returns a random number within a specified range.
	/// </summary>
	/// <param name="random"></param>
	/// <param name="minValue">
	///		The inclusive lower bound of the random number returned.
	/// </param>
	/// <param name="maxValue">
	///		The exclusive upper bound of the random number returned.
	///		<paramref name="maxValue"/> must be greater than or equal to minValue.
	///	</param>
	/// <param name="digit">
	///		The number of fractional digits in the return value.
	///	</param>
	/// <returns>
	///		A double-precision floating point number greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>.
	/// </returns>
	public static double NextDouble(this Random random, double minValue, double maxValue, int digit) {
		return Math.Round(random.NextDouble() * (maxValue - minValue) + minValue, digit);
	}
}