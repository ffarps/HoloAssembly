using UnityEngine;
using System;
using System.IO;
using SQLite4Unity3d;

public class DatabaseManagerScript : MonoBehaviour
{
    /// <summary>
    /// This sript defines the local for the database to be stored, creates a new SQLite connection, and creates the required tables
    /// </summary>
    public SQLiteConnection _connection;

    private void Start()
    {
        string databasePath = Path.Combine(Application.persistentDataPath, "myHolodatabase.db");
        //Debug.Log(Application.persistentDataPath);

        _connection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        _connection.CreateTable<HoloDataBase>();
    }
}
