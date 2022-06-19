using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidBody;

    private float _horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _rigidBody.velocity = new Vector2(_horizontalInput, _rigidBody.velocity.y) * _speed * Time.deltaTime;
    }
}
