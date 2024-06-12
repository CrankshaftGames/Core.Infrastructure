namespace Core.Infrastructure.Utils
{
	public interface IRandom
	{
		float GetValue();
		int GetValueFromRange(int min, int max);
		float GetValueFromRange(float min, float max);
	}
}