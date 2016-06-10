using UnityEngine;
using System.Collections;

public class BushSmall : MonoBehaviour {
        
    public GameObject Wreck;
    
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
        if (other.tag != "TankShell" && other.tag != "EnemyShell")
        {
            var q = Instantiate(Wreck, transform.position, transform.rotation) as GameObject;
            q.transform.parent = gameObject.transform.parent;
            Destroy(gameObject);
        }
    }
}
