using System;
using UnityEngine;
using UnityEngine.UI;

public class Tacho : MonoBehaviour
{
    public GameObject templateLabel;
    public GameObject targetObject;
    public int divisions;
    public int maxLabel;
    private Transform needle;
    private Vector3 lastPos;
    private Vector3 currPos;
    // Start is called before the first frame update
    void Start()
    {
        ShowTacho(true);
        GenerateLables();
        needle = gameObject.transform.Find("Needle");
        lastPos = targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 velocity = targetObject.GetComponent<Rigidbody>().velocity; //using rigidbody
        //float speed = (new Vector3(velocity.x, 0, velocity.z)).magnitude; // Only in XZ plane using rigidbody
        currPos = targetObject.transform.position;
        Vector3 travel = (currPos - lastPos); //using travel over time        
        float speed = (new Vector3(travel.x, 0, travel.z)).magnitude / Time.deltaTime; // Only in XZ plane using travel over time
        needle.rotation = Quaternion.Euler(0, 0, CalcAngle(speed));
        lastPos = currPos;
    }

    public void GenerateLables()
    {
        for (int i = 0; i <= maxLabel; i += (maxLabel / divisions))
        {
            GameObject lable = Instantiate(templateLabel, Vector3.zero, Quaternion.Euler(0, 0, CalcAngle(i)));
            lable.transform.SetParent(gameObject.transform,false);
            Transform number = lable.transform.Find("Number");
            number.GetComponent<Text>().text = i.ToString();
            number.eulerAngles = Vector3.zero;
            lable.SetActive(true);
        }
        gameObject.transform.Find("Needle").SetAsLastSibling();
    }
    public float CalcAngle(float speed) {
        return (45 - (speed * 270 / maxLabel));
    }
    public void ShowTacho(bool active)
    {
        gameObject.transform.Find("Dial").gameObject.SetActive(active);
        gameObject.transform.Find("Needle").gameObject.SetActive(active);
        gameObject.transform.Find("Description").gameObject.SetActive(active);
    }
}
