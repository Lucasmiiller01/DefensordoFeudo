using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using MySql.Data;
using MySql.Data.MySqlClient;

public class DatabaseConnection : MonoBehaviour {

	public string host, database, user, password;
	public bool pooling = true;

	private string connectionString;
	private MySqlConnection connection = null;
	private MySqlCommand cmd = null;
	private MySqlDataReader rdr = null;

	private MD5 _md5Hash;

	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
		this.connectionString = "Server = " + host + "Database = " + database + "User = " + user + "Passwoord = " + password;

		if (pooling) 
		{
			connectionString += "true;";
		}
		else 
		{
			connectionString += "false;";
		}

		try {
			connection = new MySqlConnection(connectionString);
			connection.Open();
			Debug.Log("Mysql State:" + connection.State);
		} 
		catch (Exception e)
		{
			Debug.Log(e);
		}
	}

	void OnApplicationQuit()
	{
		if (connection != null)
		{
			if(connection.State.ToString() != "Closed")
			{
				connection.Close();
				Debug.Log("MySql Connection closed");
			}
			connection.Dispose();
		}
	}

	public string GetConnectionState()
	{
		return connection.State.ToString ();
	}
}
