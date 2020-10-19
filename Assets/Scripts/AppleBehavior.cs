using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehavior : MonoBehaviour
{

    public GameObject appleWhole;
    public GameObject appleBite1;
    public GameObject appleBite2;
    public GameObject appleFinished;
    public int appleState;

    private AudioSource AS;
    public AudioClip crunchSFX;

    public bool canSwitch;
    public float timer;

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
        if (!canSwitch)
        {
            
            timer += Time.deltaTime;
            if(timer > 0.5f)
            {               
                Debug.Log("can switch");
                canSwitch = true;
                timer = 0;
                appleState += 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Head")
        {
            

            Debug.Log("Triggered with Head");
            if(appleState == 0)
            {
                appleWhole.SetActive(false);
                appleBite1.SetActive(true);
                canSwitch = false;
                AS.PlayOneShot(crunchSFX);
            }
            if (appleState == 1 && canSwitch)
            {
                appleBite1.SetActive(false);
                appleBite2.SetActive(true);
                canSwitch = false;
                AS.PlayOneShot(crunchSFX);
            }
            if (appleState == 2 && canSwitch)
            {
                appleBite2.SetActive(false);
                appleFinished.SetActive(true);
                AS.PlayOneShot(crunchSFX);
                canSwitch = false;
            }
            if(appleState > 2)
            {

            }
        }
    }
}
