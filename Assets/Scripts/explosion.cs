using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

    private float start;

	// Use this for initialization
	void Start () {
        start = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - start > 0.5f)
            Destroy(gameObject);
    }
}
