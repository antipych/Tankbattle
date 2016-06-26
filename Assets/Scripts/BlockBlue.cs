using UnityEngine;
using System.Collections;

public class BlockBlue : MonoBehaviour {

    //объявить список наших картинок
    public Sprite[] img;
    bool CurrentState = true;

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
        this.GetComponent<BoxCollider2D>().enabled = CurrentState;
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

    void OnTriggerStay2D(Collider2D other)
    {

        CurrentState = true;
        //Excute if the object tag was not equal to one of these
        if (other.tag != "TankShell" && other.tag != "EnemyShell")
        {
            CurrentState = false;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Why it's not working????????????
        CurrentState = true;
    }

    void OnCollisionExit2D(Collider2D other)
    {
        //Why it's not working????????????
        CurrentState = true;
    }
}
