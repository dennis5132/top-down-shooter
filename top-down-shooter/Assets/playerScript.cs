using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

public class playerScript : MonoBehaviour
{
    public float plMaxSpeed = 5f; // maximale snelheid van de player
    private Rigidbody2D plRigidBody;
    public Transform target;
    

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
        if (plRigidBody.velocity.magnitude > plMaxSpeed * Time.deltaTime)
        {
            plRigidBody.velocity = plRigidBody.velocity.normalized * plMaxSpeed * Time.deltaTime;
        }
        //speler laten stoppen
        if (plRigidBody.velocity.magnitude > 0)
        {
            plRigidBody.velocity = plRigidBody.velocity / 1.4f;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

    }
}
