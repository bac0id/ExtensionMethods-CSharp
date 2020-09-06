using System;

public static class FloatExtensions
{
	public static float RoundToNearest(this float value, float stepSize) {
		if (stepSize <= 0f) {
			return value;
		}
		int a = (int)Math.Round(value / stepSize);
		return a * stepSize;
	}

	public static float Quantize(this float value, float stepSize) {
		if (stepSize <= 0f) {
			return value;
		}
		return (float)Math.Floor(value / stepSize) * stepSize;
	}

	public static bool NearlyEqual(this float a, float b, float epsilon) {
		float num = Math.Abs(a * epsilon);
		return Math.Abs(a - b) <= num;
	}
}
