using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class QuizScript : MonoBehaviour
{
    private class Question
    {
        
        public string maintext;
        public string[] questions;
        public int correctanswer;
        public string precision;
        
        public Question(string maintext, string[] questions, int correctanswer, string precision)
        {
            this.maintext = maintext;
            this.questions = questions;
            this.correctanswer = correctanswer;
            this.precision = precision;
        }
    }

    private Button[] buttons;
    private TMP_Text maintext;
    private Question currentQuestion;
    private int currenQuestionnb = 0;
    private bool wasCorrect = false;
    private List<Question> questions;





    

    


void changeTexts(int question)
    {
        for (int i = 0; i < 4; i++)
        {
            Button btn = buttons[i];
            
            btn.GetComponentInChildren<TMP_Text>().text = questions[question].questions[i];
        }
        maintext.text = questions[question].maintext;
        currentQuestion = questions[question];
        currenQuestionnb++;


    }
    void addMockQuestions()
    {
  Question question1 = new Question("What is the first letter in the alphabet?", new string[] { "A", "N", "C", "D" }, 1, "Le p�nis est constitu� de corps caverneux. Lors d�une �rection, ces corps se remplissent de sang et font gonfler le p�nis. Une �rection peut-�tre provoqu�e lorsque l�individu est excit�.");
     Question question2 = new Question("Where should you put your penus?", new string[] { "Apple Pie", "Vaccum Cleaner", "Sex Worker", "Condom" }, 4, "Le p�nis est constitu� de corps caverneux. Lors d�une �rection, ces corps se remplissent de sang et font gonfler le p�nis. Une �rection peut-�tre provoqu�e lorsque l�individu est excit�.");
        Question question3 = new Question("1+2?", new string[] { "8", "4", "3", "4" }, 3,"Le p�nis est constitu� de corps caverneux. Lors d�une �rection, ces corps se remplissent de sang et font gonfler le p�nis. Une �rection peut-�tre provoqu�e lorsque l�individu est excit�.");
        Question question4 = new Question("2+3?", new string[] { "4", "5", "4", "9" }, 2, "Le p�nis est constitu� de corps caverneux. Lors d�une �rection, ces corps se remplissent de sang et font gonfler le p�nis. Une �rection peut-�tre provoqu�e lorsque l�individu est excit�.");
        questions = new List<Question>();
        questions.Add(question1);
        questions.Add(question2); questions.Add(question3); questions.Add(question4);
    }
    void HideallButtons()
    {
        for (int i = 1; i < 4; i++)
        {
            Button btn = buttons[i];
            btn.gameObject.SetActive(false);
        }
        buttons[0].GetComponentInChildren<TMP_Text>().text = "Continue";
    }
    void ShowallButtons()
    {
        for (int i = 1; i < 4; i++)
        {
            Button btn = buttons[i];
            btn.gameObject.SetActive(true);
        }
    }
    void TaskOnClick(string name)
    {
        Debug.Log("currenQuestionnb" + currenQuestionnb);
        
        int buttonnb = int.Parse(name.Remove(0, 6));
        if (buttonnb == 1 && buttons[0].GetComponentInChildren<TMP_Text>().text == "Continue")
        {
            if (wasCorrect)
            {   

                SceneManager.LoadScene(0);
            }
            ShowallButtons();
            maintext.fontSize = 20;
            changeTexts(currenQuestionnb);
            return;

        }
        Debug.Log("You have clicked the button " + name.Remove(0, 6));
        if (buttonnb == questions[currenQuestionnb-1].correctanswer)
        {
            Debug.Log("You Answered Correctly");
            Debug.Log(questions[currenQuestionnb-1].correctanswer);
            wasCorrect = true;
            maintext.text = "That was correct, let's continue the journey. \nPrecision:";
        }
        else
        {
            Debug.Log("You answered Wrongly");
            Debug.Log(questions[currenQuestionnb-1].correctanswer);
            maintext.text = "Oops that was wrong, Let's try again. \nPrecision:";
            


        }
        maintext.text += questions[currenQuestionnb - 1].precision;
        maintext.fontSize = 7;
        HideallButtons();






    }


    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        maintext = GetComponentInChildren<TMP_Text>();
    addMockQuestions();
        changeTexts(currenQuestionnb);

        for (int i = 0; i < 4; i++)
        {
            Button btn = buttons[i];
            btn.onClick.AddListener(() => TaskOnClick(btn.gameObject.name));
            
        }
        //btnValue();
    }

    
}
