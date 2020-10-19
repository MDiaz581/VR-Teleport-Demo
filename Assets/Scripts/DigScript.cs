using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigScript : MonoBehaviour
{

    public GameObject dirt;

    public RoomChecker RoomChecker;

    public Text winText;

    public int digsLeft = 15;

    public GameObject canvasObject;

    private AudioSource AS;

    public AudioClip digSFX;
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }
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
            dirt.transform.position = dirt.transform.position - new Vector3(0f, 0.075f, 0f);
            digsLeft -= 1;
            AS.PlayOneShot(digSFX);
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
