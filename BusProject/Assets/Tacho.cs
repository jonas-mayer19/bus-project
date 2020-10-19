using System;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class Tacho : MonoBehaviour
{
    public GameObject templateLabel;
    public GameObject targetObject;
    public int divisions;
    public int maxLabel;
    private Transform needle;
    private Drive accelerate;
    // Start is called before the first frame update
    void Start()
    {
        ShowTacho(true);
        GenerateLables();
        needle = gameObject.transform.Find("Needle");
        accelerate = targetObject.GetComponent<Drive>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Math.Abs(accelerate.currentVelocity * 3.6f);
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
