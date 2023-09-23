﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginTeacher : MonoBehaviour
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
        form.AddField("username", namefield.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/LoginTeacher.php", form);
        yield return www;
        Debug.Log(www.text.ToString());
        string theText = www.text.ToString();
        string[] splitString = theText.Split(new string[] { "...."}, 0); ;
       
        if (www.text[0] == '0')
        {
            //Debug.Log(splitString[1]);
           UnityDatabase.t_name_loged_in = splitString[1];
            Debug.Log(UnityDatabase.t_name_loged_in);
            Debug.Log("Started : ");
        //    GetSubjectsFromServer();
            Debug.Log("Closed : ");
            SceneManager.LoadScene(4);
        }
        else
        {
            Debug.Log("Login failed . Error #" + www.text);
        }
    }





}
