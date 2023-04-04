namespace NewShore.Infrastructure.Serialization
{
	using System.Text.Json;

	public static class Serializer
	{
		public static string Serialize<T>( T source )
		{
			string target;

			try
			{
				target = JsonSerializer.Serialize( source );
			}
			catch( Exception )
			{
				target = string.Empty;
			}

			return target;
		}

		public static T Deserialize<T>( string json )
		{
			T? result;

			try
			{
				result = JsonSerializer.Deserialize<T>( json );
			}
			catch( Exception )
			{
				result = default( T );
			}

			return result;
		}
	}
}
