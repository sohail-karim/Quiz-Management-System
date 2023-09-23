using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Data_from_Server : MonoBehaviour
{
    public GameObject loading;

    // Start is called before the first frame update
    void Start()
    {
        loading.SetActive(true);
        GetDepartmentsFromServer();
        GetCoursesFromServer();
        GetSubjectsFromServer();
        GetTeachersFromServer();
        StartCoroutine(loading_wait());
        
    }

	



    //-----------------Adding To Departments opens here  ----------------------------------------------------
    public void GetDepartmentsFromServer()
    {
        UnityDatabase.departs.Clear();
        StartCoroutine(ToArray());
    }
    IEnumerator ToArray()
    {
        List<string> temp = new List<string>(); 
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/GetData.php");
        yield return www;
        string theText = www.text.ToString();
        string[] splitString = theText.Split(new string[] { "...." }, 0);
        foreach (string i in splitString)
        {
            temp.Add(i);
        }
        temp.RemoveAt(temp.Count - 1);
        int length = temp.Count;
        for (int i = 0; i < temp.Count; i++)
        {
            if (i == 0)
            {
                UnityDatabase.departs.Add(temp[i]);
                temp.RemoveRange(0, 1);
                i = -1;

            }
        }
    }

    //-----------------Adding To Departments  close here -----------------------------------------------------


    IEnumerator loading_wait()
    {
        yield return new WaitForSeconds(5f);
        loading.SetActive(false);
    }








    //-----------------Adding To Courses opens here  ----------------------------------------------------
    public void GetCoursesFromServer()
    {
        UnityDatabase.course.Clear();
        StartCoroutine(Courses());
    }
    IEnumerator Courses()
    {

        List<string> temp = new List<string>();
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/GetCourse.php");
        yield return www;
        string theText = www.text.ToString();
        string[] splitString = theText.Split(new string[] { "...." }, 0);;
        foreach (string i in splitString)
        {
            temp.Add(i);
        }
        temp.RemoveAt(temp.Count - 1);
        int length = temp.Count;
        for (int i = 0; i < temp.Count; i++)
        {
            if (i == 0)
            {
                UnityDatabase.course.Add(temp[i]);
                temp.RemoveRange(0, 1);
                i = -1;
            }
        }

    }

    //-----------------Adding To Courses  close here -----------------------------------------------------




//-----------------Adding To Subjects  Starts here -----------------------------------------------------

    public void GetSubjectsFromServer()
    {
        UnityDatabase.subject.Clear();
        StartCoroutine(Subjects());
    }
    IEnumerator Subjects()
    {
        List<string> temp = new List<string>();
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/GetSubject.php");
        yield return www;
        string theText = www.text.ToString();
        string[] splitString = theText.Split(new string[] { "...." }, 0);
        foreach (string i in splitString)
        {
            temp.Add(i);
        }
        temp.RemoveAt(temp.Count - 1);
        int length = temp.Count;
        for (int i = 0; i < temp.Count; i++)
        {
            if (i == 0)
            {
                UnityDatabase.subject.Add(temp[i]);
                temp.RemoveRange(0, 1);
                i = -1;
            }
        }

   //     loading.SetActive(false);
    }

    //-----------------Adding To Subjects  Closes here -----------------------------------------------------

    public void GetTeachersFromServer()
    {
        UnityDatabase.teachers.Clear();
        StartCoroutine(Teachers());
    }
    IEnumerator Teachers()
    {

        List<string> temp = new List<string>();
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/GetTeachers.php");
        yield return www;
        string theText = www.text.ToString();
        string[] splitString = theText.Split(new string[] { "...." }, 0); ;
        foreach (string i in splitString)
        {
            temp.Add(i);
        }
        temp.RemoveAt(temp.Count - 1);
        int length = temp.Count;
        for (int i = 0; i < temp.Count; i++)
        {
            if (i == 0)
            {
                UnityDatabase.teachers.Add(temp[i]);
                temp.RemoveRange(0, 1);
                i = -1;
            }
        }

    }

    


}
