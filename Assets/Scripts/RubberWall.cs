using UnityEngine;
using System.Collections;

public class RubberWall : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "TankShell" || other.tag == "EnemyShell" || other.tag == "Ball")
        {
            if (other.tag != "TankShell")
            {
                Destroy(other.gameObject);
            }
            print(other.tag);


            //other.transform.Rotate(Vector3.forward, 90f);
            //other.transform.Rotate(Vector3.forward, Mathf.Atan2(other.transform.position.x, other.transform.position.y));
            var dir = other.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            other.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); 
                //Vector3.Reflect(other.transform.position, other.transform.position);
            //other.transform.
        }

    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    print("Points colliding: " + other.contacts.Length);
    //    print("First normal of the point that collide: " + other.contacts[0].normal);

    //    other.transform.position = Vector3.Reflect(other.transform.position, other.contacts[0].normal);
    //}



}