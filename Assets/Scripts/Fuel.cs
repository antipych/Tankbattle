using UnityEngine;
using System.Collections;

public class Fuel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was not equal to one of these
        if (other.tag != "TankShell" && other.tag != "EnemyShell")
        {
            GameObject.Find("Tank").GetComponent<Tank>().Fuel = 100;
            Destroy(gameObject);

        }
    }
}
