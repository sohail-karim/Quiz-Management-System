using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GettingSubjects : MonoBehaviour
{
    public GameObject Subjcts;
    public GameObject NoQuiz;
    int length = 0;
    string SubjectSelectedForQuiz;
    public GameObject quizCodePanel;
    public InputField quizcodel;




    // Start is called before the first frame update
    void Start()
    {
        NoQuiz.SetActive(false);
        GetSubjectsFromServer();
        StartCoroutine(LoadSubjects());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadSubjects()
    {
        yield return new WaitForSeconds(5f);
        foreach (string item in UnityDatabase.student_subject)
        {
            GameObject g = Instantiate(Subjcts, transform);
            g.name = item;
            g.SetActive(true);
            g.GetComponentInChildren<Text>().text = item;
            g.GetComponentInChildren<Button>().onClick.AddListener(delegate { QuizCode(item); });
        }
    }

    //Getting Questions For Students 

    public void QuizCode(string subject)
    {
        Debug.Log("subject Selected :" + subject);
        SubjectSelectedForQuiz = subject;
        quizCodePanel.SetActive(true);
    }

    

    public void GetQuestionsSubjectsFromServer()
    {
        string code = quizcodel.textComponent.text;
        UnityDatabase.quizcode = code;
        Debug.Log(" Quiz Code is : " + code);
        UnityDatabase.subject_Quiz_Given = SubjectSelectedForQuiz;
    
        UnityDatabase.questions.Clear();
        UnityDatabase.a.Clear();
        UnityDatabase.b.Clear();
        UnityDatabase.c.Clear();
        UnityDatabase.d.Clear();
        UnityDatabase.correctAns.Clear();


        StartCoroutine(StudentsSubjects(code, SubjectSelectedForQuiz));
        
    }
    IEnumerator StudentsSubjects(string item,string subject)
    {
        WWWForm form = new WWWForm();
        form.AddField("QuizCode", item);
        form.AddField("subjectName", subject);
        form.AddField("rollNo", UnityDatabase.Roll_No);
        List<string> temp = new List<string>();
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/GetQuestionsCopy.php", form);
        yield return www;
        Debug.Log(www.text);
        string theText = www.text.ToString();
        string[] splitString = theText.Split(new string[] { "....", "....", "....", "....", "....", "...." }, 0);
        foreach (string i in splitString)
        {
            temp.Add(i);
        }
        temp.RemoveAt(temp.Count - 1);
        length = temp.Count;
        UnityDatabase.length = length;
        for (int i = 0; i < temp.Count; i++)
        {
            if (i == 0)
            {
                UnityDatabase.questions.Add(temp[i]);
                //  Debug.Log(" = = "+ data[i]);
            }
            else if (i == 1)
            {
                UnityDatabase.a.Add(temp[i]);
                //   Debug.Log(" = = " + data[i]);
            }
            else if (i == 2)
            {
                UnityDatabase.b.Add(temp[i]);
                //  Debug.Log(" = = " + data[i]);
            }
            else if (i == 3)
            {
                UnityDatabase.c.Add(temp[i]);
                //  Debug.Log(" = = " + data[i]);
            }
            else if (i == 4)
            {
                UnityDatabase.d.Add(temp[i]);
                // Debug.Log(" = = " + data[i]);
            }
            else
            {
                UnityDatabase.correctAns.Add(temp[i]);
                //   Debug.Log(" = = " + data[i]);
                temp.RemoveRange(0, 6);
                i = -1;
            }
        }
        Debug.Log(" Total Questions " + (UnityDatabase.questions.Count));
        Debug.Log("Total a " + (UnityDatabase.a.Count));
        Debug.Log("Total b " + (UnityDatabase.b.Count));
        Debug.Log("Total c " + (UnityDatabase.c.Count));
        Debug.Log("Total d " + (UnityDatabase.d.Count));
        Debug.Log("Total correct Ans " + (UnityDatabase.correctAns.Count));
        if(length != 0)
        SceneManager.LoadScene(3);
        else
        {
            NoQuiz.SetActive(true);
            Debug.Log("No Quiz Around ");
        }
    }




    //Getting Subjects List For UserName

    public void GetSubjectsFromServer()
    {

        UnityDatabase.student_subject.Clear();
        StartCoroutine(Subjects());
    }
    IEnumerator Subjects()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", UnityDatabase.Roll_No);
        form.AddField("sem", UnityDatabase.sem);
        List<string> temp = new List<string>();
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/GetSubjectsForStudent.php", form);

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
                UnityDatabase.student_subject.Add(temp[i]);
                temp.RemoveRange(0, 1);
                i = -1;
            }
        }

    }



}

