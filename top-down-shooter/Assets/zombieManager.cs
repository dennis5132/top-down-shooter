using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieManager : MonoBehaviour
{
    public Transform[] Points;
    public float moveSpeed;
    public float sight;
    public float Basesight = 8;
    public Transform plTransform;
    public LayerMask layerCast;
    public int baseHealth;
    public int zombieCount;
    public int Remaining;
    private int spawned;
    public GameObject Zombie;
    public int BaseStuckTime;
    //public zombiescript zom;
    // Start is called before the first frame update
    void Start()
    {
        //float v;
        
        Remaining = zombieCount;
        while (spawned < zombieCount) 
        { 
            spawned++;
            Instantiate(Zombie, transform.position,Quaternion.identity);

            //zom.startpoint = Random.Range(0, 5);
            //transform.position = Points[zom.startpoint].transform.position;
            //zom.currentHealth = baseHealth;
        }
    }
    //public float currentSight(float v)
    //{
    //    return 
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
    public void defeated()
    {
        Remaining--;
        Debug.Log("zombie killed");
        sight = 100 / Mathf.Pow(Remaining, 0.843f);
        Debug.Log(sight);
    }
}
