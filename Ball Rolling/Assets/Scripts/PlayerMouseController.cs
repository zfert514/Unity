using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{
    public static PlayerMouseController instance;

    private float _mousePitch;
    private float _mouseYaw;
    private float _verticalLook;
    private float _horizontalLook;

    private Transform _playerTransform;//yaw - horizontal
    private Transform _cameraTransform;//pitch - vertical

    [Range(1,100)]
    public float mouseSensitivity;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = GameObject.FindGameObjectWithTag("CameraRotator").transform;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePitch = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        _mouseYaw = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        MouseLook();
    }

    private void MouseLook()
    {
        _horizontalLook += _mouseYaw;
        _verticalLook += _mousePitch;

        _verticalLook = Mathf.Clamp(_verticalLook, GameConstants.PLAYER_VERTICAL_LOOK_LOWER_BOUND, GameConstants.PLAYER_VERTICAL_LOOK_UPPER_BOUND);

        _cameraTransform.localRotation = Quaternion.Euler(new Vector3(-_verticalLook, 0, 0));
        _cameraTransform.localRotation = Quaternion.Euler(new Vector3(0, _horizontalLook, 0));
        _playerTransform.localRotation = Quaternion.Euler(new Vector3(0, _horizontalLook, 0));
    }

    public bool IsLeftMouseButtonClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
