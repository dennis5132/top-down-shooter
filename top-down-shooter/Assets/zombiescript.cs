using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class zombiescript : MonoBehaviour
{
    
    private Transform m_transform;
    public zombieManager manager;
    private int pointsIndex = 0;
    public int startpoint;
    private int currentHealth;
    

    

    // Start is called before the first frame update
    void Start()
    {
        startpoint = Random.Range(0, manager.Points.Length);
        transform.position = manager.Points[pointsIndex].transform.position;
        m_transform = this.transform;
        //manager.layerCast = "Level";
        currentHealth = manager.baseHealth;


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

    private void moveTo(Transform target)
    {
        
        Debug.DrawRay(transform.position, target.position - transform.position, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position - transform.position, 5, manager.layerCast);
        //Debug.Log(hit);
        if (hit)
        {
            

            Debug.Log(hit.collider);
            transform.rotation = Quaternion.LookRotation(Vector2.up, target.position - transform.position);
            transform.position += manager.moveSpeed * Time.deltaTime * Vector3.right; //fix later
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, manager.moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
            Debug.Log("no hit");
        }

}
}
