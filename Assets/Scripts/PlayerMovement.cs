using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _playerRigidbody;
    [SerializeField] private float _movementSpeed = 6f;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float horyzontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

        _playerRigidbody.velocity = new Vector3(horyzontalInput * _movementSpeed, _playerRigidbody.velocity.y, verticalInput * _movementSpeed);

    }

    private void Jump()
    {
        _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, _jumpForce, _playerRigidbody.velocity.z);
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(_groundChecker.position, .1f, _groundLayer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
}
