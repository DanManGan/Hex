using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public float rotateSpeed = 30.0f;
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0f;

    Camera m_Cam;

    // Use this for initialization
    void Start()
    {
        m_Cam = GetComponent<Camera>();
        m_Cam.clearFlags = CameraClearFlags.SolidColor;

        RandomiseColours();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the camera
        transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);

        // Change background colour
        float t = Mathf.PingPong(Time.time, duration) / duration;
        m_Cam.backgroundColor = Color.Lerp(color1, color2, t);
    }

    public void RandomiseColours()
    {
        color1 = new Color(Random.value, Random.value, Random.value, 1.0f);
        color2 = new Color(Random.value, Random.value, Random.value, 1.0f);
    }
}
