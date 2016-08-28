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
           // print(other.tag);



            var dir = other.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            other.transform.rotation = Quaternion.AngleAxis(angle+180, Vector3.forward); 

        }

    }





}