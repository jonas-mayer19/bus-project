using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class MovingWheels : MonoBehaviour
{
    private float turn = 0f;
    private GameObject bus;
    WheelCollider wheels;

    void TurnWheels()
    {


        float ybus = bus.transform.eulerAngles.y;                                                        //zum zurücksetzten der Räder auf Busposition
        var forwardBus = bus.transform.forward;                                                          //Winkelberechung zwischen Rad und Bus
        var forwardWheel = transform.forward;
        var angle = Vector3.SignedAngle(forwardWheel, forwardBus, bus.transform.up);                    //angle in von -180 bis 180 grad
      
        
        if (Input.GetKey("right") && angle > -30)
        {
            turn += 1.8f;
        }
        else if (Input.GetKey("left") && angle < 30)
        {
            turn -= 1.8f;
        }
        else if (Input.GetKey("up") && !(Input.GetKey("left") || Input.GetKey("right")))
        {
            turn = ybus;
           /* if (turn < ybus)                                                                            //langsames zurückdrehen der Räder
            {
                turn += 2f;
            }
            else if (turn > ybus)
            {
                turn -= 2f;
            }*/


        }
        else if (Input.GetKey("down") && !(Input.GetKey("left") || Input.GetKey("right")))
        {
            turn = ybus;
           /* if (turn < ybus)                                                                            //langsames zurückdrehen der Räder
            {
                turn += 2f;
            }
            else if (turn > ybus)
            {
                turn -= 2f;
            }
           */
        }
        

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, turn, transform.eulerAngles.z);    //y-Rotation der Räder     

    }


    // Start is called before the first frame update
    void Start()
    {
        bus = GameObject.Find("Bus");
        wheels = this.GetComponent<WheelCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        
            TurnWheels();
    }
}
