using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController Player;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jump_height = 3f;

    public Transform ground_check;
    public float ground_distance = 0.4f;
    public LayerMask ground_mask;


    Vector3 velocity;
    bool is_grounded;

    private void Start()
    {
        Player = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        is_grounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask);

        if (is_grounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x_move = Input.GetAxis("Horizontal");
        float z_move = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x_move + transform.forward * z_move;

        Player.Move(move * speed);

        if (Input.GetButtonDown("Jump") && is_grounded) {
            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        Player.Move(velocity * Time.deltaTime);
    }
}
