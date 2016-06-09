using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

    public float Speed = 10; //Speed of the velocity

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed; //Give Velocity to the Player ship shot
    }
}
