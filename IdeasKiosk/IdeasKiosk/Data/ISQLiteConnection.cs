using System;
using SQLite.Net.Async;

namespace IdeasKiosk.Data
{
    public interface ISQLiteConnection
	{
		string GetDataBasePath();
		SQLiteAsyncConnection GetConnection();
	}
}
