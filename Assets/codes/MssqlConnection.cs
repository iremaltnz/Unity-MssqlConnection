using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.SqlClient;

public class MssqlConnection : MonoBehaviour
{
    public string connect =@"Data Source=ServerName; Initial Catalog=DataBaseName; User ID=UserId;Password=Password;Trusted_Connection=False;";
    void Start()
    {
        SqlConnectionCheck();
    } 

    void SqlConnectionCheck()
    {
        SqlConnection sqlConnection = new SqlConnection(connect);
        try
        {
            sqlConnection.Open();
            Debug.Log("Success Connection");
         
        }
        catch (System.Exception e)
        {
            Debug.Log("Error Connection");
            throw e;
        }
    }

    public void GamerRegister(string UserName, string Password)
    {
        SqlConnection sqlConnection = new SqlConnection(connect);
        sqlConnection.Open();

        SqlCommand sqlCommand = new SqlCommand("INSERT Gamers(UserName,Password) VALUES('" + UserName + "','" + Password + "')", sqlConnection);
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();

    }

    public bool GamerLoginCheck(string UserName, string Password)
    {
        SqlConnection sqlConnection = new SqlConnection(connect); ;
        sqlConnection.Open();

        SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Gamers WHERE UserName='" + UserName + "' and Password='" + Password + "'", sqlConnection);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        int sayac = 0;

        while (sqlDataReader.Read())
        {
            sayac++;
  
        }

        sqlConnection.Close();

        if (sayac == 0)
        {
 
            return false;
        }

        else
        {
            return true;
        }

    }

}
