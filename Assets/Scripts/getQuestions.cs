using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getQuestions : MonoBehaviour
{

    public GameObject opt1, opt2, opt3, opt4;
    public Text Questions;
    public static int numQuestion = 0;
    private bool onQuestion = false;



    public void loadQuestion(object Argument)
    {
        onQuestion = (bool)Argument;

        if (onQuestion == false)
        {
            Questions.text = questions.Questions[numQuestion];
            opt1.GetComponentInChildren<Text>().text = questions.option1[numQuestion];
            opt2.GetComponentInChildren<Text>().text = questions.option2[numQuestion];
            opt3.GetComponentInChildren<Text>().text = questions.option3[numQuestion];
            opt4.GetComponentInChildren<Text>().text = questions.option4[numQuestion];
            numQuestion++;
        }
    }

   public void checkAnswer(int idx)
    {
        if (questions.rightAnwser[numQuestion - 1] == idx)
        {
            Level.instance.StartWinAnimation();
        }
        else 
        {
            Level.instance.StartLoseAnimation();
        }
    }


    // Use this for initialization
    void Start()
    {

        Level.instance.OnTransition += new Level.OnVarChangedHandler(loadQuestion);
        loadQuestion(false);
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    void onButtonCLick()
    {

    }

}

