using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Camera camera;
    private Touch initTouch = new Touch();
    private float rotX =0f;
    private float rotY=0f;
    private Vector3 origRot;
    public float rotSpeed = 0.5f;
    public float dir = -1;
    // Start is called before the first frame update
    void Start()
    {
        origRot = camera.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase ==TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                //swiping
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;
                rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                rotY += deltaX * Time.deltaTime * rotSpeed * dir;
                rotY = Mathf.Clamp(rotY, -45f, 45f);
                rotY =  Mathf.Clamp(rotY, -45f, 45f);
                camera.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
}
