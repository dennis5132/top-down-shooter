using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class zombiescript : MonoBehaviour
{
    [SerializeField] Transform[] Points;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sight;
    public Transform plTransform;

    private int pointsIndex = 0;
    public int startpoint;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, plTransform.position) < sight)
        {
            moveTo(plTransform);
        }
        else if (pointsIndex <= Points.Length -1) 
        {
            moveTo(Points[pointsIndex].transform);
            if (Vector2.Distance(this.transform.position, Points[pointsIndex].position) < 0.1)
            {
                pointsIndex++;
            }
            
            if (pointsIndex == Points.Length) 
            {
                pointsIndex = 0;
            }
            
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }

    private void moveTo(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
