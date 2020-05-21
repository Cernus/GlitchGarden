using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public static GameObject selectedDefender;
    public GameObject defender;

    private Text costText;

	// Use this for initialization
	void Start ()
    {
        costText = GetComponentInChildren<Text>();
        if(!costText)
        {
            Debug.LogWarning(name + " has no cost text");
        }

        costText.text = defender.GetComponent<Defender>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        Debug.Log(name + " pressed");

        // Set all buttons to black
        Transform transform = this.transform.parent;
        foreach (Transform child in transform)
        {
            SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();
            childRenderer.color = new Color(0f, 0f, 0f, 1f);
        }

        // Set selected button to normal
        //SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        //renderer.color = new Color(1f, 1f, 1f, 1f);
        this.GetComponent<SpriteRenderer>().color = Color.white;

        selectedDefender = defender;
    }
}
