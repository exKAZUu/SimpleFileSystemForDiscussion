using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Command
{
	class Ls : ICommand
	{
		#region ICommand メンバー

		public void Execute(string[] args, IList<Directory> directoryies)
		{
			if(args.Length != 0)
				throw new ArgumentException();

			StringBuilder builder = new StringBuilder();
			foreach(var dir in directoryies)
			{
				builder.AppendLine(dir.ToString());
			}
		}

		#endregion
	}
}
