using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Armory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.GetComponent<Tank>() != null)
            {
            other.gameObject.GetComponent<Tank>().Health = 100f;
            other.gameObject.GetComponent<Tank>().Fuel = 100f;
            other.gameObject.GetComponent<Tank>().Shells = 10;

        }

        if (other.gameObject.GetComponent<Tank>().isGem)
        {
            //TODO Congratulations
            if (SceneManager.sceneCount < SceneManager.GetActiveScene().buildIndex + 1)
            {
                SceneManager.LoadScene(0);
            }
            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }
}
