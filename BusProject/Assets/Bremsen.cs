using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bremse : MonoBehaviour
{

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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float t = keyPressedTimer();
        Debug.Log("t: " + t);
        float a = -1f;
        float v = GetComponent<Accelerate>().currentVelocity;
        Debug.Log("v: " + v);
        //GetComponent<Rigidbody>().velocity;
        if (v > 0 && Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("vnew: " + this.Break(v, t, a) * Time.deltaTime);
            transform.Translate(0, 0, (this.Break(v, t, a) * Time.deltaTime));

        }
    }
}
