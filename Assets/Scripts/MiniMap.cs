using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Image borderMask;
    public RawImage borderImage;
    public Image border;
    public CapsuleCollider2D borderCollider;
    public float fadeDuration = 0.35f; 
    private bool isInitialized = false; // To track if the minimap has been initialized


    private bool IsGameSceneActive()
    {
        // Replace this with your actual logic to determine if the game is active.
        // For example, check if a specific GameObject exists or if you're in a specific scene.
        return GameObject.Find("MiniMap Mask") != null;
    }

    void Update()
    {
        // Check if the minimap needs initialization
        if (!isInitialized && IsGameSceneActive())
        {
            InitializeMinimap();
        }
    }

    private void InitializeMinimap()
    {
        try
        {
            borderMask = GameObject.Find("MiniMap Mask").GetComponent<Image>();
            borderImage = GameObject.Find("MiniMap Image").GetComponent<RawImage>();
            border = GameObject.Find("Border").GetComponent<Image>();
            borderCollider = GameObject.FindWithTag("MainCamera").GetComponentInChildren<CapsuleCollider2D>();

            isInitialized = true; // Set the initialization flag
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error initializing minimap: {ex.Message}");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //to modify to human and ghost
        {
            StartCoroutine(FadeTransparency(0.4f));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //to modify to human and ghost
        {
            StartCoroutine(FadeTransparency(1f));
        }
    }

    IEnumerator FadeTransparency(float targetTransparency)
    {
        float elapsedTime = 0f;
        Color initialMaskColor = borderMask.color;
        Color initialImageColor = borderImage.color;
        Color initialBorderColor = border.color;

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            
            Color maskColor = Color.Lerp(initialMaskColor, new Color(initialMaskColor.r, initialMaskColor.g, initialMaskColor.b, targetTransparency), t);
            borderMask.color = maskColor;

            Color imageColor = Color.Lerp(initialImageColor, new Color(initialImageColor.r, initialImageColor.g, initialImageColor.b, targetTransparency), t);
            borderImage.color = imageColor;

            Color borderColor = Color.Lerp(initialBorderColor, new Color(initialBorderColor.r, initialBorderColor.g, initialBorderColor.b, targetTransparency), t);
            border.color = borderColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color is set
        borderMask.color = new Color(initialMaskColor.r, initialMaskColor.g, initialMaskColor.b, targetTransparency);
        borderImage.color = new Color(initialImageColor.r, initialImageColor.g, initialImageColor.b, targetTransparency);
        border.color = new Color(initialBorderColor.r, initialBorderColor.g, initialBorderColor.b, targetTransparency);
    }
}
