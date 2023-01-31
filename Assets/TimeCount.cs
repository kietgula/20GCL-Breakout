using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCount : MonoBehaviour
{
    TextMeshProUGUI timeText;
    public static float time = 0;

    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        timeText.text = "Time:" + time.ToString();
    }
}
