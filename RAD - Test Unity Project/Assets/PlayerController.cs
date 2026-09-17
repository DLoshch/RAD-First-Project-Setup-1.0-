using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputs playerInputs;
    public CharacterController characterController;
    public GameObject playerCamera;
    public float moveSpeed = 5f;

    [SerializeField]
    private Vector2 moveInput;
    [SerializeField]
    private Vector2 lookInput;

    void Start()
    {
        playerInputs = new PlayerInputs();
        playerInputs.Enable();
        playerInputs.Player.Enable();

        playerInputs.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInputs.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        playerInputs.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInputs.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayerCamera();
    }

    public void MovePlayer()
    {
        float gravity = -9.81f;
        Vector3 moveDirection = transform.forward;
        Vector3 move = new Vector3(moveInput.x * Time.deltaTime * moveSpeed, gravity * Time.deltaTime * moveSpeed, moveInput.y * Time.deltaTime * moveSpeed);
        Vector3 finalMove = move;
        Debug.Log($"Move Direction: {moveDirection}, Final Move: {finalMove}");
        characterController.Move(finalMove);
    }

    public void RotatePlayerCamera()
    {

    }
}
