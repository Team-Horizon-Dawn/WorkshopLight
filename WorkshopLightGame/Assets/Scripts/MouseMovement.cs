using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MouseMovement : MonoBehaviour
{
    private Rigidbody rb;
    
    public float rotationSpeed;

    public float speed;

    public float jumpforce;

    private int doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        doubleJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion originalRotation = transform.rotation;
        if (Input.GetButton("Horizontal"))
        {
            print(Input.GetAxisRaw("Horizontal"));
            transform.Rotate(0, 0, -Input.GetAxisRaw("Horizontal") * (rotationSpeed * Time.deltaTime), Space.Self);
        }

        if (Input.GetButton("Vertical"))
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }

        if (Math.Abs(transform.position.y - 0.5f) < 0.01)
        {
            jumpforce = 250;
        }
    
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpforce);
        }

        //used for resetting Z rotation
        var mouseTransform = transform;
        Quaternion q = mouseTransform.rotation;
        q.eulerAngles = new Vector3(90, q.eulerAngles.y, q.eulerAngles.z);
        mouseTransform.rotation = q;
    }
}
