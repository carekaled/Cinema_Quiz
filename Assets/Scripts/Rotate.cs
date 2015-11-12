using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public int Speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float angle = 0;

        angle += Time.deltaTime;

        gameObject.transform.Rotate(new Vector3(0f, 0f, 1f), angle * Speed);

	}
}
