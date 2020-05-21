using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    private Text starText;
    private int stars;
    public enum Status
    {
        SUCCESS,
        FAILURE
    };
    
    // Use this for initialization
	void Start ()
    {
        starText = this.GetComponent<Text>();
        stars = 100;
        UpdateDisplay();
	} 
	
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();        
        
        //Debug.Log(ammount + "stars added to display");
    }

    public Status UseStars(int amount)
    {
        if(stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }

        return Status.FAILURE;
        
    }
}
