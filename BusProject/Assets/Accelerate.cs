using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour
{
    public float currentVelocity = 0.0f;
    public float maxVelocity = 30;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Abfragen ob Bus nach vorne fahren soll
        if (Input.GetAxis("Vertical") > 0)
        {
            if (currentVelocity < maxVelocity)
            {
                currentVelocity += 0.5f;
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
                currentVelocity--;
            }
        }

        this.transform.Translate(new Vector3(0, 0, -1) * currentVelocity * Time.deltaTime);
    }
}
