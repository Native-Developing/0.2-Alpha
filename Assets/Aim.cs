using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public int AimButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(AimButton))
        {
            transform.position += new Vector3(0.80f, -0.25f, -0.65f);
            transform.Rotate(-2.78f, 0, 0);

        }
        if (Input.GetMouseButtonUp(AimButton))
        {
            transform.position += new Vector3(-0.80f, 0.25f, 0.65f);
            transform.Rotate(2.78f, 0, 0);
        }
    }
}
