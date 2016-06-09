using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "Shell")
        {
            Destroy(other.gameObject); 
        }
    }
}
