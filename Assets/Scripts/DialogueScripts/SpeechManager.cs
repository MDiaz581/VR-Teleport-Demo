using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeechManager : MonoBehaviour
{
    public GameObject canvasParent;

    public GameObject MainCamera;

    private Camera cam;

    public Transform CanvasPos;

    public Transform cameraPos;

    public Transform speechOriginPos;

    public bool canSeeOrigin;



    // Start is called before the first frame update
    void Start()
    {
        cam = MainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(speechOriginPos.position);
        CanvasPos.LookAt(MainCamera.transform, Vector3.up);
        

        if (viewPos.y < 1f && viewPos.y > 0f && viewPos.x < 1f && viewPos.x > 0f && viewPos.z > 0f)
        {
            
            canvasParent.transform.position = Vector3.Lerp(canvasParent.transform.position, speechOriginPos.position, 0.1f);
            canSeeOrigin = true;

        } else
        {
            canvasParent.transform.position = Vector3.Lerp(canvasParent.transform.position, cameraPos.position, 0.1f);
            canSeeOrigin = false;
        }

    }
}
