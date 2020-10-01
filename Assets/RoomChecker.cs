using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomChecker : MonoBehaviour
{
    public bool bedIsDown;

    public bool toiletIsDown;

    public bool fermentingToiletWine;

    public bool madeWine;

    public bool holdingWine;

    public bool grateInPlace;

    public float timer;

    private bool playKnock = true;

    private bool playfootsteps = true;

    public float initialTimer;

    public float checkTimer;

    public GameObject hatch;

    public Transform hatchInitialPos;

    public Transform movePosition;

    public Transform appleSpawnPos;

    public GameObject apple;

    public GameObject canvasObject;

    public Text loseText;

    private bool isChecking;

    public AudioClip knockSound;

    public AudioClip footstepsSound;

    public AudioClip hatchSlidingSound;

    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        timer = initialTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= Random.Range(5f,10f))
        {
            if(Random.Range(1f, 5f) > 3f)
            {
                playfootsteps = false;
            }
            if (playfootsteps)
            {
                AS.PlayOneShot(footstepsSound);
                playfootsteps = false;
            }

        }

        if (timer <= Random.Range(2f, 3f))
        {
            if (playKnock)
            {
                AS.PlayOneShot(knockSound);
                playKnock = false;
            }
            
        }

        if(timer <= 0)
        {


            if (!isChecking)
            {
                hatch.transform.position = movePosition.position;
                checkTimer = Random.Range(3f, 7f);
                Debug.Log("Checking for: " + checkTimer);
                
                AS.PlayOneShot(hatchSlidingSound);
                isChecking = true;
            } else
            {
                checkTimer -= Time.deltaTime;

                if (fermentingToiletWine && !toiletIsDown)
                {
                    canvasObject.SetActive(true);
                    loseText.text = "You lose! The guards caught you trying to make prison wine!";
                    Debug.Log("GameOver");
                }

                if (!bedIsDown)
                {
                    canvasObject.SetActive(true);
                    loseText.text = "You lose! The guards saw your escape tunnel!";
                    Debug.Log("GameOver");
                }
                if (madeWine && !toiletIsDown)
                {
                    canvasObject.SetActive(true);
                    loseText.text = "You lose! See all that prison wine you made!";
                    Debug.Log("GameOver");
                }
                if (!grateInPlace)
                {
                    canvasObject.SetActive(true);
                    loseText.text = "You lose! The guard saw you messing with the vents!";
                    Debug.Log("GameOver");
                }
                if (holdingWine)
                {
                    canvasObject.SetActive(true);
                    loseText.text = "You lose! The guard See all that prison wine you made!";
                    Debug.Log("GameOver");
                }

                if (checkTimer <= 0)
                {
                    Instantiate(apple, appleSpawnPos.position, appleSpawnPos.rotation);
                    Debug.Log("Finished Check");
                    timer = initialTimer;
                    AS.PlayOneShot(hatchSlidingSound);
                    AS.PlayOneShot(footstepsSound);
                    playKnock = true;
                    playfootsteps = true;
                    hatch.transform.position = hatchInitialPos.position;
                    isChecking = false;
                }
            }
            
        }
    }

}
