using UnityEngine;
using System.Collections;
using System;

public class Tank : MonoBehaviour
{
    public int Speed = 4;

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
        left,
        right
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
        float moveV = Input.GetAxis("Vertical");
        float moveH = Input.GetAxis("Horizontal");

        if (Mathf.Abs(moveV) > 0.1f || Mathf.Abs(moveH) > 0.1f)
        {
            anim.SetBool("Move", true);

            if (Mathf.Abs(moveV) > 0.1f)
            {
                rig.velocity = new Vector2(0, moveV * Speed);
                Rotate(moveV > 0 ? Direction.up : Direction.down);
            }
            else
            {
                rig.velocity = new Vector2(moveH * Speed, 0);
                Rotate(moveH > 0 ? Direction.right : Direction.left);
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
            Instantiate(shell, shotSpawn.position, shotSpawn.rotation);
        }
    }

    private void Rotate(Direction d)
    {
        var curEulerAngles = transform.eulerAngles;
        Vector3 newEulerAngles;

        switch (d)
        {
            case Direction.down:
                newEulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                break;
            case Direction.left:
                newEulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                break;
            case Direction.right:
                newEulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
                break;
            default:
                newEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                break;
        }

        if (curEulerAngles != newEulerAngles)
            transform.eulerAngles = newEulerAngles;
    }
}
