using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem
{
	class File
	{

		public File(string filename)
		{
			Name = filename;
		}

		public string Name { get; set; }

		public string ToString()
		{
			return Name;
		}
	}
}
