using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float slowSpeed;
    [SerializeField] float boostSpeed;
    [SerializeField] float speedCoolDown;
    [SerializeField] float rotateSpeed;

    float currentSpeed;

    void Start()
    {
        currentSpeed = slowSpeed;
    }
    void Update()
    {
        float rotateInput = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        float moveInput = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -rotateInput);
        transform.Translate(0, moveInput, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedUp"))
        {
            currentSpeed = boostSpeed;
            StartCoroutine("RevertSpeedAfterDelay");
        }
    }

    IEnumerator RevertSpeedAfterDelay()
    {
        yield return new WaitForSeconds(speedCoolDown);
        currentSpeed = slowSpeed;
    }
}
