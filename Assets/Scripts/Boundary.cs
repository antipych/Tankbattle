using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "TankShell" || other.tag == "EnemyShell")
        {
            Destroy(other.gameObject);
        }
    }
}
