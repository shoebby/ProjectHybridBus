using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class continuousMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpHeight = 10f;
    public float gravity = -9.81f;
    public float additionalHeight = 0.2f;
    public LayerMask groundLayer;

    public XRNode inputSource;
    public XRNode jumpInputSource;

    private float fallingSpeed;

    private XRRig rig;
    private Vector2 inputAxis;
    private bool jumpPressed;
    private CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        InputDevice offhandDevice = InputDevices.GetDeviceAtXRNode(jumpInputSource);

        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        offhandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out jumpPressed);
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();

        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * speed * Time.deltaTime);

        bool isGrounded = GroundCheck();
        if (isGrounded)
        {
            fallingSpeed = 0f;
        }
        else
        {
            fallingSpeed += gravity * Time.deltaTime;
            character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
        }

        if (isGrounded && jumpPressed)
        {
            Jump();
        }
    }

    void CapsuleFollowHeadset()
    {
        character.height = rig.cameraInRigSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }

    bool GroundCheck()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }

    void Jump()
    {
        character.Move(Vector3.up);
    }
}
