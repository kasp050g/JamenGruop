using Microsoft.Xna.Framework;
using System;

namespace JamenGruop_RTS
{
	public static class Helper
	{
		public static Random random = new Random();

		/// <summary>
		/// Calculate a random number between the minValue and the maxValue.
		/// </summary>
		/// <param name="minValue">minValue</param>
		/// <param name="maxValue">maxValue</param>
		/// <returns></returns>
		public static float GetRandomValue(int minValue, int maxValue)
		{
			return random.Next(minValue, maxValue);
		}

		/// <summary>
		/// Calculate a random number between 0 and the value.
		/// </summary>
		/// <param name="value">maxValue</param>
		/// <returns></returns>
		public static float GetRandomValue(int value)
		{
			return GetRandomValue(0, value);
		}

		/// <summary>
		/// Calculate Sine 
		/// </summary>
		/// <param name="degrees"></param>
		/// <returns></returns>
		public static float Sin(float degrees)
		{
			return (float)Math.Sin(degrees / 180f * Math.PI);
		}

		/// <summary>
		/// Calculate cosine 
		/// </summary>
		/// <param name="degrees"></param>
		/// <returns></returns>
		public static float Cos(float degrees)
		{
			return (float)Math.Cos(degrees / 180f * Math.PI);
		}

		public static float CalculateAngleBetweenPositions(Vector2 fromPosition, Vector2 toPosition)
		{
			// Calculate position distance in Vector2
			Vector2 vectorTowardsToVector = toPosition - fromPosition;

			// Distance from toPosition.
			float distance = vectorTowardsToVector.Length();

			// Only do calculate if distance is greater than 0.
			if (distance > 0)
			{
				float dot = Vector2.Dot
				(
					// Vector point right.
					new Vector2(1, 0),
					// Vector pointing towards destination.
					Vector2.Normalize(vectorTowardsToVector)
				);

				// Calculate degrees.
				float degrees = MathHelper.ToDegrees((float)Math.Acos(dot));

				// TODO : donno what to write here
				if (vectorTowardsToVector.Y < 0)
				{
					degrees = 360 - degrees;
				}

				return degrees;
			}
			else
			{
				return 0;
			}
		}
	}
}
