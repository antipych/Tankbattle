using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    public float changestateRate = 5F;     //Fire Rate between changestate
    private float nextChangeState = 0.0F;	//First changestate & Next changestate Time
    private bool CurrentState = true;

    //объявить список наших картинок
    public Sprite[] img;

    // Use this for initialization
    void Start () {
        nextChangeState = Time.time + Random.Range(0, changestateRate) + changestateRate;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextChangeState)
        {
            nextChangeState = Time.time + changestateRate;
            //Changes state
            CurrentState = !CurrentState;
            if(CurrentState)
            {
                this.GetComponent<SpriteRenderer>().sprite= img[0];
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = img[1];
            }
            this.GetComponent<BoxCollider2D>().enabled = CurrentState;
        }
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
}
