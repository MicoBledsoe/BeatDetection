using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    public AudioPeer audioPeer; // Reference to the AudioPeer script
    public Material skyboxMaterial; // The skybox material to modify
    public Color[] colors; // Array of colors to cycle through

    private int currentColorIndex = 0; // Index to track the current color

    void Start()
    {
        if (audioPeer == null)
        {
            Debug.LogError("AudioPeer is not assigned.");
            return;
        }

        if (skyboxMaterial == null)
        {
            Debug.LogError("Skybox material is not assigned.");
            return;
        }

        if (colors.Length == 0)
        {
            Debug.LogError("No colors assigned.");
            return;
        }

        // Set the initial color to the first color in the array
        skyboxMaterial.SetColor("_Tint", colors[currentColorIndex]);
    }

    void Update()
    {
        // Check if a beat is detected
        if (audioPeer.IsBeatDetected())
        {
            ChangeSkyboxColor();
        }
    }

    void ChangeSkyboxColor()
    {
        // Increment the color index and loop back if needed
        currentColorIndex = (currentColorIndex + 1) % colors.Length;

        // Change the skybox color to the next color in the array
        skyboxMaterial.SetColor("_Tint", colors[currentColorIndex]);
    }
}
