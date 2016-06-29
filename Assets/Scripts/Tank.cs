using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float TurnSpeed = 90f;

    float Health = 3f;
    public float Fuel = 100f;
    public float Scores = 0f;
    public bool isGem = false;

    public float Lives = 5f;
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

        SetTexts();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rotate) > 0.1f)
        {
            // TODO: другая анимация
            anim.SetBool("Move", true);

            if (rotate > 0)
            {
                transform.Rotate(Vector3.forward, -TurnSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.forward, TurnSpeed * Time.deltaTime);
            }
        }


        if (Mathf.Abs(move) > 0.1f)
        {
            anim.SetBool("Move", true);
            Fuel= Fuel - MoveSpeed * Time.deltaTime;
            SetTexts();
            if (Fuel <= 0)
            {
                Respawn();
            }

            if (move > 0)
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

        if (Time.time > nextFire && Input.GetAxis("Fire1") > 0 && !isInDock)
        {
            nextFire = Time.time + fireRate;
            var q= Instantiate(shell, shotSpawn.position, shotSpawn.rotation) as GameObject;
            q.tag = "TankShell";
        }

        heading = (start - transform.position).magnitude;

        if (heading<1 && isGem)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            //Debug.Log("");
        }
    }

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "EnemyShell")
        {
            var shell = other.gameObject.GetComponent<Shell>();
            Health -= shell.Power;

            Destroy(other.gameObject);

            if (Health < 0)
            {
                Respawn();
            }

            SetTexts();
        }

        if (other.tag == "GemFree")
        {
            isGem=true;

            Destroy(other.gameObject);

            Scores += 100;

            SetTexts();
        }
    }

    private void Respawn()
    {
        --Lives;
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

        Health = 3f;
        Fuel = 100f;

        SetTexts();
        //if()
    }

    void SetTexts()
    {
        //string GemText = "False";
        //if (isGem == true)
        //{ GemText= "True"; }

        if (LivesText == null)
            return;
        LivesText.text = "Lives: " + Lives.ToString() + "  Health: " + (33 * Health + 1).ToString() + "%" +
            "  Fuel: " + Fuel.ToString("F00") + "  Scores: " + Scores.ToString("F00"); // +" Gem:"+GemText;

        //Debug.Log(isGem);
    }
}
