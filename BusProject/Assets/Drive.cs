using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;

public class Drive : MonoBehaviour
{
    
    private Vector3 [] direction = new Vector3[2];
    public float velocity = 3f;

    

    private void Move()
    {
        if(Input.GetKey("up"))
        {
            Rotation(true);                                                                  
            this.transform.Translate(direction[0].normalized * velocity * Time.deltaTime );      //Translation zur Objektverschiebung auf Basis der Objektkoordinaten
        }
        else if (Input.GetKey("down"))
        {
            Rotation(false);
            this.transform.Translate(direction[1].normalized * velocity * Time.deltaTime );
        }      
    }
    private void Rotation(bool r)                                                               //boolean zur Unterscheidung von Vor- und Rückwärtsfahren
    {
        float a = -1 * velocity * 2;
        if (Input.GetKey("right"))
        {
            if (r)                                                                              //pos y Kordinaten bei vorwärts, sonst negative
            {
                a *= -1;
            }
            this.transform.Rotate(0, a * velocity * Time.deltaTime, 0);
        }
        else if (Input.GetKey("left"))
        {
            if (!r)                                                                             //neg y Kordinaten bei vorwärts, sonst positive
            {
                a *= -1;
            }
            this.transform.Rotate(0, a * velocity * Time.deltaTime, 0);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        direction[0] = new Vector3(0, 0, -1);                                                   //forward
        direction[1] = new Vector3(0, 0, 1);                                                    //back

    }

    // Update is called once per frame
    void Update()
    {
        Move();
       
    }
    
}
