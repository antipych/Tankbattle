using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public Tank target;
    public GameObject Wreck;
    private Vector3 PitVector;

    public GameObject shell;
    public Transform shotSpawn;
    public float fireRate = 5F;	    //Fire Rate between Shots
    private float nextFire = 0.0F;	//First fire & Next fire Time
    
    // Use this for initialization
    void Start () {
        nextFire = Time.time+ Random.Range(0, fireRate) + fireRate;
    }
	
	// Update is called once per frame
	void Update () {
        var dir = target.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Time.time > nextFire && target.heading > 1 )
        {
            nextFire = Time.time + fireRate;
            var c = Instantiate(shell, shotSpawn.position, shotSpawn.rotation) as GameObject;
            c.tag = "EnemyShell";
        }
    }

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "TankShell" )
        {
            Destroy(other.gameObject);

            PitVector = transform.position;
            PitVector.z = 1;
            var q = Instantiate(Wreck, PitVector, transform.rotation) as GameObject;
            q.transform.parent = gameObject.transform.parent;

            Destroy(gameObject);

            GameObject.Find("Tank").GetComponent<Tank>().Scores += 100;
        }

        if (other.tag == "Ball")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
