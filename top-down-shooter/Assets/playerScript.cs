using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;
using TMPro; // Import TextMeshPro namespace

public class playerScript : MonoBehaviour
{
    public float plMaxSpeed = 5f; // maximale snelheid van de player
    private Rigidbody2D plRigidBody;
    public Transform target;
    public int Health;

    // Add a reference to the TextMeshProUGUI component
    public TextMeshProUGUI healthText;

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
        plRigidBody.AddForce(movement * plMaxSpeed);

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

        // Update the health text every frame
        if (healthText != null)
        {
            healthText.text = "Health: " + Health.ToString(); // Update the health display
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health -= 1;
            Debug.Log(Health);
            if (Health <= 0)
            {
                SceneManager.LoadScene("slainMenu");
            }
        }
    }
}
