using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthScript : MonoBehaviour
{

    public zombiescript zombie;
    public float barLength;
    public float barTop;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        barLength = (0.25f - zombie.currentHealth); Debug.Log(barLength);
        transform.localScale = new Vector2((3 - zombie.currentHealth) / barTop, 0.25f); Debug.Log(transform.localScale);
        //transform.localPosition = new Vector2(barLength / 1, 0); Debug.Log(transform.localPosition);

    }
}
