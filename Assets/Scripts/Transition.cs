using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Transition : MonoBehaviour {

    public GameObject[] objs;
    public GameObject hal9000;
    public GameObject perguntas; 

	// Use this for initialization
	void Start () {
        Level.instance.OnAnswerResult += new Level.OnVarChangedHandler(OnAnswerResult);
	}

    private void OnAnswerResult(object Argument)
    {
        if ((bool)Argument)
        {
            startWinAnim();
        }
        else {
            strteLoseAnim();
        }
    }

    private void strteLoseAnim()
    {
        Level.instance.bOnTransition = true;
        StartCoroutine(AnimLose());
       
        
    }

    private void startWinAnim()
    {
        Level.instance.bOnTransition = true;
        StartCoroutine(AnimWin());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

     IEnumerator AnimLose (){

         hal9000.SetActive(true);
         //perguntas.SetActive(false);
         Vector3 x = hal9000.transform.position;
         while(hal9000.transform.position.y < -4){
             hal9000.transform.position += new Vector3(0, 1f, 0);
            yield return new WaitForSeconds(0.1f);
         }
         yield return new WaitForSeconds(1f);
         Level.instance.bOnTransition = false;
         hal9000.SetActive(false);
         hal9000.transform.position = x;
         //perguntas.SetActive(true);
     }

     IEnumerator AnimWin()
     {
         int x = getQuestions.numQuestion;

         GameObject c = objs[x - 1];
         int rpt = 2, idx = 0;

         c.GetComponent<AudioSource>().Play();

         while (idx < rpt)
         {
                c.transform.position += new Vector3(0, 1f, 0);
                yield return new WaitForSeconds(0.1f);
                idx++;
         }
         c.transform.Find("Head").gameObject.SetActive(false);
         c.transform.Find("Body").gameObject.SetActive(true);
         
         yield return new WaitForSeconds(2f);
         c.GetComponent<AudioSource>().Stop();
         Level.instance.bOnTransition = false;
         c.transform.Find("Body").gameObject.SetActive(false);

     }
}
