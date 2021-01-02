﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class CameraRot : MonoBehaviour
{
    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    public bool clampVerticalRotation = true;
    public float MinimumX = -90F;
    public float MaximumX = 90F;
    public bool smooth;
    public float smoothTime = 5f;

    public static float rotSpeed = 0.3f;


    private Quaternion m_CharacterTargetRot;
    private Quaternion m_CameraTargetRot;
    public Transform character;
    public Transform Camera;


    void Start()
    {
       
        
       
    }
    private void FixedUpdate()
    {
        Init(character, Camera);
        LookRotation(character,Camera);
    }
    public void Init(Transform character, Transform camera)
    {
        m_CharacterTargetRot = character.localRotation;
        m_CameraTargetRot = camera.localRotation;
    }

    public void LookRotation(Transform character, Transform camera)
    {
        float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
        float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

        m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

        if (clampVerticalRotation)
            m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

        if (smooth)
        {
            character.localRotation = Quaternion.Slerp(character.localRotation, m_CharacterTargetRot,
                smoothTime * Time.deltaTime);
            camera.localRotation = Quaternion.Slerp(camera.localRotation, m_CameraTargetRot,
                smoothTime * Time.deltaTime);
        }
        else
        {
            character.localRotation = m_CharacterTargetRot;
            camera.localRotation = m_CameraTargetRot;
        }


    }
    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

    public void SwipeLeft()
    {
        if (gameObject.transform.position.x >= -4)
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * 200, Space.World);
        }
        
    }
    public void SwipeRight()
    {
        if (gameObject.transform.position.x <= 3)
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * 200, Space.World);
        }

    }

}

