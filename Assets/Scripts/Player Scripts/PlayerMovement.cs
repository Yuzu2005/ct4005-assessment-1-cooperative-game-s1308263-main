using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float playerSpeed = 5, gravityValue = -9.81f, controllerDeadzone = 0.1f, gamepadRotateSmoothing = 1000f;

    [Space(10)]
    [SerializeField] private float dodgeCooldown = 3, dodgeDuration = 1f, dodgeSpeed = 200f;

    [Space(10)]
    [SerializeField] private GameObject healthTextObject;
    public GameObject playerModel;

    [SerializeField] private Transform spawnCenter;

    private bool canDodge = true;
    public bool isDodging;
    public bool isMoving;

    private Vector2 movement;
    private Vector2 aim;

    private Vector3 playerVelocity;

    private CharacterController controller;
    private PlayerControls playerControls;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        controller.enabled = false;
        //respawn loaction 1
        if (FindObjectOfType<MultipleTargetCamera>().targets.Count == 1) {
            Vector3 Spawn1 = spawnCenter.GetChild(0).transform.position;
            transform.position = Spawn1;
        }
        //respawn location 2
        else if (FindObjectOfType<MultipleTargetCamera>().targets.Count == 2) {
            Vector3 Spawn2 = spawnCenter.GetChild(1).transform.position;
            transform.position = Spawn2;
        }
        //respawn location 3
        else if (FindObjectOfType<MultipleTargetCamera>().targets.Count == 3) {
            Vector3 Spawn3 = spawnCenter.GetChild(2).transform.position;
            transform.position = Spawn3;
        }
        //respawn location 4
        else if (FindObjectOfType<MultipleTargetCamera>().targets.Count == 4) {
            Vector3 Spawn4 = spawnCenter.GetChild(3).transform.position;
            transform.position = Spawn4;
        }
        controller.enabled = true;
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        FindObjectOfType<MultipleTargetCamera>().AddPlayer(transform);
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    private void Update() {
        HandleMovement();
        HandleRotation();
    }

    //Input references for movement and rotation
    public void MovementInput(InputAction.CallbackContext contextMove) => movement = contextMove.ReadValue<Vector2>();
    public void RotationInput(InputAction.CallbackContext contextAim) => aim = contextAim.ReadValue<Vector2>();

    //Handles player movement
    private void HandleMovement() {
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        TryGetComponent<Shoot>(out Shoot isGren);
        if (Mathf.Abs(move.x) > 0 && isDodging == false) {
            isMoving = true;
            if (isMoving == true && isDodging == false && isGren.isGrenade == false) {
                playerModel.GetComponent<PlayerAnimations>().ForwardRun();
            }
        }
        else if (Mathf.Abs(move.x) < 0 && isDodging == false) {
            isMoving = true;
            if (isMoving == true && isDodging == false && isGren.isGrenade == false) {
                playerModel.GetComponent<PlayerAnimations>().BackwardRun();
            }
        }
        else {
            isMoving = false;
            if (isMoving == false && isDodging == false && isGren.isGrenade == false) {
                playerModel.GetComponent<PlayerAnimations>().Idle();
            }
        }
    }

    //Handles player rotation
    private void HandleRotation() {
        if (Mathf.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone) {
            Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
            if (playerDirection.sqrMagnitude > 0.0f) {
                Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, gamepadRotateSmoothing * Time.deltaTime);
            }
            healthTextObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
        }
    }

    //dodge input
    public void DodgeInput(InputAction.CallbackContext dodge) {
        if (dodge.performed) {
            TryGetComponent<PlayerHealthScript>(out PlayerHealthScript healthComp);
            TryGetComponent<Shoot>(out Shoot shootComp);
            if (dodge.performed) {
                if (healthComp.isAlive == true) {
                    if (canDodge == true) {
                        if (isDodging == false) {
                            isDodging = true;
                            canDodge = false;
                            shootComp.StopCoroutine("AutoFire");
                            StartCoroutine("Dodge");
                        }
                    }
                }
            }
        }
    }

    //dodge function
    private IEnumerator Dodge() {
        float startTime = Time.time;
        while (Time.time < startTime + dodgeDuration) {
            aim = movement;
            Vector3 dodge = new Vector3(movement.x, 0, movement.y);
            controller.Move(dodge * dodgeSpeed * Time.deltaTime);
            playerModel.GetComponent<PlayerAnimations>().Dodge();
            yield return null;
        }
        yield return new WaitForSeconds(dodgeCooldown);
        isDodging = false;
        canDodge = true;
        isMoving = false;
    }
}

//Script by Jacob