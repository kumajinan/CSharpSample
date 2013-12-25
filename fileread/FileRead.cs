using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace fileread
{
	public class FileRead
	{
		private const string FILE_PATH = @"../../gutenberg.csv";
		private readonly string[] DELIMITER = {"\",\""};

		private StringBuilder sb;
		private List<List<String>> dataList = new List<List<string>>();

		public FileRead ()
		{
			sb = new StringBuilder();
			sb.Capacity = 256;
		}

		public void Read() 
		{
			//ファイル読み込み
			StreamReader cReader = null;
			try 
			{
				cReader = new StreamReader(FILE_PATH, System.Text.Encoding.Default);
				while (cReader.Peek() >= 0) 
				{
					string stBuffer = cReader.ReadLine();
					sb.Append(stBuffer + System.Environment.NewLine);

					//1行分のデータをdataListに追加する
					List<string> addList = new List<string>();
					var values = stBuffer.Split(DELIMITER, StringSplitOptions.None);
					foreach (var value in values)
					{
						char[] charsToTrim = { '\"'};
						addList.Add(value.Trim(charsToTrim));
					}
					dataList.Add(addList);
				}
			}
			finally
			{
				if (cReader != null) {
					cReader.Close();
				}
			}
		}

		public override string ToString() 
		{
			return sb.ToString();
		}

		public void PrintCsvData() 
		{
			foreach (var list in dataList) 
			{
				foreach (var value in list)  
				{
					Console.Write(value + " ");
				}
				Console.WriteLine ();
			}
		}
		
		public string getCharcter(String targetStr)
		{
			var x = 1;
			var y = 1;

			foreach (var list in dataList) 
			{
				foreach (var value in list)  
				{
					//検索対象文字と一致した場合は、使用済扱いでnullをセットしして、場所の情報を返却
					if (targetStr.Equals (value)) 
					{
						list [x - 1] = "";
						return x.ToString().PadLeft(2) + "," + y.ToString().PadLeft(2) + " = " + value;
					}
					x += 1;
				}
				x = 1;
				y += 1;
			}

			return targetStr + " is not found";
		}

	}
}

