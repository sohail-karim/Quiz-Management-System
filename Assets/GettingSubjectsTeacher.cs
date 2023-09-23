using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GettingSubjectsTeacher : MonoBehaviour
{
    public GameObject Subjcts;
    public InputField code;
    public GameObject code_panel;
    public GameObject Questions_Panel;
    private string subject_selected_for_quiz;
    public InputField startDate, startTime;
    public InputField EndDate, EndTime;
    string startDateandTime, endDateandTime;
	public GameObject loading;
	public Text txt;



    public InputField question, option_a, option_b, option_c, option_d, correct_ans;

    //Getting Questions for Screen for saving it in database
   
   

   
    // Start is called before the first frame update
    void Start()
    {
		loading.SetActive(true);
		StartCoroutine(loading_wait());
        GetSubjectsFromServer();
        
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadSubjects()
    {
        yield return new WaitForSeconds(0f);
        foreach (string item in UnityDatabase.teacher_subjects)
        {
            GameObject g = Instantiate(Subjcts, transform);
            g.name = item;
            g.GetComponentInChildren<Text>().text = item;
            g.GetComponentInChildren<Button>().onClick.AddListener(delegate { SettingCodeforQuiz(item); });
        }
    }
	
	IEnumerator loading_wait()
    {
        yield return new WaitForSeconds(5f);
        loading.SetActive(false);
    }

    //Getting Questions For Students 

    public void SettingCodeforQuiz(string item)
    {
        Debug.Log("You Clicked : " + item);
		txt.text = "Enter 8 Digit Quiz Code for " + item + " ".ToString();
        subject_selected_for_quiz = item.ToString();
        code_panel.SetActive(true);
        clearQuestions();

    }
    private void clearQuestions()
    {
        UnityDatabase.questions.Clear();
        UnityDatabase.a.Clear();
        UnityDatabase.b.Clear();
        UnityDatabase.c.Clear();
        UnityDatabase.d.Clear();
        UnityDatabase.correctAns.Clear();
    }
    public void SetCodeAndAddQuestions()
    {
        UnityDatabase.quiz_code = code.text.ToString();
        startDateandTime = startDate.text + " " + startTime.text + ":00";
        endDateandTime = EndDate.text + " " + EndTime.text + ":00";
        Debug.Log("Start Date and Time : " + startDateandTime);
        Debug.Log("End Date and Time : " + endDateandTime);
        Debug.Log("Code " + UnityDatabase.quiz_code + " for " + subject_selected_for_quiz + " Has Added to Database ");
        SettingQuizPassword();
        code_panel.SetActive(false);
        Questions_Panel.SetActive(true);
    }
    public void SettingQuizPassword()
    {
        StartCoroutine(quizPassword());
    }
    //Getting Subjects List For UserName
    IEnumerator quizPassword()
    {
        WWWForm form = new WWWForm();
    
        form.AddField("quizcode", UnityDatabase.quiz_code.ToString());
        form.AddField("subject", subject_selected_for_quiz);
        form.AddField("teacher_name",UnityDatabase.t_name_loged_in);
        form.AddField("startDateandTime", startDateandTime);
        form.AddField("endDateandTime", endDateandTime);
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/settngquizpassword.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Quiz Password Set successfully");
        }
        else
        {
            Debug.Log("Quiz Password Set failed . Error #" + www.text);
        }
    }

    public void AddQuestiontoUnityDatabase()
    {
        StartCoroutine(addQuestions());
    }
    //Getting Subjects List For UserName
    IEnumerator addQuestions()
    {
        WWWForm form = new WWWForm();
        form.AddField("question", question.text);
        form.AddField("a", option_a.text);
        form.AddField("b", option_b.text);
        form.AddField("c", option_c.text);
        form.AddField("d", option_d.text);
        form.AddField("ans", correct_ans.text);
        form.AddField("quizcode", UnityDatabase.quiz_code.ToString());
        form.AddField("subject", subject_selected_for_quiz);
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/AddquestionstoDatabaseFromTeachers.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Questions Saved successfully");
            question.text = "";
            option_a.text = "";
            option_b.text = "";
            option_c.text = "";
            option_d.text = "";
            correct_ans.text = "";
        }
        else
        {
            Debug.Log("Question Saving failed . Error #" + www.text);
        }
    }
        public void GetSubjectsFromServer()
    {

        UnityDatabase.teacher_subjects.Clear();
        StartCoroutine(Subjects());
    }
    IEnumerator Subjects()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", UnityDatabase.t_name_loged_in);
        List<string> temp = new List<string>();
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/GetSubjectsForTeacher.php", form);

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
                UnityDatabase.teacher_subjects.Add(temp[i]);
                Debug.Log(temp[i]);
                temp.RemoveRange(0, 1);
                i = -1;
            }
        }
		StartCoroutine(LoadSubjects());
    }

    public void Logout()
    {
        SceneManager.LoadScene(0);
    }
   
}

