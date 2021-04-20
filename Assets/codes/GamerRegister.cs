using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamerRegister : MonoBehaviour
{
    public GameObject UserName;
    public GameObject Password;
    public Text RegisterMessage;

    private string userName;
    private string password;

    public void Register()
    {
        userName = UserName.GetComponent<InputField>().text.ToString();
        password = Password.GetComponent<InputField>().text.ToString();

        MssqlConnection mssqlConnection = new MssqlConnection();
        mssqlConnection.GamerRegister(userName,password);

        bool check= mssqlConnection.GamerLoginCheck(userName,password);

        if (check)
        {
            RegisterMessage.text =  "Register Success";
        }
        else
        {
            RegisterMessage.text = "Register Error";
        }

    }
}
