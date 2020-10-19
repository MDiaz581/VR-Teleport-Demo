using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;

    public Dialogue dialogue;

    private string sentence;

    // Start is called before the first frame update
    void Start()
    {

       
    }


    public void StartDialogue(int sentenceNumber)
    {
        dialogueText.text = dialogue.sentences[sentenceNumber];
        sentence = dialogue.sentences[sentenceNumber];
        //StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));

    }
/*
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {

            dialogueText.text += letter;

            yield return null;

        }
    }
*/
}
