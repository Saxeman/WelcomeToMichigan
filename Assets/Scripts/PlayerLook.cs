using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouse_sensitivity = 100f;

    public Transform player_body;

    float x_rotation = 0f;

    bool camera_move = false;

    float mouse_x;
    float mouse_y;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: Remove comment before final build
        //Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (camera_move == false)
        {
            mouse_x = 0;
            mouse_y = 0;

        }
        else {
            mouse_x = Input.GetAxis("Mouse X") * mouse_sensitivity;
            mouse_y = Input.GetAxis("Mouse Y") * mouse_sensitivity;
        }


        x_rotation -= mouse_y;
        //Debug.Log(x_rotation);
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

        //rotates camera based on rotation of parent
        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
        player_body.Rotate(Vector3.up * mouse_x);
    }

    private IEnumerator wait() {
        yield return new WaitForSeconds(0.1f);
        camera_move = true;
    }
}
