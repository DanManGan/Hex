using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float moveSpeed = 600f;

    float m_Movement = 0f;
    int m_Score = 0;
    CameraScript m_Cam;

    private void Start()
    {
        m_Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update () {
        m_Movement = Input.GetAxisRaw("Horizontal");
	}

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, m_Movement * Time.fixedDeltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int value)
    {
        m_Score = m_Score + value;

        if (m_Score % 50 == 0 && m_Score != 0)
        {
            m_Cam.RandomiseColours();
        }
    }

    public int GetScore()
    {
        return m_Score;
    }
}
