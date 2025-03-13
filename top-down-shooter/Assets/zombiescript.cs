using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class zombiescript : MonoBehaviour
{
    [SerializeField] Transform[] Points;
    [SerializeField] private float moveSpeed;

    private int pointsIndex = 0;
    //public Vector3 goalpos = Input.mousePosition;
    //public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex <= Points.Length -1) 
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(this.transform.position, Points[pointsIndex].position) < 0.1)
            {
                pointsIndex++;
                Debug.Log(pointsIndex);
            }
            
            Debug.Log("moving");
            if (pointsIndex == Points.Length) 
            {
                pointsIndex = 0;
            }
            
        }
        //transform.up = target.position - transform.position;

        //Vector3 Pos = Camera.main.ScreenToWorldPoint(goalpos);
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, Pos - transform.position);

        //transform.position += transform.up * 0.001f;
    }
    
}
