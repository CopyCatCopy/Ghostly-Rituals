using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    public float rotateScale;
    public float thrustScale;
    public float scaler;
    private Rigidbody2D rb2;
    public GameObject Bullet;
    public GameObject FireForm;
    public float fireSpeed = 1000;
    public int xp = 0;
    public int bulletCount = 10;
    public Text XPtext;
    public GameObject AmmoMask;
    AudioSource pewSound;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        pewSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate ship
        float rotation = rotateScale * Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, -rotation));

        //Consider Time.Deltatime
        Debug.Log(Time.deltaTime);

        float inX = Time.deltaTime * scaler * Input.GetAxis("Horizontal");
        float inY = Time.deltaTime * scaler * Input.GetAxis("Vertical");
        transform.position += new Vector3(inX, inY, 0);
        Debug.Log(inX + ", " + inY);

        //Update XP in UI
        XPtext.text = "XP: " + xp.ToString();

        //Thrusters
        float thrust = thrustScale * Input.GetAxis("Vertical");
        rb2.AddForce(transform.up * thrust);

        //Firing
        if( (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) && bulletCount > 0)
        {
            //Debug.Log(Fire!!!);
            pewSound.Play();
            GameObject b = Instantiate(Bullet, FireForm.transform.position, Quaternion.identity);
            bulletCount--;
            AmmoMask.GetComponent<MaskScript>().MoveMask(bulletCount, 10);
            Rigidbody2D rb2b = b.GetComponent<Rigidbody2D>();
            rb2b.AddForce(fireSpeed * transform.up);
            Destroy(b, 2.0f);
        }

        //Reload
        if(Input.GetKeyDown(KeyCode.R))
        {
            bulletCount = 10;
            AmmoMask.GetComponent<MaskScript>().MoveMask(bulletCount, 10);
        }
    }
}
