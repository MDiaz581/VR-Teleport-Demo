using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VentScript : MonoBehaviour
{

    XRSocketInteractor socket;

    public RoomChecker RoomChecker;


    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();

        socket.onSelectEnter.AddListener(OnSocketEnter);
        socket.onSelectExit.AddListener(OnSocketExit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSocketEnter(XRBaseInteractable socketObject)
    {
        if (socketObject.gameObject.CompareTag("Grate"))
        {

            RoomChecker.grateInPlace = true;


        }

    }
    void OnSocketExit(XRBaseInteractable socketObject)
    {
        RoomChecker.grateInPlace = false;
    }
}
