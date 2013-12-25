using System;

namespace fileread
{
	class MainClass
	{
		//検索文字列
		private const string TARGET_STR = "STAY HUNGRY, STAY FOOLISH";

		public static void Main (string[] args)
		{
			Console.WriteLine ("Start Code IQ");
			Console.WriteLine ("C#：グーテンベルグ印刷の活字");

			FileRead fileread = new FileRead();
			fileread.Read();
			//Console.WriteLine (fileread);
			//fileread.PrintCsvData ();

			//検索文字列を順に検索
			for (int i = 0; i < TARGET_STR.Length; i++) 
			{
				string target = TARGET_STR.Substring (i, 1);
				string info = fileread.getCharcter (target);

				Console.Write((i+1).ToString("d2"));
				Console.Write(".\t");
				Console.WriteLine (info);
			}

			Console.WriteLine ("End Code IQ");

		}
	}
}
