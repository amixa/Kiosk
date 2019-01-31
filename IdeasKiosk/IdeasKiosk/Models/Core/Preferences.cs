using System;
using SQLite;
using SQLite.Net.Attributes;

namespace IdeasKiosk.Models.Core
{
    public class Preferences
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Url { get; set; }
    }
}
