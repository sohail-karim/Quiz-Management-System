using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayOverAllResulsts : MonoBehaviour
{
    public GameObject Name;
    public GameObject Marks;
    public GameObject Subjects;
    public GameObject DateAndTime;
    public GameObject loading;
    public GameObject sr;
    int j = 1;
    int length = 0;
    List<string> temp = new List<string>();


    private void OnEnable()
    {
        loading.SetActive(true);
        StartCoroutine(loading_wait());
        GetResultsFromServer();
        StartCoroutine(LoadSubjects());
    }

    // Start is called before the first frame update
    void Start()
    {
      //  GetResultsFromServer();
     //   StartCoroutine(LoadSubjects());

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDisable()
    {
        Debug.Log("Results : "+ temp.Count);
        temp.Clear();
        Debug.Log("Results after  : " + temp.Count);
    }

    IEnumerator LoadSubjects()
    {
        yield return new WaitForSeconds(3f);
         for(int i=0;i< temp.Count; i++)
          {
                if (i == 0)
                {
                    GameObject h = Instantiate(sr, transform);
                    h.name = j.ToString();
                    h.GetComponent<Text>().text = j.ToString() + " )";
                    GameObject g = Instantiate(Name, transform);
                    g.name = temp[i].ToString();
                    g.GetComponent<Text>().text = temp[i].ToString();
                //      g.GetComponentInChildren<Text>().text = item;
            }
                if (i == 1)
                {
                    GameObject g = Instantiate(Marks, transform);
                    g.name = temp[i].ToString();
                g.GetComponent<Text>().text = temp[i].ToString();
                //        g.GetComponentInChildren<Text>().text = item;
            }
                if (i == 2)
                {
                    GameObject g = Instantiate(Subjects, transform);
                    g.name = temp[i].ToString();
                g.GetComponent<Text>().text = temp[i].ToString();
                //       g.GetComponentInChildren<Text>().text = item;
            }
                if (i == 3)
                {
                    GameObject g = Instantiate(DateAndTime, transform);
                    g.name = temp[i].ToString();
                g.GetComponent<Text>().text = temp[i].ToString();
                temp.RemoveRange(0, 4);
                Debug.Log(temp.Count + " is now length ");
                i = -1;
                j++;
                //      g.GetComponentInChildren<Text>().text = item;
            }
           
            }
        }
    

    
    //Getting Subjects List For UserName

    public void GetResultsFromServer()
    {

        UnityDatabase.student_subject.Clear();
        StartCoroutine(Results());
    }
    IEnumerator Results()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", UnityDatabase.Roll_No);
      
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/GetResultsForStudents.php", form);
        yield return www;
        string theText = www.text.ToString();
        string[] splitString = theText.Split(new string[] { "....", "....", "....", "...." }, 0);
        Debug.Log(" String Retrived From Server "+ theText);
        foreach (string i in splitString)
        {
            Debug.Log(" + " + i);
            temp.Add(i);
        }
        temp.RemoveAt(temp.Count - 1);
        length = temp.Count;
        Debug.Log("length : " + length);
    }

    IEnumerator loading_wait()
    {
        yield return new WaitForSeconds(5f);
        loading.SetActive(false);
    }

}
