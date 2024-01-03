using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Clean_Enemy : MonoBehaviour
{
    [SerializeField] private new AudioSource audio;
    [SerializeField] private Sprite Trigger;
    [SerializeField] private Sprite NotTrigger;
    [SerializeField] private float Health = 3f;

    private SpriteRenderer spriteRenderer;
    // Reference to the SpriteRenderer component
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            // If there is no SpriteRenderer, add one
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
    }
    private bool Target_Changed = false;
    private void Change_Target_Num()
    {
        L_Clean_Stage_Control stageControl = GameObject.FindObjectOfType<L_Clean_Stage_Control>();

        if (stageControl != null)
        {
            stageControl.Targets -= 1;

        }
        else
        {
            Debug.LogWarning("L_Clean_Stage_Control not found in scene!");
        }
    }

    private void Update()
    {
        if (Health <= 0f)
        {
            if (Target_Changed == false)
            {
                Change_Target_Num();
                Target_Changed = true;
            }
            audio.Play();
            Destroy(gameObject,0.5f);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Trigger != null)
            {
                spriteRenderer.sprite = Trigger;
                Health -= 1f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = NotTrigger;
        }
    }
}
