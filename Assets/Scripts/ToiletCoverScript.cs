using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToiletCoverScript : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    public GameObject toiletDown;
    public GameObject toiletUp;
    public RoomChecker RoomChecker;


    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.onSelectEnter.AddListener(ActivateButton);
    }

    // Update is called once per frame
    void Update()
    {



    }

    void ActivateButton(XRBaseInteractor interactor)
    {

        if (RoomChecker.toiletIsDown)
        {
            Debug.Log("Do its");
            toiletDown.SetActive(false);
            toiletUp.SetActive(true);
            RoomChecker.toiletIsDown = false;
        }
        else
        {
            toiletDown.SetActive(true);
            toiletUp.SetActive(false);
            RoomChecker.toiletIsDown = true;
        }


    }
}
