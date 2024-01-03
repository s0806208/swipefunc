using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Clean_Tooth : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float transitionDuration = 2f;

    private Color initialColor;
    private Color targetColor = new Color(1f, 1f, 1f, 1f); // White color

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeColorOverTime());
        }
    }
    private bool targetColorReached = false;
    private IEnumerator ChangeColorOverTime()
    {
        float elapsedTime = 0f;
        if (spriteRenderer.color != targetColor)
        {
            while (elapsedTime < transitionDuration)
            {
                spriteRenderer.color = Color.Lerp(initialColor, targetColor, elapsedTime / transitionDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        if (spriteRenderer.color == targetColor && !targetColorReached)
        {
            Change_Target_Num();
            targetColorReached = true; // Set flag to prevent further calls
        }
        spriteRenderer.color = targetColor;
    }
}
