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
    // Start is called before the first frame update
    void Start()
    {
        GenerateLables();
        needle = gameObject.transform.Find("Needle");
    }

    // Update is called once per frame
    void Update()
    {
        float speed = targetObject.GetComponent<Rigidbody>().velocity.magnitude;
        needle.rotation = Quaternion.Euler(0, 0, CalcAngle(speed));
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
    }
    public float CalcAngle(float speed) {
        return (45 - (speed * 270 / maxLabel));
    }
    }
