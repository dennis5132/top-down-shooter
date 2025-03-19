using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class zombiescript : MonoBehaviour
{
    
    private Transform m_transform;
    //public GameObject zmanager;
    public zombieManager manager;
    public int pointsIndex = 0;
    public int startpoint;
    public int currentHealth;
    //public int BaseStucktime;
    private float stuckTime;
    

    

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<zombieManager>();
        startpoint = Random.Range(0, 5);
        transform.position = manager.Points[startpoint].transform.position;
        m_transform = this.transform;
        currentHealth = manager.baseHealth;
        pointsIndex = Random.Range(0, manager.Points.Length);
        stuckTime = manager.BaseStuckTime;

        //manager.layerCast = "Level";
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, manager.plTransform.position) < manager.sight)
        {
            moveTo(manager.plTransform);
            
        }
        else if (pointsIndex <= manager.Points.Length -1) 
        {
            moveTo(manager.Points[pointsIndex].transform);
            if (Vector2.Distance(this.transform.position, manager.Points[pointsIndex].position) < 0.1)
            {
                //pointsIndex++;
                pointsIndex = Random.Range(0, manager.Points.Length);
            }
            
            if (pointsIndex == manager.Points.Length) 
            {
                pointsIndex = 0;
            }
            
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            currentHealth -= 1;
            if (currentHealth < 1)
            {
                Destroy(this.gameObject);
            }
            
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        stuckTime -= 1 * Time.deltaTime;
        if (stuckTime <= 0) 
        { 
            pointsIndex = Random.Range(0, manager.Points.Length);
            stuckTime = manager.BaseStuckTime * 0.5f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        stuckTime = manager.BaseStuckTime;
    }

    private void moveTo(Transform target)
    {
        
        Debug.DrawRay(transform.position, target.position - transform.position, Color.red);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position - transform.position, 5, manager.layerCast);
        ////Debug.Log(hit);
        //if (hit)
        //{
        //    Debug.Log(hit.collider);
        //    transform.rotation = Quaternion.LookRotation(Vector2.up, target.position - transform.position);
        //    transform.position += manager.moveSpeed * Time.deltaTime * Vector3.right; //fix later
        //}
        //else
        //{
            transform.position = Vector2.MoveTowards(transform.position, target.position, manager.moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
            //Debug.Log("no hit");
        //}

}
}
