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

    public bool hasApple;

    public GameObject canvasObject;

    public Text loseText;

    private bool isChecking;

    public AudioClip knockSound;

    public AudioClip footstepsSound;

    public AudioClip hatchSlidingSound;

    public AudioSource AS;

    public float textTimer;

    private DialogueManager dialogueManager;

    private bool startTextTimer;

    private bool spottedVent;

    private SpeechManager speechManager;

    public int ventConvoInt;

    public GameObject button;

    public GameObject dialogueBox;

    public bool gameStart;

    private float gameStartCountdown;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = initialTimer;
        textTimer = 0f;

        dialogueManager = FindObjectOfType<DialogueManager>();
        speechManager = FindObjectOfType<SpeechManager>();

        dialogueManager.StartDialogue(0);
        button.SetActive(false);
        startTextTimer = false;
        spottedVent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (speechManager.canSeeOrigin && !spottedVent)
        {
            dialogueManager.StartDialogue(1);
            startTextTimer = true;
            spottedVent = true;
        }

        if (startTextTimer)
        {
            textTimer += Time.deltaTime;            
            if (textTimer >= 5)
            {               
                textTimer = 0;
                Debug.Log("Resetting Timer");
                dialogueManager.StartDialogue(ventConvoInt);
                ventConvoInt += 1;
            }
            if(ventConvoInt == 13)
            {
                startTextTimer = false;
                button.SetActive(true);
            }

        }

        if (gameStart)
        {
            gameStartCountdown += Time.deltaTime;

            if(gameStartCountdown >= 4)
            {
                dialogueBox.SetActive(false);
            }
        


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
                    if (!hasApple)
                    {
                        Instantiate(apple, appleSpawnPos.position, appleSpawnPos.rotation);
                        hasApple = true;
                    }
                    
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

    public void StartGame()
    {
        gameStart = true;
        dialogueManager.StartDialogue(14);
    }
}
