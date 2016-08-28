using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float Speed = 1; //Speed of the velocity
    public float Power = 1;

    public GameObject explosion;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed; //Give Velocity to the Player ship shot
    }
    void OnDestroy()
    {
        Instantiate(explosion, gameObject.transform.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "TankShell" || other.tag == "EnemyShell" || other.tag == "Ball")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Vector3 PitVector = transform.position;
            //var newCrater = Instantiate(Crater, PitVector, transform.rotation) as GameObject;
        }
    }

 }
