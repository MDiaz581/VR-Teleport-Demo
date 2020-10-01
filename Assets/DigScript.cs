using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigScript : MonoBehaviour
{

    public GameObject dirt;

    public RoomChecker RoomChecker;

    public Text winText;

    public int digsLeft = 10;

    public GameObject canvasObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Spoon" && !RoomChecker.bedIsDown)
        {
            dirt.transform.position = dirt.transform.position - new Vector3(0f, 0.1f, 0f);
            digsLeft -= 1;
            if(digsLeft <= 0)
            {
                Debug.Log("You Win");
                canvasObject.SetActive(true);
                winText.text = "You win! you can escape through the hole";
            }
            other.GetComponent<SpoonHealth>().health -= 1;
        }
    }
}
