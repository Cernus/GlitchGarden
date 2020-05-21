using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInTime;

    private Image fadePanel;
    private Color currentColour = Color.black;
    
    // Use this for initialization
	void Start ()
    {
        fadePanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Time.timeSinceLevelLoad < fadeInTime)
        {
            // Fade in
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColour.a -= alphaChange;
            fadePanel.color = currentColour;
        }
        else
        {
            // Unticks box at top of inspector
            gameObject.SetActive(false);
        }
	}
}
