﻿using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

    public float Speed = 5; //Speed of the velocity
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




}
