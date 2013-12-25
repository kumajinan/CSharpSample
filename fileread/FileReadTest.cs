using System;
using NUnit.Framework;

namespace fileread
{
	public class FileReadTest
	{
		[TestFixtureSetUp] public void Init()
		{ /* ... */ }
		[TestFixtureTearDown] public void TearDown()
		{ /* ... */ }

		[Test]
		public void newのテスト()
		{
			FileRead fileread = new FileRead();
			Assert.That(fileread, Is.Not.Null);
		}

		[Test]
		public void Readのテスト()
		{
			FileRead fileread = new FileRead();
			fileread.Read();

			Assert.That (fileread.ToString ().Length, Is.GreaterThan (0));
		}

		[Test]
		public void getCharcterのテスト()
		{
			FileRead fileread = new FileRead();
			fileread.Read();

			string target = "Z";
			string ret = fileread.getCharcter (target);
			Assert.That(ret, Is.EqualTo(" 1, 1 = Z"));

			target = "A";
			ret = fileread.getCharcter (target);
			Assert.That(ret, Is.EqualTo(" 3, 1 = A"));

			target = "Y";
			ret = fileread.getCharcter (target);
			Assert.That(ret, Is.EqualTo("15, 1 = Y"));

			target = "H";
			ret = fileread.getCharcter (target);
			Assert.That(ret, Is.EqualTo("15, 2 = H"));
		}
	}
}

