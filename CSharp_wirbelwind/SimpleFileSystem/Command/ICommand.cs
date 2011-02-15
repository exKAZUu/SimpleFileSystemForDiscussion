using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem.Command
{
	interface ICommand
	{
		public void Execute(string[] args, IList<Directory> directoryies);
	}
}
