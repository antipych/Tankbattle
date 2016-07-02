using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

    private Vector3 PitVector;
    public GameObject Wreck;
    public GameObject FreeGem;
    public bool GemInside;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "TankShell" || other.tag == "EnemyShell")
        {
            Destroy(other.gameObject);

            if (GemInside)
            {
                PitVector = transform.position;
                PitVector.z = 1;
                var EmptyGem = Instantiate(FreeGem, PitVector, transform.rotation) as GameObject;
            }

            PitVector.z = 2;
            var q = Instantiate(Wreck, PitVector, transform.rotation) as GameObject;


            Destroy(gameObject);
            GameObject.Find("Tank").GetComponent<Tank>().Scores += 100;
        }
    }
}
