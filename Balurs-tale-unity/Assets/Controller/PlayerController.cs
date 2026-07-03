using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    CharacterController characterController;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction lookAction;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        lookAction = InputSystem.actions.FindAction("Look");
    }

    [SerializeField] Transform cameraTransform;

    
    [Header("Player Look Settings (global)")]
    [SerializeField] float lookSpeed = 0.1f;
    public static float globalLookSpeedModifier = 1f;
    public static bool enableMouseSmoothing = true;
    [SerializeField] float lookSmoothing = 0.005f;
    public static float globalLookSmoothingModifier = 1f;

    [Header("Player Movement Settings (GD only)")]
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float movementSmooth = 0.05f;
    [Header("In air movement")]
    [SerializeField] float airControl = 0.2f;
    [SerializeField] float gravityValue = -30f;
    [Header("Jump settings")]
    [SerializeField] float jumpHeight = 1.2f;
    [SerializeField] float jumpDelay = 0.2f;


    void Update()
    {
        if (jumpAction.WasPressedThisFrame()) StartCoroutine(JumpInputCorutine());
        Looking();
        Moving();
    }
    
    bool isWanna2Jump = false;
    IEnumerator JumpInputCorutine()
    {
        isWanna2Jump = true;
        yield return new WaitForSeconds(jumpDelay);
        isWanna2Jump = false;
    }


    void Looking()
    {
        
    }

    void Moving()
    {
        
    }
}
