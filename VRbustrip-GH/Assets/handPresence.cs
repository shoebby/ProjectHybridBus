using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class handPresence : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice targetDevice;

    public List<GameObject> controllerPrefabs;
    private GameObject controllerSpawned;

    public GameObject handModelPrefab;
    private GameObject handModelSpawned;
    private Animator handAnimator;

    void Start()
    {
        TryInitialize();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                controllerSpawned = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                controllerSpawned = Instantiate(controllerPrefabs[0], transform);
            }

            handModelSpawned = Instantiate(handModelPrefab, transform);
            handAnimator = handModelSpawned.GetComponent<Animator>();
        }
    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0f);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0f);
        }
    }

    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            if (showController)
            {
                handModelSpawned.SetActive(false);
                controllerSpawned.SetActive(true);
            }
            else
            {
                handModelSpawned.SetActive(true);
                controllerSpawned.SetActive(false);
                UpdateHandAnimation();
            }
        }

        //primary button input
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue) //if the primary button is pressed
        {
            Debug.Log("pressed primary button");
        }

        //secondary button input
        if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) && secondaryButtonValue) //if the secondary button is pressed
        {
            Debug.Log("pressed secondary button");
        }

        //trigger input
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f) //if the trigger is pushed in over a certain threshold
        {
            Debug.Log("trigger" + triggerValue);
        }

        //joystick input
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero) //if the joysddtick is not idle
        {
            Debug.Log("joystick" + primary2DAxisValue);
        }
    }
}
