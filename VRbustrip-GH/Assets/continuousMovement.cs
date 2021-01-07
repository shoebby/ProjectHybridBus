using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class continuousMovement : MonoBehaviour
{
    public float speed = 1f;
    public float gravity = -9.81f;
    public float additionalHeight = 0.2f;
    public LayerMask groundLayer;

    public XRNode inputSource;

    private float fallingSpeed;

    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        capsuleFollowHeadset();

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
    }

    void capsuleFollowHeadset()
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
}
