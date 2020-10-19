using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour
{
    public float currentVelocity = 0.0f;
    public float maxVelocity = 30;
    GameObject bus;
    Rigidbody bus_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bus = GameObject.Find("Bus");
        bus_rigidbody = bus.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // Beschleunigen
        if (Input.GetAxis("Vertical") > 0)
        {
            if (currentVelocity < maxVelocity)
            {
                currentVelocity += 0.25f;
                bus_rigidbody.AddForce(0,-50,0, ForceMode.Impulse);
            }
        }
        // Bremsen und rückwärts fahren
        else if (Input.GetAxis("Vertical") < 0)
        {
            if (currentVelocity > 0)
            {
                currentVelocity--;
            }
            else if (currentVelocity <= 0 && Math.Abs(currentVelocity) < maxVelocity / 2)
            {
                currentVelocity -= 0.1f;
            }
        }
        // Bus ausrollen lassen
        else if (Input.GetAxis("Vertical") == 0 && currentVelocity != 0)
        {
            if (Math.Abs(currentVelocity) < 1)
            {
                currentVelocity = 0;
            }
            else if (currentVelocity < 0)
            {
                currentVelocity++;
            }
            else
            {
                currentVelocity -= 0.5f;
            }
            bus_rigidbody.AddForce(0, 50, 0, ForceMode.Impulse);
        }

        this.transform.Translate(new Vector3(0, 0, -1) * currentVelocity * Time.deltaTime);
        
    }
}
