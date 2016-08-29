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

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    //Excute if the object tag was equal to one of these
    //    if (other.tag == "TankShell" || other.tag == "EnemyShell" || other.tag == "Ball")
    //    {
    //        if (other.tag != "TankShell")
    //        {
    //            Destroy(other.gameObject);
    //        }
    //       // print(other.tag);



    //        var dir = other.transform.position - transform.position;
    //        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //        other.transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward); 

    //    }

    //}


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "TankShell" || coll.gameObject.tag == "EnemyShell" || coll.gameObject.tag == "Ball")
        {
            //Получилось!!!!!!!!!!!! Нужно чтобы у прилетевшего объекта в коллайдере стоял Phisics2D.Material (friction=0, bounce=1)
            //и был выключен триггер
            ContactPoint2D contact = coll.contacts[0];
            var direction = Vector3.Reflect(coll.gameObject.transform.up * 5, contact.normal);
            var angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
            coll.gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}





    }