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
        if(!theColl.isTrigger && (other.tag == "TankShell" || other.tag == "EnemyShell"))
        { 
            Instantiate(Crater, other.gameObject.transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {   
        CurrentState = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<Tank>() != null)
        {
            theSprite.sprite = img[1];
            theColl.isTrigger = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<Tank>() != null)
        {
            theSprite.sprite = img[0];
            theColl.isTrigger = false;
        }
    }
}
