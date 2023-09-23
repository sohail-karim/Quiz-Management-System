using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityDatabase {
	
    // -------------------department data -------------------------
    public static List<string> departs = new List<string>();

    // -------------------department data -------------------------
    public static string server = "allcoursesfree.net";


    // -------------------Courses data -------------------------
    public static List<string> course = new List<string>();



    // -------------------Subjects data -------------------------
    public static List<string> subject = new List<string>();

    // -------------------Teachers data -------------------------
    public static List<string> teachers = new List<string>();

    // ------------------- Student Login Name -------------------------
    public static string s_name_loged_in;           // these are also requered to store scores in database;
    public static string Roll_No;
    public static string sem;
    public static string subject_Quiz_Given;

    

    // ------------------- Teacher Login Name -------------------------
    public static string t_name_loged_in;

    // ------------------- Teacher Subjects  Name -------------------------
    public static List<string> teacher_subjects = new List<string>();
    public static string quiz_code;

    // ------------------- Student Specific Subjects -------------------------
    public static List<string> student_subject =  new List<string>();



    // ------------------Questions  Specific Subjects -------------------------
    public static List<string> questions = new List<string>();
    public static List<string> a = new List<string>();
    public static List<string> b = new List<string>();
    public static List<string> c = new List<string>();
    public static List<string> d = new List<string>();
    public static List<string> correctAns = new List<string>();
    public static int score = 0;

    public static string quizcode;

    // ------------------Questions  Specific Subjects -------------------------



    //temp
    public static string dropdown;
    public static string dropdown1;
    public static string dropdown2;
    public static string dropdown3;

    public static int length;


}
