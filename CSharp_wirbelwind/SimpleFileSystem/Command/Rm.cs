using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Command
{
	class Rm : ICommand
	{
		#region ICommand メンバー

		public void Execute(string[] args, IList<Directory> directoryies)
		{
			if(args.Length != 1)
				throw new ArgumentException();

			string[] infos = args[0].Split('/');
			if(infos.Length < 1 && 2 < infos.Length)
				throw new ArgumentException();

			if(infos.Length == 1)
				RmDir(infos[0], directoryies);
			if(infos.Length == 2)
				RmFile(infos[0], infos[1], directoryies);
		}

		private void RmFile(string dirname, string filename, IList<Directory> directoryies)
		{
			var dirobj = directoryies.SingleOrDefault(dir => dir.Name.Equals(dirname));
			if(dirobj == null)
				throw new Exception("Fileが存在しません");

			if(!dirobj.Contains(filename))
				throw new Exception("Fileが存在しません");

			dirobj.Remove(filename);
		}

		private void RmDir(string dirname, IList<Directory> directoryies)
		{
			var dirobj = directoryies.SingleOrDefault(dir => dir.Name.Equals(dirname));
			if(dirobj == null)
				new Exception("Directoryが存在しません");

			directoryies.Remove(dirobj);
		}

		#endregion
	}
}
