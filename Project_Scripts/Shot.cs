using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject ammoSpawn;
    public GameObject ammo;
    
    private float lastFire = 0.5f;
    public float fireRate;
    private float timer;
    private float timer2;
    public float shootTime;
    public float reset;
    public bool shot;
    public float length;
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > shootTime && shot == false && Time.time > lastFire)
        {
            lastFire = Time.time + fireRate;
            GameObject ammoInstance = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.Euler(0, 0, 0));
            ammoInstance.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.up * -1 * power, ForceMode.Impulse);
            shot = true;
        }

        if (timer > reset)
        {
            timer = 0;
            shot = false;
        }

        timer2 += Time.deltaTime;

        if (timer2 > 0 && timer2 < 5)
        {
            power = 6;
        }

        if (timer2 > 5 && timer2 < 10)
        {
            power = 7;
        }

        if (timer2 > 10 && timer2 < 15)
        {
            power = 8;
        }

        if (timer2 > 15 && timer2 < 20)
        {
            power = 9;
        }

        if (timer2 > 20 && timer2 < 25)
        {
            power = 10;
        }


    }
}
