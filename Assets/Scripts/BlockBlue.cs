using UnityEngine;
using System.Collections;

public class BlockBlue : MonoBehaviour {

    //объявить список наших картинок
    public Sprite[] img;
    public bool CurrentState = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (CurrentState)
        {
            this.GetComponent<SpriteRenderer>().sprite = img[0];
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = img[1];
        }
        this.GetComponent<BoxCollider2D>().isTrigger = !CurrentState;
    }

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "TankShell" || other.tag == "EnemyShell")
        {
            if (CurrentState) { Destroy(other.gameObject); }

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {   
        CurrentState = true;
    }
    void OnCollisionStay2D(Collision2D Col)
    {
        //Excute if the object tag was not equal to one of these
        if (Col.gameObject.tag != "TankShell" && Col.gameObject.tag != "EnemyShell")
        {
            CurrentState = false;
        }

    }



}
