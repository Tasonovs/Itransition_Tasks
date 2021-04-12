using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace N3
{
	class Program
	{
		static void Main(string[] args)
		{
			GameMaster gameMaster = new GameMaster(args);
			gameMaster.Start();
		}

	}
}
