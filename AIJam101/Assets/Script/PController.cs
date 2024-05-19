using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class PController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;

    private void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float horizontalA = Input.GetAxis("Horizontal");
        float verticalA = Input.GetAxis("Vertical");

        float currentAngle = gameObject.transform.eulerAngles.y;

        Vector3 movement = (transform.forward * verticalA + transform.right * horizontalA).normalized * speed;

        rb.velocity = new Vector3(-movement.x, rb.velocity.y, -movement.z);

        Vector2 mousepos = Input.mousePosition;

        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x,mousepos.x,gameObject.transform.eulerAngles.z);

    }
}
