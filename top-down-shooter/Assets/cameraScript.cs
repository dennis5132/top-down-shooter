using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform plTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(plTransform.position.x, plTransform.position.y, -10);
    }
}
