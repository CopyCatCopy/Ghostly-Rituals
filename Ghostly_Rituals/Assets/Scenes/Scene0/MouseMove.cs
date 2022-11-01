using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float thrustScale;
    public float scaler;
    private Rigidbody2D rb2;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Consider Time.Deltatime
        Debug.Log(Time.deltaTime);

        float inX = Time.deltaTime * scaler * Input.GetAxis("Horizontal");
        float inY = Time.deltaTime * scaler * Input.GetAxis("Vertical");
        transform.position += new Vector3(inX, inY, 0);
        Debug.Log(inX + ", " + inY);

        //Thrusters
        float thrust = thrustScale * Input.GetAxis("Vertical");
        rb2.AddForce(transform.up * thrust);
    }
}
