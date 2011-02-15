using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Command
{
	class Mv : ICommand
	{
		#region ICommand メンバー

		public void Execute(string[] args, IList<Directory> directoryies)
		{
			if(args.Length != 2)
				throw new ArgumentException();

			string[] infos = args[0].Split('/');
			if(infos.Length < 1 && 2 < infos.Length)
				throw new ArgumentException();

			string[] infos2 = args[1].Split('/');
			if(infos.Length == 1)
			{
				if(infos2.Length != 1)
					throw new ArgumentException();

				MvDir(infos[0], infos2[0], directoryies);

			}
			if(infos.Length == 2)
			{
				if(infos2.Length != 2)
					throw new ArgumentException();

				MvFile(infos[0], infos[1], infos2[0], infos2[1], directoryies);

			}

		}

		private void MvFile(string dirname, string filename, 
			string newdirname, string newfilename, IList<Directory> directoryies)
		{
			var srcdir = directoryies.SingleOrDefault(dir => dir.Name.Equals(dirname));
			if(srcdir == null)
				throw new Exception("移動元Fileが存在しません");

			if(!srcdir.Contains(filename))
				throw new Exception("移動元Fileが存在しません");

			var dstdir = directoryies.SingleOrDefault(dir => dir.Name.Equals(dirname));
			if(dstdir == null)
				throw new Exception("移動元Fileが存在しません");

			if(!dstdir.Contains(filename))
				throw new Exception("移動元Fileが存在しません");

			var file = srcdir.Get(filename);
			srcdir.Remove(filename);
			file.Name = newfilename;
			dstdir.Add(file);
		}

		private void MvDir(string dirname, string newdirname, IList<Directory> directoryies)
		{
			bool isExist = directoryies.Any(dir => dir.Name.Equals(newdirname));
			if(isExist)
				throw new Exception("移動先のDirectoryは存在します");

			var dirobj = directoryies.SingleOrDefault(dir => dir.Name.Equals(dirname));
			if(dirobj == null)
				throw new Exception("移動元のDirectoryは存在します");

			dirobj.Name = newdirname;
		}

		#endregion
	}
}
