using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    InputMaster inputMaster;

    public CharacterController controller;
    public float speed = 12f;
    public float jumpHeight = 3f;

    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    [SerializeField] Keys keyManager;

    private void Awake()
    {
        inputMaster = new InputMaster();
        inputMaster.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable()
    {
        inputMaster.Player.Movement.Enable();
        inputMaster.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Player.Movement.Disable();
        inputMaster.Player.Jump.Disable();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = inputMaster.Player.Movement.ReadValue<Vector2>().x;
        float z = inputMaster.Player.Movement.ReadValue<Vector2>().y;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "klucz")
        {
            keyManager.GotKey(other.gameObject);
        }
        if(other.gameObject.tag == "zdrowie")
        {
            GetComponent<LifeCoinsMana>().AddLive();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "mana")
        {
            GetComponent<LifeCoinsMana>().AddMana();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "zloto")
        {
            GetComponent<LifeCoinsMana>().AddCoins();
            Destroy(other.gameObject);
        }

    }
}
