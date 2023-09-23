using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddingDataToDatabase : MonoBehaviour
{
    public InputField department_name_field;
    public InputField Course_name_field;
    public InputField Subject_name_field;
    public InputField teacher_name_textfield;
    public InputField teacher_username_textfield;
    public InputField teacher_password_textfield;
    public InputField Roll_No_textfield;
    public InputField student_name_textfield;
    public InputField father_name_textfield;
    public InputField password_name_textfield;


    public InputField Question;
    public InputField a;
    public InputField b;
    public InputField c;
    public InputField d;
    public InputField ans;
    Get_Data_from_Server get_Data_From_Server;

    private void Start()
    {
    }


    //------------------ Add Deparrments to Datbase Starts Here ---------------
    //--------------------------------------------------------------------------

    public void Logout()
    {
        SceneManager.LoadScene(0);
    }

    public void AddDepartment()
    {
        get_Data_From_Server = FindObjectOfType<Get_Data_from_Server>();
        StartCoroutine(Department());
        SceneManager.LoadScene(1);
        get_Data_From_Server.GetDepartmentsFromServer();

        foreach (string item in UnityDatabase.departs)
        {
            Debug.Log("1) " + item);
        }


    }

    IEnumerator Department()
    {
        
            WWWForm form = new WWWForm();
            form.AddField("Depart_name", department_name_field.text);
            WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/UpdateDepartInDatabase.php", form);
            yield return www;
            if (www.text == "0")
            {
                Debug.Log("Department Saved successfully");
                UnityDatabase.departs.Clear();

            foreach (string item in UnityDatabase.departs)
            {
                Debug.Log(item);
            }

            get_Data_From_Server.GetDepartmentsFromServer();
            }
            else
            {
                Debug.Log("Department Saving failed . Error #" + www.text);
            }
        
    }




    //------------------ Add Deparrments to Datbase Ends Here ---------------
    //--------------------------------------------------------------------------






    //------------------ Add Courses to Datbase Starts Here ---------------
    //--------------------------------------------------------------------------




    public void AddCourse()
    {
        get_Data_From_Server = FindObjectOfType<Get_Data_from_Server>();
        StartCoroutine(Course());
        SceneManager.LoadScene(1);
        get_Data_From_Server.GetCoursesFromServer();
    }

    IEnumerator Course()
    {
        
        WWWForm form = new WWWForm();
        form.AddField("course_name", Course_name_field.text);
        form.AddField("c_depart", UnityDatabase.dropdown);

        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/UpdateCoursetInDatabase.php", form);
        yield return www;
        if (www.text.Contains("0"))
        {
            Debug.Log("Course Saved successfully");
            UnityDatabase.course.Clear();
            get_Data_From_Server.GetCoursesFromServer();

        }
        else
        {
            Debug.Log("Course Savong failed . Error #" + www.text);
        }

    }


    //------------------ Add Courses to Datbase Ends Here ---------------
    //--------------------------------------------------------------------------





    //------------------ Add Subjects to Datbase Starts  Here ---------------
    //--------------------------------------------------------------------------

    
    public void AddSubject()
    {
        get_Data_From_Server = FindObjectOfType<Get_Data_from_Server>();
        StartCoroutine(Subject());
        SceneManager.LoadScene(1);
        get_Data_From_Server.GetCoursesFromServer();
        get_Data_From_Server.GetTeachersFromServer();
    }

    IEnumerator Subject()
    {

        WWWForm form = new WWWForm();
        form.AddField("subject_name", Subject_name_field.text);
        form.AddField("department", UnityDatabase.dropdown);
        form.AddField("c_id", UnityDatabase.dropdown1);
        form.AddField("semester", UnityDatabase.dropdown2);
        form.AddField("t_id", UnityDatabase.dropdown3);

        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/UpdateSubjectInDatabase.php", form);
        yield return www;
        if (www.text.Contains("0"))
        {
            Debug.Log("Subject Saved successfully");
            UnityDatabase.course.Clear();
            get_Data_From_Server.GetSubjectsFromServer();

        }
        else
        {
            Debug.Log("Subject Savong failed . Error #" + www.text);
        }

    }


    //------------------ Add Subjects to Datbase Ends Here ---------------
    //--------------------------------------------------------------------------



    //------------------ Add Questions to Datbase Starts Here ---------------
    //--------------------------------------------------------------------------





    public void AddQuestions()
    {
        get_Data_From_Server = FindObjectOfType<Get_Data_from_Server>();
        StartCoroutine(Questiona());
        SceneManager.LoadScene(1);
        get_Data_From_Server.GetCoursesFromServer();
    }

    IEnumerator Questiona()
    {

        WWWForm form = new WWWForm();
        form.AddField("subject", UnityDatabase.dropdown3);
        form.AddField("department", UnityDatabase.dropdown);
        form.AddField("c_name", UnityDatabase.dropdown1);
        form.AddField("sem", UnityDatabase.dropdown2);
        form.AddField("question", Question.text);
        form.AddField("a", a.text);
        form.AddField("b", b.text);
        form.AddField("c", c.text);
        form.AddField("d", d.text);
        form.AddField("ans", ans.text);



        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/UpdateQuestionInDatabase.php", form);
        yield return www;
        if (www.text.Contains("0"))
        {
            Debug.Log("Question Saved successfully");
        }
        else
        {
            Debug.Log("Subject Savong failed . Error #" + www.text);
        }
    }


    //------------------ Add Questionsn to Datbase Ends Here ---------------
    //--------------------------------------------------------------------------





    //------------------ Add Teacher to Datbase Starts Here ---------------
    //--------------------------------------------------------------------------


    public void AddTeacher()
    {
        StartCoroutine(Teacher());
        SceneManager.LoadScene(1);
    }

    IEnumerator Teacher()
    {

        WWWForm form = new WWWForm();
        form.AddField("teacher_name", teacher_name_textfield.text);
        form.AddField("department", UnityDatabase.dropdown);
        form.AddField("teacher_username", teacher_username_textfield.text);
        form.AddField("teacher_password", teacher_password_textfield.text);

        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/UpdateTeacherInDatabase.php", form);
        yield return www;
        if (www.text.Contains("0"))
        {
            Debug.Log("Teacher Saved successfully");
        }
        else
        {
            Debug.Log("Teacher Savong failed . Error #" + www.text);
        }
    }


    //------------------ Add Teacher to Datbase Ends Here ---------------
    //--------------------------------------------------------------------------




    //------------------ Add Teacher to Datbase Starts Here ---------------
    //--------------------------------------------------------------------------


    public void AddStudent()
    {
        StartCoroutine(Student());
        SceneManager.LoadScene(1);
    }

    IEnumerator Student()
    {

        WWWForm form = new WWWForm();
        form.AddField("roll",Roll_No_textfield.text);
        form.AddField("name", student_name_textfield.text);
        form.AddField("f_name", father_name_textfield.text);
        form.AddField("pass", password_name_textfield.text);
        form.AddField("depart", UnityDatabase.dropdown);
        form.AddField("c_name", UnityDatabase.dropdown1);
        form.AddField("sem", UnityDatabase.dropdown2);

        WWW www = new WWW(UnityDatabase.server + "/Quiz_Management/UpdateStudentInDatabase.php", form);
        yield return www;
        if (www.text.Contains("0"))
        {
            Debug.Log("Teacher Saved successfully");
        }
        else
        {
            Debug.Log("Teacher Savong failed . Error #" + www.text);
        }
    }


    //------------------ Add Teacher to Datbase Ends Here ---------------
    //--------------------------------------------------------------------------

    public void wapsAja()
    {
        SceneManager.LoadScene(2);
    }
}
