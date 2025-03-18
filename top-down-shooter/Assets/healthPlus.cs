using System.Collections;
using UnityEngine;

public class healthPlus : MonoBehaviour
{
    public int healthBonus = 2;  // Amount of health to add when collided
    public int maxHealth = 5;  // Maximum health the player can have

    private void Start()
    {
        // Ensure this object has a Collider2D component
        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogWarning("No Collider2D attached to health object!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the player collided with this object
        if (collider.gameObject.CompareTag("Player")) // Assuming your player has the tag "Player"
        {
            // Get the playerScript component from the player object
            playerScript player = collider.gameObject.GetComponent<playerScript>();

            if (player != null)
            {
                // Increase player's health, ensuring it doesn't exceed maxHealth
                player.Health = Mathf.Min(player.Health + healthBonus, maxHealth);

                // Print +2 hp to the console
                Debug.Log("+2 hp");

                // Destroy the health object
                Destroy(gameObject);

                // Start coroutine to respawn object after 15 seconds
                StartCoroutine(RespawnObject());
            }
            else
            {
                Debug.LogWarning("No playerScript found on the player object!");
            }
        }
    }

    // Coroutine to respawn the object after 15 seconds
    private IEnumerator RespawnObject()
    {
        yield return new WaitForSeconds(15f);

        // Respawn the object at the original position (you can modify this if needed)
        Instantiate(gameObject, transform.position, transform.rotation);
    }
}
