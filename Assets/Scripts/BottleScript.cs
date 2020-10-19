using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BottleScript : MonoBehaviour
{
    public Material wineMat;

    public Material waterMat;

    public GameObject ToiletWater;

    public GameObject spoonPrefab;

    public Transform spoonSpawn;

    public RoomChecker RoomChecker;

    private XRSimpleInteractable grabInteractable;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRSimpleInteractable>();

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            transform.position = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if(other.gameObject.tag == "Toilet Water" && RoomChecker.madeWine)
        {
            Debug.Log("triggered2");
            this.gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = wineMat;
            ToiletWater.GetComponent<MeshRenderer>().material = waterMat;
            RoomChecker.madeWine = false;
            RoomChecker.holdingWine = true;
        }

        if (other.gameObject.tag == "Vent" && RoomChecker.holdingWine)
        {
            Debug.Log("put in Vent");
            Instantiate(spoonPrefab, spoonSpawn.position, spoonSpawn.rotation);
            this.gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = waterMat;
            RoomChecker.holdingWine = false;
        }
    }
}
