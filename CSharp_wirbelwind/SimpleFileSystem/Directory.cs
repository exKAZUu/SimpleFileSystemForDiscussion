using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSystem
{
	class Directory
	{
		private SortedList<string, File> _files;
		public Directory(string dirname)
		{
			Name = dirname;
		}
		public string Name { get; set; }


		internal bool Contains(string filename)
		{
			return _files.Any(pair =>
			{
				return pair.Value.Name.Equals(filename);
			});
		}

		internal void Remove(string filename)
		{
			_files.Remove(filename);
		}

		internal File Get(string filename)
		{
			return _files[filename];
		}

		internal void Add(File file)
		{
			_files.Add(file.Name, file);
		}

		internal string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine(Name + "/");
			foreach(var file in _files)
				builder.AppendFormat("{0}/{1}\n", Name, file.Value.Name);
			return builder.ToString();
		}
	}
}
