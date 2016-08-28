using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    public Tank target;
    public float fireRate = 5F;	    //Fire Rate between Shots
    private float nextFire = 0.0F;  //First fire & Next fire Time
    public GameObject ball;

    // Use this for initialization
    void Start () {
        nextFire = Time.time + Random.Range(0, fireRate) + fireRate;
    }
	
	// Update is called once per frame
	void Update () {
        var dir = target.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
 

        if (Time.time > nextFire && target.heading > 1)
        {
            nextFire = Time.time + fireRate;
            var c = Instantiate(ball, transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward)) as GameObject;
            c.tag = "Ball";
        }
    }
}
