using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visuale : MonoBehaviour
{

    public float sensitivity = 1.0f;

    private CharacterController controller;
    private float pitch = 0.0f;
    private float yaw = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotazione della visuale
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }
}
