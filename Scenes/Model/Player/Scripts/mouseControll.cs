using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseControll : MonoBehaviour
{
    public float sens = 2.0f;
    public float maxYAngle = 80.0f;

    private float rotationX = 0.0f;

    public Transform t_Camera;
    private RaycastHit hit;
    private Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = t_Camera.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //горизонтальна€ плоскость

        transform.parent.Rotate(Vector3.up * mouseX * sens);

        //¬ертикалка

        rotationX -= mouseY * sens;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);

        //Physics.Linecast(transform.position, t_Camera.position, out hit);
        if(Physics.Linecast(transform.position, t_Camera.position, out hit))
        {
            t_Camera.localPosition = new Vector3(0, 0, Vector3.Distance(transform.position, hit.point));
        }
        else
        {
            t_Camera.localPosition = cameraOffset;
        }
    }
}

