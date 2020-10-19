using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonHealth : MonoBehaviour
{
    public int health;

    private AudioSource AS;

    public AudioClip spoonBreakSFX;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            AS.PlayOneShot(spoonBreakSFX);

            Destroy(gameObject);
        }
    }
}
