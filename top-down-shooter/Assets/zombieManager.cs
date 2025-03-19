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
    public int zombieCount;
    private int spawned;
    public GameObject Zombie;
    public int BaseStuckTime;
    //public zombiescript zom;
    // Start is called before the first frame update
    void Start()
    {
        
        while (spawned < zombieCount) 
        { 
            spawned++;
            Instantiate(Zombie, transform.position,Quaternion.identity);

            //zom.startpoint = Random.Range(0, 5);
            //transform.position = Points[zom.startpoint].transform.position;
            //zom.currentHealth = baseHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
