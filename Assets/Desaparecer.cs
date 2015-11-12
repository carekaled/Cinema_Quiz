using UnityEngine;
using System.Collections;

public class Desaparecer : MonoBehaviour {

    public GameObject starBut;
	// Use this for initialization
	void Start () {
        StartCoroutine(AnimWin());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator AnimWin()
    {
       
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        starBut.SetActive(true);
    }   

}
