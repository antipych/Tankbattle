using UnityEngine;
using System.Collections;
using System;

public class Tank : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float TurnSpeed = 90f;

    public GameObject shell;
    public Transform  shotSpawn;
    public float fireRate = 1F;	//Fire Rate between Shots
    private float nextFire = 0.0F;	//First fire & Next fire Time

    private Rigidbody2D rig;

    //ссылка на компонент анимаций
    private Animator anim;

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
        rig  = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        if (Time.time > nextFire && Input.GetAxis("Fire1") > 0)
        {
            nextFire = Time.time + fireRate;
            var q= Instantiate(shell, shotSpawn.position, shotSpawn.rotation) as GameObject;
            q.tag = "TankShell";
        }
    }

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "EnemyShell")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
