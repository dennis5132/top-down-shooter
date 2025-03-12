using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var tempbullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            tempbullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 600f);
        }
    }
}
