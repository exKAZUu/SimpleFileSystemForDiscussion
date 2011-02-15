using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Command
{
	class MkFile : ICommand
	{
		#region ICommand メンバー

		public void Execute(string[] args, IList<Directory> directoryies)
		{
			if(args.Length != 1)
				throw new ArgumentException();

			string[] fileinfos = args[0].Split('/');

			if(fileinfos.Length != 2)
				throw new ArgumentException();

			var dirname = fileinfos[0];
			var filename = fileinfos[1];

			var targetdir = directoryies.SingleOrDefault(dir => 
			{
				return dir.Name.Equals(dirname);
			});

			if(targetdir == null)
				throw new Exception("Directoryが存在しません");

			if(targetdir.Contains(filename))
				throw new Exception("Fileがすでに存在します");

			targetdir.Add(new File(filename);
		}

		#endregion
	}
}
