using System;
using System.IO;
using System.Reflection;

namespace InputInterceptorNS {

	internal static class Helpers {

		public static Byte[] GetResource(String name)
		{
			TypeInfo typeInfo = typeof(Helpers).GetTypeInfo();
			Assembly assembly = typeInfo.Assembly;
			InputInterceptor.DPath = typeInfo.Namespace + ".Resources." + name;
			using (Stream stream = assembly.GetManifestResourceStream(InputInterceptor.DPath))
			{
				Byte[] result;

				if(null == stream)
				{
					Console.WriteLine("InputInterceptor.Helpers.GetResource():  " +
						InputInterceptor.DPath + " not found or invalid");
					return null;
				}
		
				result = new Byte[stream.Length];
				stream.Read(result, 0, (Int32)stream.Length);
				return result;
			}
		}
	}
}
