using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public static Level instance = null;
    
    public delegate void OnVarChangedHandler(object Argument);

    public event OnVarChangedHandler OnQuestionAwserd;
    public event OnVarChangedHandler OnTransition;
    public event OnVarChangedHandler OnAnswerResult;


    private bool _bOnQuestion = false;
    public bool bOnQuestion
    {
        get { return _bOnQuestion; }
        set
        {
            _bOnQuestion = value;
            if (OnQuestionAwserd != null)
                OnQuestionAwserd(_bOnQuestion);
        }
    }

    private bool _bOnTransition = false;
    public bool bOnTransition
    {
        get { return _bOnTransition; }
        set
        {
            _bOnTransition = value;
            OnTransition(_bOnTransition);
        }
    }

    private bool _bOnAnwser = false;
    public bool bOnAnwser
    {
        get { return _bOnAnwser; }
        set
        {
            _bOnAnwser = value;
            OnAnswerResult(_bOnAnwser);
        }
    }

    private bool bGameOver = false;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void onButtonCLick() {
       // bOnTransition = false;
        //print("PRESSED");
    }

    internal void StartLoseAnimation()
    {
        bOnAnwser = false;
    }

    internal void StartWinAnimation()
    {
        bOnAnwser = true;
    }
}
