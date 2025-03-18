using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieManager : MonoBehaviour
{
    [SerializeField] public Transform[] Points;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float sight;
    public Transform plTransform;
    public LayerMask layerCast;
    public int baseHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
