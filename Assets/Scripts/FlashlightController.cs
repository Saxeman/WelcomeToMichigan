using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    Light flashlight;
    bool flashlight_on = false;

    public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        flashlight = this.GetComponent<Light>();
        flashlight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(camera.rotation.x, transform.rotation.y, camera.rotation.z, transform.rotation.w);
        if (Input.GetKeyDown(KeyCode.F) && flashlight_on == false)
        {
            flashlight_on = true;
            flashlight.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && flashlight_on == true) {
            flashlight_on = false;
            flashlight.enabled = false;
        }
    }
}
