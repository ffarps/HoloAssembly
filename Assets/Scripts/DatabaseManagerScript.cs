using UnityEngine;
using System;
using System.IO;
using SQLite4Unity3d;

public class DatabaseManagerScript : MonoBehaviour
{
    private SQLiteConnection _connection;

    private void Start()
    {
        // Specify the database file path
        string databasePath = Path.Combine(Application.persistentDataPath, "myHolodatabase.db");
        //Debug.Log(Application.persistentDataPath);

        // Initialize the database connection
        _connection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        // Create a table (if it doesn't exist)
        _connection.CreateTable<HoloDataBase>();
    }
}
