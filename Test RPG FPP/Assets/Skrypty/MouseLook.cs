using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    InputMaster inputMaster;

    float camVerticalRotation = 0f;

    [SerializeField] float camSpeed;

    public Transform player;

    private void Awake()
    {
        inputMaster = new InputMaster();
    }

    private void OnEnable()
    {
        inputMaster.Player.Look.Enable();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        inputMaster.Player.Look.Disable();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = inputMaster.Player.Look.ReadValue<Vector2>().x * camSpeed * Time.deltaTime;
        float mouseY = inputMaster.Player.Look.ReadValue<Vector2>().y * camSpeed * Time.deltaTime;

        camVerticalRotation -= mouseY;
        camVerticalRotation = Mathf.Clamp(camVerticalRotation, -60f, 60f);
        transform.localEulerAngles = Vector3.right * camVerticalRotation;

        player.Rotate(Vector3.up, mouseX);
    }
}
