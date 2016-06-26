using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

    public float Speed = 5; //Speed of the velocity
    public float Power = 1;
    public GameObject Crater;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed; //Give Velocity to the Player ship shot
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Block" || other.tag == "Block2")
        {
            Vector3 PitVector = transform.position;
            // PitVector.z = 1;
            var newCrater = Instantiate(Crater, PitVector, transform.rotation) as GameObject;
        }
    }
}
