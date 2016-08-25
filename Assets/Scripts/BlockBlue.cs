using UnityEngine;
using System.Collections;

public class BlockBlue : MonoBehaviour {

    //объявить список наших картинок
    public Sprite[] img;
    public bool CurrentState = true;
    public GameObject Crater;


    private BoxCollider2D theColl;
    private SpriteRenderer theSprite;

    // Use this for initialization
    void Start () {
        theColl = GetComponent<BoxCollider2D>();
        theSprite = GetComponent<SpriteRenderer>();
    }





    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(" OnTriggerEnter2D  ");
        //
        if (!theColl.isTrigger && (other.tag == "TankShell" || other.tag == "EnemyShell"))
        { 
            Instantiate(Crater, other.gameObject.transform.position, transform.rotation);
            Destroy(other.gameObject);
           
        }
        else if(other.tag == "PlayerTank")
        {
            if (other.gameObject.GetComponent<Tank>() != null)
            {
                theSprite.sprite = img[1];

            }
        }

  
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("OnTriggerExit2D  ");
        if (other.gameObject.GetComponent<Tank>() != null)
        {
            theSprite.sprite = img[0];
            theColl.isTrigger = false;
            //theColl.isTrigger = true;
            //this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("OnCollisionEnter2D  ");
        if (coll.gameObject.GetComponent<Tank>() != null)
        {
            theSprite.sprite = img[1];
            theColl.isTrigger = true;
            // this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    //void OnCollisionExit2D(Collision2D coll)
    //{
    //    Debug.Log("OnCollisionExit2D  ");
    //    if (coll.gameObject.GetComponent<Tank>() != null)
    //    {
    //        theSprite.sprite = img[0];
    //        //theColl.isTrigger = true;
    //        // this.GetComponent<BoxCollider2D>().enabled = false;
    //    }
    //}
}
