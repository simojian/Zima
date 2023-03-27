using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChestnutClick : MonoBehaviour
{
    private GameObject gameLogic;
    private ClickOnLeaf cLScript;

    private float timer = 0;
    private bool original = true;
    private bool decay = false;

    public AudioSource aS;
    public AudioSource fallSound;

    public Vector2 pitchRange;
    public Vector2 volumeRange;

    private void Start()
    {
        gameLogic = GameObject.Find("GameLogic");

        cLScript = gameLogic.GetComponent<ClickOnLeaf>();

        if (GameObject.FindGameObjectsWithTag("Nut").Length > 1)
        {
            original = false;
        }

        decay = cLScript.nutDecay;
    }

    private void OnMouseDown()
    {
        
        nutClicked();
    }

    void nutClicked()
    {
        
        aS.pitch = Random.Range(pitchRange.x, pitchRange.y);
        aS.volume = Random.Range(volumeRange.x, volumeRange.y);
        aS.Play();
        

        cLScript.AddNut();
        Destroy(gameObject);
    }

    private void Update()
    {
        if (decay && !original)
        {
            timer += Time.deltaTime;

            if (timer >= cLScript.nutDespawnTimer)
            {
                nutClicked();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!original)
        {
            fallSound.pitch = Random.Range(pitchRange.x, pitchRange.y);
            fallSound.volume = Random.Range(volumeRange.x, volumeRange.y);
            fallSound.Play();
        }
    }
}
