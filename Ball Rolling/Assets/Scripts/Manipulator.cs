using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    public bool transformObject;
    public bool rotateObject;
    public bool scaleObject;
    public bool reset;

    public float speed = 3;
    public float xAxis;
    public float yAxis;
    public float zAxis;

    private Vector3 _rPosition;
    private Quaternion _rRotation;
    private Vector3 _rScale;

    private Vector3 _movement;

    // Start is called before the first frame update
    void Start()
    {
        _rPosition = transform.position;
        _rRotation = transform.rotation;
        _rScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        _movement = new Vector3(xAxis, yAxis, zAxis);

        if (transformObject)
        {
            rotateObject = false;
            scaleObject = false;
            reset = false;
            transform.Translate(_movement * speed * Time.deltaTime);
        }

        if (rotateObject)
        {
            transformObject = false;
            scaleObject = false;
            reset = false;
            transform.Rotate(_movement * speed * Time.deltaTime);
        }

        if (scaleObject)
        {
            rotateObject = false;
            transformObject = false;
            reset = false;
            transform.localScale = _movement + _rScale;
        }

        if (reset)
        {
            rotateObject = false;
            scaleObject = false;
            transformObject = false;
            transform.position = _rPosition;
            transform.rotation = _rRotation;
            transform.localScale = _rScale;
        }
    }
}
