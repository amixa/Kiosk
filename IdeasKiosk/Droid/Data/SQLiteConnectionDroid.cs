using System.IO;
using IdeasKiosk.Data;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(IdeasKiosk.Droid.SQLiteConnectionDroid))]

namespace IdeasKiosk.Droid
{
	public class SQLiteConnectionDroid : ISQLiteConnection
	{
		private SQLiteAsyncConnection _connection;

		public string GetDataBasePath()
		{
			string filename = "Idealink.db3";
			string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}

		public SQLiteAsyncConnection GetConnection()
		{
			if (_connection != null)
			{
				return _connection;
			}

			SQLiteConnectionWithLock connectioonWithLock =
			new SQLiteConnectionWithLock(new SQLitePlatformAndroid(), new SQLiteConnectionString(GetDataBasePath(), true));
			return _connection = new SQLiteAsyncConnection(() => connectioonWithLock);
		}
	}
}