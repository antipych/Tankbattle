using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float TurnSpeed = 90f;

    public float Health = 100f;
    public float Fuel = 100f;
    public float Scores = 0f;
    public bool isGem = false;

    public float Lives = 5f;
    public float Shells = 10f;
    public Text  LivesText;
    public Text GameResult;

    public GameObject shell;
    public Transform  shotSpawn;
    public GameObject Wreck;
    public GameObject FreeGem;

    public float fireRate = 1F;	//Fire Rate between Shots
    private float nextFire = 0.0F;	//First fire & Next fire Time

    private Rigidbody2D rig;

    //ссылка на компонент анимаций
    private Animator anim;

    private Vector3 start;
    private Vector3 PitVector;
    private Quaternion startRotation;

    public float heading;

    bool ShowGameOver = false;

    float move;
    float rotate;

    public bool isInDock { get {
            return heading < 1;
    } }

    public enum Direction
    {
        up,
        down,
        rLeft,
        rRight
    }

    // Use this for initialization
    void Start()
    {
        start = transform.position;
        startRotation = transform.rotation;

        rig  = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Time.timeScale = 1;

        SetTexts();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") == true)
            //if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
            move = 1;
        if (Input.GetKeyUp("up") == true)
            move = 0;
        if (Input.GetKeyDown("down") == true)
            //if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
            move = -1;
        if (Input.GetKeyUp("down") == true)
            move = 0;
        //if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        //    rotate = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("left") == true)
            //if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
            rotate = -1;
        if (Input.GetKeyUp("left") == true)
            rotate = 0;
        if (Input.GetKeyDown("right") == true)
            //if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
            rotate = 1;
        if (Input.GetKeyUp("right") == true)
            rotate = 0;

        Move(move);
        Rotate(rotate);
        Fire(Input.GetAxis("Fire1") > 0);







        heading = (start - transform.position).magnitude;

        //Теперь есть бункер для приноса кристалла!!!
        //if (heading<1 && isGem)
        //{
        //    //TODO Congratulations
        //    if (SceneManager.sceneCount < SceneManager.GetActiveScene().buildIndex + 1)
        //    {
        //        SceneManager.LoadScene(0);
        //    }
        //    else  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        //}

        //Теперь есть бункер для зарядки!!!
        //if (heading<1)
        //{
        //    Health = 100f;
        //    Fuel = 100f;
        //    Shells = 10;
        //}

        if (Health <= 0)
        {
            Respawn();
        }

        if (Fuel <= 0)
        {
            Respawn();
        }

        SetTexts();

    }

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "EnemyShell" || other.tag == "TankShell")
        {
            var shell = other.gameObject.GetComponent<Shell>();
            Health -= shell.Power;

            Destroy(other.gameObject);
   
        }

        if (other.tag == "Ball")
        {
            var shell = other.gameObject.GetComponent<Ball>();
            Health -= shell.Power;

            Destroy(other.gameObject);

        }

        if (other.tag == "GemFree")
        {
            isGem=true;

            Destroy(other.gameObject);

            Scores += 100;

        }


    }

    private void Respawn()
    {
        --Lives;

        if (Lives < 1) ShowGameOver = true;

        PitVector = transform.position;

        if (isGem==true) {

            isGem = false;
            
            PitVector.z = 0;
            var EmptyGem = Instantiate(FreeGem, PitVector, transform.rotation) as GameObject;
            //EmptyGem.transform.parent = gameObject.transform.parent;
            //EmptyGem.tag = "FreeGem";

        }
        PitVector = transform.position;
        PitVector.z = 1;
        var q = Instantiate(Wreck, PitVector, transform.rotation) as GameObject;
        q.transform.parent = gameObject.transform.parent;

        transform.position = start;
        transform.rotation = startRotation;

        Health = 100f;
        Fuel = 100f;
        Shells = 10;


    }

    void SetTexts()
    {
        //string GemText = "False";
        //if (isGem == true)
        //{ GemText= "True"; }

        if (LivesText == null)
            return;
        LivesText.text = 
            "Lives: " + Lives.ToString() + 
            "\nHealth: " + (Health).ToString("###") + "%" +
            "\nFuel: " + Fuel.ToString("F00") +
            "\nShells: " + Shells.ToString("F00") +
            "\nScores: " + Scores.ToString("F00"); // +" Gem:"+GemText;

        //Debug.Log(isGem);
    }

    void OnGUI()
    {

        if (ShowGameOver)
        {

            // GUILayout.Box("Congratulations! You Win!");
            //GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 60), "Congratulations!You Win!");
            Time.timeScale = 0;
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 60), "Game Over! \n Press to Continue..."))
            {

                    Time.timeScale = 1; 
                    Scores = 0;
                    SceneManager.LoadScene(0);

            }



        }

    }

    public void SetMove(float movedirection)
    {
        move = movedirection;
    }
    void Move(float movedirection)
    {
        if (Mathf.Abs(movedirection) > 0.1f)
        {
            anim.SetBool("Move", true);
            Fuel = Fuel - MoveSpeed * Time.deltaTime;
     


            if (movedirection > 0)
            {
                transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
            }
        }
        else
        {
            anim.SetBool("Move", false);
            rig.velocity = Vector2.zero;
        }
    }

    public void SetRotate(float rotatedirection)
    {
        rotate = rotatedirection;
    }
    void Rotate(float rotatedirection)
    {
        if (Mathf.Abs(rotatedirection) > 0.1f)
        {
            // TODO: другая анимация
            anim.SetBool("Move", true);

            if (rotatedirection > 0)
            {
                transform.Rotate(Vector3.forward, -TurnSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.forward, TurnSpeed * Time.deltaTime);
            }
        }

    }

    public void Fire(bool InputFire)
    {
        if (Time.time > nextFire && InputFire && !isInDock)
        {
            if (Shells > 0)
            {
                nextFire = Time.time + fireRate;
                var q = Instantiate(shell, shotSpawn.position, shotSpawn.rotation) as GameObject;
                q.tag = "TankShell";
                --Shells;

            }
        }

    }
}
