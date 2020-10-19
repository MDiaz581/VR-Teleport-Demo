using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bedscript : MonoBehaviour
{
    private XRSimpleInteractable grabInteractable;
    public GameObject bedLow;
    public GameObject bedUp;
    public RoomChecker RoomChecker;


    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRSimpleInteractable>();
        grabInteractable.onSelectEnter.AddListener(Shoot);

    }

    // Update is called once per frame
    void Update()
    {



    }

    void Shoot(XRBaseInteractor interactor)
    {

        if (RoomChecker.bedIsDown)
        {
            bedLow.SetActive(false);
            bedUp.SetActive(true);
            RoomChecker.bedIsDown = false;
        } else
        {
            bedLow.SetActive(true);
            bedUp.SetActive(false);
            RoomChecker.bedIsDown = true;
        }


    }
}

