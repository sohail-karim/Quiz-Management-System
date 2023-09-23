using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ifpaused : MonoBehaviour
{
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationPause(bool ispaused)
    { 
        Debug.Log(" //your app is in the background, yay!!!!" + ispaused);
        pausePanel.SetActive(true);
        QuestionnsManager manager = FindObjectOfType<QuestionnsManager>();
        manager.SubmitAns();

    }

    public void ChangeScene()
    {

        SceneManager.LoadScene(2);
    }
}
