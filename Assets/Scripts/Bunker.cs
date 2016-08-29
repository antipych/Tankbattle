using UnityEngine;
using System.Collections;

public class Bunker : MonoBehaviour {

    //объявить список наших картинок
    public Sprite[] img;
    private SpriteRenderer theSprite;

    // Use this for initialization
    void Start () {
        theSprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "TankShell" || other.tag == "EnemyShell" || other.tag == "Ball")
        {
            Destroy(other.gameObject);
        }
        else if (other.tag == "PlayerTank")
        {
            if (other.gameObject.GetComponent<Tank>() != null)
            {
                theSprite.sprite = img[1];

            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<Tank>() != null)
        {
            theSprite.sprite = img[0];
        }
    }

}
