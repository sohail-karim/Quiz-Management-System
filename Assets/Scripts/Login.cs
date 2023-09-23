﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField namefield;
    public InputField passwordField;

    public Button submitButton;


    public void LoginFunction()
    {
        StartCoroutine(LoginGoesHere());
    }
    IEnumerator LoginGoesHere()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", namefield.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            UnityDatabase.s_name_loged_in = namefield.text;
            SceneManager.LoadScene(1);
        }
        else
        {

            Debug.Log("Login failed . Error #" + www.text);
        }
    }

}
