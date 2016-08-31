using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Armory : MonoBehaviour {

    bool ShowThisGUI = false;

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
            ShowThisGUI = true;

        }

    }

    

    void OnGUI()
    {

        if (ShowThisGUI)
        {

            // GUILayout.Box("Congratulations! You Win!");
            //GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 60), "Congratulations!You Win!");
            Time.timeScale = 0;
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 60), "Congratulations!You Win! \n Press to Continue..."))
            {
                Time.timeScale = 1;
                if (SceneManager.sceneCount < SceneManager.GetActiveScene().buildIndex + 1)
                {
                    SceneManager.LoadScene(0);
                }
                else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            

        }

    }
}
