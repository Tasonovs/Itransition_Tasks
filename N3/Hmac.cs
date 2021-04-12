using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace N3
{
	public static class Hmac
	{
		public static (string textHashHex, string keyHex) Generate(string text)
		{
			byte[] keyBytes = new byte[16];
			using (var random = RandomNumberGenerator.Create())
				random.GetNonZeroBytes(keyBytes);

			string keyBase64 = Convert.ToBase64String(keyBytes);

			var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(keyBase64)); //It works only with Base64 key
			string keyHex = Convert.ToHexString(hmac.Key).ToLower();

			var textHashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(text));
			var textHashHex = Convert.ToHexString(textHashBytes).ToLower();

			return (textHashHex, keyHex);
		}
	}
}
