using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;

public class Drive : MonoBehaviour
{
    
    public float currentVelocity = 0.0f;
    public float maxVelocity = 30;
    Rigidbody bus_rigidbody;
    float a = -1f;



   
    private void Rotation()                                                               //boolean zur Unterscheidung von Vor- und Rückwärtsfahren
    {
        float a = -2 * currentVelocity;
        if (Input.GetKey("right"))
        {
                a *= -1;
            
            this.transform.Rotate(0, a  * Time.deltaTime, 0);
        }
        else if (Input.GetKey("left"))
        {
           
            this.transform.Rotate(0, a  * Time.deltaTime, 0);
        }
    }

    float keyPressedTimer()
    {
        float timePressed = 0.0f;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            timePressed = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            timePressed = Time.time - timePressed;
        }

        /*timePressed += Time.deltaTime;
        float seconds = timePressed % 60;
        */
        return timePressed;
    }

    float Break(float v, float t, float a)
    {
        float vNew = a * t + v;
        return vNew;
    }
    void Accelerate()
    {
        // Beschleunigen
        if (Input.GetAxis("Vertical") > 0)
        {
            
            if (currentVelocity < maxVelocity)
            {
                currentVelocity += 0.25f;
                bus_rigidbody.AddForce(0, -50, 0, ForceMode.Force);
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
            bus_rigidbody.AddForce(0, 50, 0, ForceMode.Force);
        }
        Rotation();
        this.transform.Translate(new Vector3(0, 0, -1) * currentVelocity * Time.deltaTime);

    
    }

    // Start is called before the first frame update
    void Start()
    {
        
        bus_rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Accelerate();

        float t = keyPressedTimer();
        Debug.Log("t: " + t);
        
        Debug.Log("v: " + currentVelocity);
       

        if (currentVelocity > 0 && Input.GetKey(KeyCode.DownArrow))
        {
       
            Debug.Log("vnew: " + this.Break(currentVelocity, t, a) * Time.deltaTime);
            transform.Translate(0, 0, (this.Break(currentVelocity, t, a) * Time.deltaTime));

        }
    }
    
}
