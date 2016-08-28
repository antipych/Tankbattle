using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

    public GameObject Crater;

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
        if (other.tag == "TankShell" || other.tag == "EnemyShell" || other.tag == "Ball")
        {
            var q = Instantiate(Crater, transform.position, transform.rotation) as GameObject;
            q.transform.parent = gameObject.transform.parent;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
