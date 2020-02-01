using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private Transform XFormCamera;
    private Transform XFormParent;

    private Vector3 LocalRotation;
    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private float CameraDistance = 10F;

    public float MouseSensitivity = 0.5F;
    public float ScrollSensitivity = 2F;
    public float OrbitDampening = 10F;
    public float ScrollDampening = 6F;

    public bool CameraDisabled = false;
    private bool isRotating;

    void Start()
    {
        this.XFormCamera = this.transform;
        this.XFormParent = this.transform.parent;
    }


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            CameraDisabled = !CameraDisabled;

        if (!CameraDisabled)
        {

            if (isRotating)
            {
                mouseOffset = (Input.mousePosition - mouseReference);

                LocalRotation.x += mouseOffset.x * MouseSensitivity;
                LocalRotation.y -= mouseOffset.y * MouseSensitivity;

            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0F)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;

                ScrollAmount *= (this.CameraDistance * 0.3f);

                this.CameraDistance += ScrollAmount * -1f;

                this.CameraDistance = Mathf.Clamp(this.CameraDistance, 1.5f, 100f);
            }

        }


        Quaternion QT = Quaternion.Euler(LocalRotation.y, LocalRotation.x, 0);
        this.XFormParent.rotation = Quaternion.Lerp(this.XFormParent.rotation, QT, Time.deltaTime * OrbitDampening);

        if (this.XFormCamera.localPosition.z != this.CameraDistance * -1f)
        {
            this.XFormCamera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this.XFormCamera.localPosition.z, this.CameraDistance * -1f, Time.deltaTime * ScrollDampening));

        }

        if (Input.GetMouseButton(0))
        {
            isRotating = true;

            mouseReference = Input.mousePosition;
        }
        else
        {
            isRotating = false;
        }
    }
}
