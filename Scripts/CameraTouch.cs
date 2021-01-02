using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.MobileJoystick;
public class CameraTouch : MonoBehaviour
{
    private Touch initTouch = new Touch();

    public Camera cam;
    private float rotX=0f;
    private float rotY=0f;
    private Vector3 origRot;
    public static float rotspeed = 0.4f;
    public float dir = -1;
    public TouchField TouchField;
    protected Vector3 LookDirection;
    void Start()
    {
        origRot = cam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }


    void FixedUpdate()
    {
        Touch touch = Input.touches[0];

        if (touch.position.x > Screen.width / 2) {

            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            } else if (touch.phase == TouchPhase.Moved)
            {
                rotX = rotX + TouchField.TouchDist.x * rotspeed * Time.deltaTime;
                rotY = Mathf.Clamp(rotY - TouchField.TouchDist.y * rotspeed * Time.deltaTime, -1, 1);
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;
                rotX -= deltaY * Time.deltaTime * rotspeed * dir;
                rotY += deltaX * Time.deltaTime * rotspeed * dir;



            } else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();

            }

        } 

    }
}
