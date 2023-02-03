using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject DialogueBox;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")){
            Debug.Log("Test Collision");
            DialogueBox.SetActive(true);
            trigger.StartDialogue();
        }
    }
}