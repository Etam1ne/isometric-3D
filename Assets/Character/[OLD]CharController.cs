using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Camera _camera;

    private Transform _character;
    private Rigidbody _rb;
    private Animator _animator;

    private Vector3 _direction;
    private Vector3 _inputs = Vector3.zero;

    public float _speed = 5f;


    // getters and setters

    public Transform Character { get { return _character; } }
    public Rigidbody Rrb { get { return _rb; } }
    public Animator Animator { get { return _animator; } }

    public Vector3 Direction { get { return _direction; } }
    public Vector3 Inputs { get { return _inputs; } }
    public float Speed { get { return _speed; } set { _speed = value; } }

    private void Awake()
    {
        _character = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _inputs = Vector3.zero;
        _inputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _inputs.Normalize();
        _inputs = IsoVectorConvert(_inputs);
    }

    private void FixedUpdate()
    {

        _rb.velocity = new Vector3(_inputs.x * _speed, _rb.velocity.y, _inputs.z * _speed);
        MovementAnimation();

        Ray _cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
        Plane _groundPlane = new(Vector3.up, new Vector3(0, _character.position.y ,0));

        if (_groundPlane.Raycast(_cameraRay, out float rayLength))
        {
            Vector3 pointToLook = _cameraRay.GetPoint(rayLength);
            _character.LookAt(new Vector3(pointToLook.x, _character.position.y, pointToLook.z));
        }
    }

    private Vector3 IsoVectorConvert(Vector3 vector)
    {
        Quaternion rotation = Quaternion.Euler(0, 45f, 0);
        Matrix4x4 isoMatrix = Matrix4x4.Rotate(rotation);
        Vector3 result = isoMatrix.MultiplyPoint3x4(vector);
        return result;
    }

    private void MovementAnimation()
    {
        _direction = _character.InverseTransformDirection(_rb.velocity);

        if (_inputs != Vector3.zero)
        {
            if (0 <= _direction.z & _direction.z <= 5)
            {
                _speed = 5f;
                _animator.SetInteger("Direction", 1);
            }
            else if (-5 < _direction.z & _direction.z < 0)
            {
                _speed = 3.5f;
                _animator.SetInteger("Direction", -1);
            }
        }

        else
        {
            _animator.SetInteger("Direction", 0);
        }
    }
}
