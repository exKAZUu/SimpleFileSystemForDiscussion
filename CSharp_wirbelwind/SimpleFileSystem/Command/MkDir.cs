using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Command
{
	class MkDir : ICommand
	{
		#region ICommand メンバー

		public void Execute(string[] args, IList<Directory> directoryies)
		{
			if(args.Length != 1)
				throw new ArgumentException();

			string[] info = args[0].Split('/');
			if(info.Length != 1)
				throw new ArgumentException();

			string dirname = info[0];

			bool isExist = directoryies.Any(dir => dir.Name.Equals(dirname));
			if(isExist)
				throw new Exception("Directoryが存在しています");

			directoryies.Add(new Directory(dirname));
		}

		#endregion
	}
}
