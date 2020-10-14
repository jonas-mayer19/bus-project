using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class MovingWheels : MonoBehaviour
{
    private float turn = 0f;
    private GameObject bus;

    void TurnWheels()
    {
        
        
        float ybus = bus.transform.eulerAngles.y;                                                        //zum zurücksetzten der Räder auf Busposition
        var forwardBus = bus.transform.forward;                                                          //Winkelberechung zwischen Rad und Bus
        var forwardWheel = transform.forward;
        var angle = Vector3.Angle(forwardBus, forwardWheel);
        Debug.Log( angle);
       
        if (Input.GetKey("right") && angle < 35)
        {
            turn += 0.2f;
        }
        else if (Input.GetKey("left") && angle < 35)
        {
            turn -= 0.2f;
        }
        else if (Input.GetKey("up") && !(Input.GetKey("left")|| Input.GetKey("right")))
        {

            turn = ybus;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, turn, transform.eulerAngles.z);    //y-Rotation der Räder     

            
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, turn, transform.eulerAngles.z);    //y-Rotation der Räder     
     


    }


    // Start is called before the first frame update
    void Start()
    {
        bus = GameObject.Find("Bus");

    }

    // Update is called once per frame
    void Update()
    {
        
            TurnWheels();
    }
}
