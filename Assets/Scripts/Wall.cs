﻿using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

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
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Vector3 PitVector = transform.position;
            var newCrater = Instantiate(Crater, PitVector, transform.rotation) as GameObject;
        }
    }
}
