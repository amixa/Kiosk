using System;
using System.IO;
using IdeasKiosk.Data;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(IdeasKiosk.iOS.SQLiteConnectionTouch))]

namespace IdeasKiosk.iOS
{
	public class SQLiteConnectionTouch : ISQLiteConnection
	{
		private SQLiteAsyncConnection _connection;

		public string GetDataBasePath()
		{
			string filename = "Idealink.db3";
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}

			return Path.Combine(libFolder, filename);
		}

		public SQLiteAsyncConnection GetConnection()
		{
			if (_connection != null)
			{
				return _connection;
			}

			SQLiteConnectionWithLock connectioonWithLock =
			new SQLiteConnectionWithLock(
			new SQLitePlatformIOS(),
			new SQLiteConnectionString(GetDataBasePath(), true));
			return _connection = new SQLiteAsyncConnection(() => connectioonWithLock);
		}
	}
}