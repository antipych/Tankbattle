using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {


    Color c1 = Color.yellow;
    Color c2 = Color.red;
    LineRenderer lineRenderer;
    Vector3 StartRayVector;
    Vector3 RayVector;
    RaycastHit2D hit;

    // Use this for initialization
    void Start () {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(.1f, .1f);
        lineRenderer.SetVertexCount(2);
        
    }


    void FixedUpdate()
    {


        //Получаем вектор точки старта (со смещением чтобы не пересекалось с коллайдером корпуса лазера)
        StartRayVector = new Vector3(transform.position.x + Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)/5, transform.position.y + Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)/5, 0);

        lineRenderer.SetPosition(0, StartRayVector);

        RayVector = new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)*100, Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * 100, 0) ;

        hit = Physics2D.Raycast(StartRayVector, RayVector);
        if (hit.collider != null)
        {

            lineRenderer.SetPosition(1, hit.point);
            if (hit.collider.gameObject.name == "Tank")
            {
                //GameObject.Find("Tank").GetComponent<Tank>().Scores += 100;
                hit.collider.gameObject.GetComponent<Tank>().Health -= 0.5f;
            }
        }

    }

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
    {
        //Excute if the object tag was equal to one of these
        if (other.tag == "TankShell")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            GameObject.Find("Tank").GetComponent<Tank>().Scores += 100;
        }

        if (other.tag == "Ball")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
