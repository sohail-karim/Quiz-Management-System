using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class viewDetailDeparts: MonoBehaviour
{
    public GameObject id;
    public GameObject Depart;
    public GameObject loading;
    int length = 0;
    int j = 1;
    List<string> temp = new List<string>();

    private void OnEnable()
    {
        loading.SetActive(true);
        StartCoroutine(loading_wait());
        GetStudentsDetailsFromServer();
        StartCoroutine(LoadSubjects());

    }

    IEnumerator loading_wait()
    {
        yield return new WaitForSeconds(5f);
        loading.SetActive(false);
    }
    private void OnDisable()
    {
        SceneManager.LoadScene(1);
    }
    // Start is called before the first frame update
    void Start()
    {
        //    GetStudentsDetailsFromServer();
        //  StartCoroutine(LoadSubjects());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadSubjects()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < temp.Count; i++)
        {
            
              
            if (i == 0)
            {
                GameObject h = Instantiate(id, transform);
                h.name = j.ToString();
                h.GetComponent<Text>().text = j.ToString() + " )";
                GameObject g = Instantiate(Depart, transform);
                g.name = temp[i].ToString();
                g.GetComponent<Text>().text = temp[i].ToString();
                temp.RemoveRange(0, 1);
                Debug.Log(temp.Count + " is now length ");
                i = -1;
                j++;
                //        g.GetComponentInChildren<Text>().text = item;
            }
        }
    }



    //Getting Subjects List For UserName

    public void GetStudentsDetailsFromServer()
    {

        UnityDatabase.student_subject.Clear();
        StartCoroutine(StudentDetails());
    }
    IEnumerator StudentDetails()
    {
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/GetDetailsForDeparts.php");
        yield return www;
        string theText = www.text.ToString();
        string[] splitString = theText.Split(new string[] { "...."}, 0);
        Debug.Log(" String Retrived From Server " + theText);
        foreach (string i in splitString)
        {
            Debug.Log(" + " + i);
            temp.Add(i);
        }
        temp.RemoveAt(temp.Count - 1);
        length = temp.Count;
        Debug.Log("length : " + length);
    }
}
