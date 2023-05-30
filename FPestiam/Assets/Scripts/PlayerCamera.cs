using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform body;
    public float sensitivity = 500f;
    float xClamp = 0f;

    public GameObject weapon1;
    public GameObject weapon2;
    private GameObject activeWeapon;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SetActiveWeapon(weapon1);
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        body.Rotate(Vector3.up * mouseX);
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xClamp -= mouseY;
        xClamp = Mathf.Clamp(xClamp, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xClamp, 0f, 0f);

        // Changer d'arme avec les touches "1" et "2"
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveWeapon(weapon1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveWeapon(weapon2);
        }
    }

    private void SetActiveWeapon(GameObject weapon)
    {
        if (activeWeapon != null)
        {
            activeWeapon.SetActive(false);
        }

        activeWeapon = weapon;
        activeWeapon.SetActive(true);
    }
}
