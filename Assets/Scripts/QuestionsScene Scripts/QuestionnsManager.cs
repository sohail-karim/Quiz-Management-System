using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionnsManager : MonoBehaviour
{

    public static int j = 0;
    selectedoption option;
    int length;


    public Text[] temp_q;
    public GameObject scorePanel;
    public Text total_Scores;
    private void Start()
    {
        option = FindObjectOfType<selectedoption>();
        length = UnityDatabase.length;
        Debug.Log("Length "+ length);

    }

    public void AbDispayingData()
    {

        for (int i = 0; i < length; i += 6)
        {
            for (int k = 0; k < 5; k++)
            {
                if (k == 0)
                    temp_q[k].text = UnityDatabase.questions[j];
                if (k == 1)
                    temp_q[k].text = UnityDatabase.a[j];
                if (k == 2)
                    temp_q[k].text = UnityDatabase.b[j];
                if (k == 3)
                    temp_q[k].text = UnityDatabase.c[j];
                if (k == 4)
                    temp_q[k].text = UnityDatabase.d[j];

            }
        }

        j++;
    }

    public void SubmitAns()
    {
        Debug.Log(" Value Of J " + j);
        Debug.Log(UnityDatabase.correctAns[j-1]);
        string tempAns = option.submit();
        Debug.Log("Temp Ans :" + tempAns);

        if (UnityDatabase.correctAns[j - 1] == tempAns)
        {
            Debug.Log("Correct Ans :");
            UnityDatabase.score++;
            option.ClearToggles();

        }
        else
        {
            Debug.Log("Wrong Ans ");
            option.ClearToggles();
        }
        if (j == (length / 6))
        {
            scorePanel.SetActive(true);
            total_Scores.text = "Your Marks in this Quiz : " + UnityDatabase.score.ToString();
            SetScoreFunction();         // calling function to update scores in database 

        }
        AbDispayingData();
    }


    
    // this is used for updating the scores wht the quiz ends 
    public void SetScoreFunction()
    {
        StartCoroutine(SetCoreCouroutine());
    }
    IEnumerator SetCoreCouroutine()
    {

        WWWForm form = new WWWForm();
        form.AddField("Roll_No", UnityDatabase.Roll_No);
        form.AddField("Subject_Name", UnityDatabase.subject_Quiz_Given);
        form.AddField("marks", UnityDatabase.score);
        form.AddField("quizid", UnityDatabase.quizcode);
        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/UpdateMarksInDatabase.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Score updated");
        }
        else
        {
            Debug.Log("update failed #" + www.text);
        }

    }
    
    public void SceneChange()
    {
        SceneManager.LoadScene(2);
    }
}
