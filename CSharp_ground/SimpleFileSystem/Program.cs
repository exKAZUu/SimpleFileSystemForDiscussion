using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace SimpleFileSystem {

	static class Program {

		static readonly Dictionary<string, List<string>> Dirs = new Dictionary<string, List<string>>();

		static void Main(string[] args) {
			while (true) {
				Console.Write("sfs> ");
				var line = Console.ReadLine();
				if (line == "exit") return;
				try {
					Execute(line);
				}
				catch (Exception e) {
					Console.WriteLine(e.Message);
				}
			}
		}

		private static void Execute(string line) {
			var input = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
			if (input.Length == 0)
				return;
			switch (input[0]) {
				case "mkfile":
					if (input.Length != 2)
						throw new ArgumentException("引数の数が正しくありません。");
					MakeFile(input[1]);
					return;
				case "mkdir":
					if (input.Length != 2)
						throw new ArgumentException("引数の数が正しくありません。");
					MakeDir(input[1]);
					return;
				case "rm":
					if (input.Length != 2)
						throw new ArgumentException("引数の数が正しくありません。");
					Remove(input[1]);
					return;
				case "mv":
					if (input.Length != 3)
						throw new ArgumentException("引数の数が正しくありません。");
					Move(input[1], input[2]);
					return;
				case "ls":
					if (input.Length != 1)
						throw new ArgumentException("引数の数が正しくありません。");
					List();
					return;
				default:
					throw new ArgumentException("そのコマンドは存在しません。");
			}
		}

		private static void MakeDir(string dirName) {
			CheckDirectoryNone(dirName);
			Dirs[dirName] = new List<string>();
		}

		private static void MakeFile(string filePath) {
			var pair = filePath.Split(new[] { '/' }, 2, StringSplitOptions.RemoveEmptyEntries);
			if (pair.Length != 2)
				throw new ArgumentException("ファイルの形式として正しくありません。");
			var dirName = pair[0];
			var fileName = pair[1];
			CheckFileNone(dirName, fileName);
			Dirs[dirName].Add(fileName);
		}

		private static void Remove(string path) {
			var splitted = path.Split(new[] { '/' }, 2, StringSplitOptions.RemoveEmptyEntries);
			switch (splitted.Length) {
				case 1: {
						var dirName = path;
						CheckDirectoryExist(dirName);
						Dirs.Remove(dirName);
						return;
					}
				case 2: {
						var dirName = splitted[0];
						var fileName = splitted[1];
						CheckFileExist(dirName, fileName);
						Dirs[dirName].Remove(fileName);
						return;
					}
			}
			throw new ArgumentException("入力が正しくありません。");
		}

		private static void List() {
			foreach (var dir in Dirs) {
				Console.WriteLine(dir.Key + '/');
				foreach (var file in dir.Value) {
					Console.WriteLine(dir.Key + '/' + file);
				}
			}
		}

		private static void Move(string src, string dst) {
			var srcPair = src.Split(new[] { '/' }, 2, StringSplitOptions.RemoveEmptyEntries);
			var dstPair = dst.Split(new[] { '/' }, 2, StringSplitOptions.RemoveEmptyEntries);
			if (srcPair.Length != dstPair.Length)
				throw new ArgumentException("入力が正しくありません。");
			switch (srcPair.Length) {
				case 1:
					CheckDirectoryExist(src);
					CheckDirectoryNone(dst);
					Dirs[dst] = Dirs[src];
					Dirs.Remove(src);
					return;
				case 2:
					CheckFileExist(srcPair[0], srcPair[1]);
					CheckFileNone(dstPair[0], dstPair[1]);
					Dirs[dstPair[0]].Add(dstPair[1]);
					Dirs[srcPair[0]].Remove(srcPair[1]);
					return;
			}
			throw new ArgumentException("入力が正しくありません。");
		}

		private static void CheckDirectoryExist(string dirName) {
			if (Dirs.ContainsKey(dirName) == false)
				throw new ArgumentException("ディレクトリ " + dirName + " は存在していません。");
		}

		private static void CheckDirectoryNone(string dirName) {
			if (Dirs.ContainsKey(dirName))
				throw new ArgumentException("ディレクトリ " + dirName + " は存在しています。");
		}

		private static void CheckFileExist(string dirName, string fileName) {
			CheckDirectoryExist(dirName);
			if (Dirs[dirName].Contains(fileName) == false)
				throw new ArgumentException("ファイル " + fileName + " は存在していません。");
		}

		private static void CheckFileNone(string dirName, string fileName) {
			CheckDirectoryExist(dirName);
			if (Dirs[dirName].Contains(fileName))
				throw new ArgumentException("ファイル " + fileName + " は存在しています。");
		}
	}
}
