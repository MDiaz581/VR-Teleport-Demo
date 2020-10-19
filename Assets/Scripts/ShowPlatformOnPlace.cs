using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShowPlatformOnPlace : MonoBehaviour
{
    public GameObject planeToActivate;
    public string whichTag;
    XRSocketInteractor socket;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();

        socket.onSelectEnter.AddListener(OnSocketEnter);
        socket.onSelectExit.AddListener(OnSocketExit);

    }

    void OnSocketEnter(XRBaseInteractable socketObject)
    {
        if (socketObject.gameObject.CompareTag(whichTag))
        {
            Debug.Log("OBJECT IS PLACED.");
            planeToActivate.SetActive(true);
        }

    }

    void OnSocketExit(XRBaseInteractable socketObject)
    {
        planeToActivate.SetActive(false);
    }
}
