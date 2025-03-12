using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class playerScript : MonoBehaviour
{
    public float plMaxSpeed = 5f; // maximale snelheid van de player
    private Rigidbody2D plRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        plRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // uitlezen van de pijltjestoetsen
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //bewegen van het object
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        plRigidBody.AddForce(movement * 100f);

        //beperken van de snelheid
        if (plRigidBody.velocity.magnitude > plMaxSpeed)
        {
            plRigidBody.velocity = plRigidBody.velocity.normalized * plMaxSpeed;
        }
        //speler laten stoppen
        if (plRigidBody.velocity.magnitude > 0)
        {
            plRigidBody.velocity = plRigidBody.velocity / 1.4f;
        }
        
        Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 Difference = WorldPoint - transform.position;
        Difference.Normalize();

        float RotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotationZ - 90);
    }
}
