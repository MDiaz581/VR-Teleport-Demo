using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterSocket : MonoBehaviour
{
    XRSocketInteractor socket;

    public RoomChecker RoomChecker;

    public float timer;

    public GameObject ToiletWater;

    public Material waterMat;

    public Material wineMat;

    private GameObject apple;

    // Start is called before the first frame update
    void Start()
    {
        /*
        socket = GetComponent<XRSocketInteractor>();

        socket.onSelectEnter.AddListener(OnSocketEnter);
        socket.onSelectExit.AddListener(OnSocketExit);
        */
    }

    void Update()
    {
        if (RoomChecker.fermentingToiletWine)
        {
            apple.transform.position = transform.position;
            if (!RoomChecker.toiletIsDown)
            {
                timer += Time.deltaTime;
            } else
            {

            }
            
            if (timer >= 15f)
            {
                Debug.Log("Finished Ferment");
                ToiletWater.GetComponent<MeshRenderer>().material = wineMat;
                RoomChecker.madeWine = true;
                RoomChecker.fermentingToiletWine = false;
                timer = 0f;
                if(apple != null)
                {
                    RoomChecker.hasApple = false;
                    //apple.SetActive(false);
                    Destroy(apple);
                }
                
            }
        }
    }
/*
    void OnSocketEnter(XRBaseInteractable socketObject)
    {
        if (socketObject.gameObject.CompareTag("Red"))
        {
            Debug.Log("OBJECT IS PLACED.");
            apple = socketObject.gameObject;
            RoomChecker.fermentingToiletWine = true;


        }

    }
    void OnSocketExit(XRBaseInteractable socketObject)
    {
        Debug.Log("Removed Apple");
        timer = 0f;
        RoomChecker.fermentingToiletWine = false;
    }
*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Red"))
        {
            
            Debug.Log("OBJECT IS PLACED.");
            apple = other.gameObject;
            RoomChecker.fermentingToiletWine = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Removed Apple");
        timer = 0f;
        RoomChecker.fermentingToiletWine = false;
    }

}
