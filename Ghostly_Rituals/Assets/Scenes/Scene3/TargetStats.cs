using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStats : MonoBehaviour
{
    public int health;
    public int xp;
    public GameObject theShip;
    AudioSource boom;

    // Start is called before the first frame update
    void Start()
    {
        theShip = GameObject.Find("Ship");
        boom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Target hit!!!");
            boom.Play();
            Destroy(collision.gameObject);
            transform.localScale *= 0.80f;
            health--;
            xp++;
            theShip.GetComponent<ShipMovement>().xp += xp;
            if(health < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
