using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speedMove = 3;
    public float speedRotate = 3;

    public float minRightX;
    public float maxRightX;

    public float minAngleZ;
    public float maxAngleZ;

    private float zRot;
    private float coffAngle;

    public GameObject objVisual;

    public GameObject bulletObj;
    public Transform cannon;

    public float powerOfShot;

    void Update()
    {
        shipMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireShip();
        }
    }
    private void shipMovement()
    {
        zRot = coffAngle * Input.GetAxis("Horizontal");

        if (zRot > maxAngleZ)
            zRot = maxAngleZ;

        if (zRot < minAngleZ)
            zRot = minAngleZ;

        objVisual.transform.eulerAngles = new Vector3(0, 0, zRot);

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            if (coffAngle != 0) coffAngle = 0;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            coffAngle += speedRotate * Time.deltaTime;

        if (Input.GetAxis("Horizontal") == 0 && coffAngle > 0)
            coffAngle -= (speedRotate * 7) * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow) && (transform.position.x < maxRightX))
            transform.Translate(Vector3.right * speedMove * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow) && (transform.position.x > minRightX))
            transform.Translate(Vector3.left * speedMove * Time.deltaTime);
    }

    private void fireShip()
    {
        GameObject bullet = GameObject.Instantiate(bulletObj, cannon.position, cannon.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(-Vector3.forward, ForceMode.Impulse);
    }
}
