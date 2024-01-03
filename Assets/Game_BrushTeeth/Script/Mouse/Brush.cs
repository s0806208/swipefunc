using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] private GameObject Bubble;
    [SerializeField] private Sprite Trigger;
    [SerializeField] private Sprite NotTrigger;

    private SpriteRenderer spriteRenderer; 
    // Reference to the SpriteRenderer component
    void Start()
    {
        // this sets the base cursor as invisible
        Cursor.visible = false;
        // Get the SpriteRenderer component attached to the same GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            // If there is no SpriteRenderer, add one
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tooth"))
        {

            if (Trigger != null)
            {
                spriteRenderer.sprite = Trigger;
            Bubble.SetActive(true);
            }
        }
        if (other.CompareTag("Effect_Collide"))
        {

            if (Trigger != null)
            {
                spriteRenderer.sprite = Trigger;
            Bubble.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter (Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Effect_Collide"))
        {
            spriteRenderer.sprite = NotTrigger;
            Bubble.SetActive(false);
        }
    }
}
