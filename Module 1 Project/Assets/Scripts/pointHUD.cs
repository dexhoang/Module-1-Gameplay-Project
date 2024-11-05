using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointHUD : MonoBehaviour
{
    public Text points;
    public float total;
    public float speed;

    private void Start()
    {
        total = 0;
        speed = 0;
    }

    private void Update()
    {
        points.text = "Points: " + (int)total;
        total += speed + Time.deltaTime;
    }
}
