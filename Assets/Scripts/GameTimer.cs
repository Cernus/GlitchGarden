using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float levelSeconds = 100f;

    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel;
    private SceneLoader sceneLoader;
    private GameObject winLabel;

    // Use this for initialization
    void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        isEndOfLevel = false;

        FindYouWin();
        winLabel.SetActive(false);

        //slider.value = 0f;        
	}

    private void FindYouWin()
    {
        winLabel = GameObject.Find("You Win Text");
        if (!winLabel)
        {
            Debug.LogWarning("Please create You Win Text object");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        if(Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            HandleWinCondition();
        }
    }

    private void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        // Wait until audiosource has finished playing
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    // Destroy all objects with DestroyOnWin tag
    private void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");

        foreach(GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    private void LoadNextLevel()
    {
        sceneLoader.LoadNextScene();
    }
}
