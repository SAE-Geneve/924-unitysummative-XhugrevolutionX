using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Vector2 _inputMove;
    private CharacterController _controller;
    private Camera _mainCamera;

    
    private float _angleVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputMove.magnitude >= Mathf.Epsilon)
        {
            RotatePlayerWithCamera();
            GetDirectionAndMove();
        }
    }
    
    private void RotatePlayerWithCamera()
    {
        //Player facing away from camera
        float targetAngle = _mainCamera.transform.rotation.eulerAngles.y;
        targetAngle += Mathf.Atan2(_inputMove.x, _inputMove.y) * Mathf.Rad2Deg;

        float actualAngle = Mathf.SmoothDampAngle(_controller.transform.eulerAngles.y, targetAngle, ref _angleVelocity, 0.25f);

        _controller.transform.rotation = Quaternion.Euler(0, actualAngle, 0);
    }
    
    private void GetDirectionAndMove()
    {
        Vector3 cameraForward = _mainCamera.transform.forward;
        Vector3 cameraRight = _mainCamera.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 direction = cameraForward * _inputMove.y + cameraRight * _inputMove.x;
        _controller.Move(direction * (speed * Time.deltaTime));
    }
    
    public void InputMove(InputAction.CallbackContext context)
    {
        _inputMove = context.ReadValue<Vector2>();
    }
}
