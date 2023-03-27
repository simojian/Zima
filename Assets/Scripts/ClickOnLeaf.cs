using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ClickOnLeaf : MonoBehaviour
{
    // Start is called before the first frame update
    public int startLeafCount = 10000000;
    public int removeOnClick = 1;
    public int addNutOnClick = 1;
    public float nutSpawnChance = 0.1f;
    
    public int leafCount = -1;
    public int nutCount = 0;
    public TMP_Text leafCounterText;
    public TMP_Text nutCounterText;

    public GameObject nutObject;
    public GameObject nutSpawnPosition;
    private float spawnX = 0;
    private float spawnY = 0;
    public float spawnRange = 0;

    public float maxCoolDown = 1.0f;

    public float autoAmount = 0;
    public float maxTimeAuto = 3.0f;
    public float timeIncrementAuto = 0.3f;
    public float currentTimeAuto;
    public int autoRemove = 1;

    public int maxNuts = 30;
    public float nutDespawnTimer = 20f;
    public float nutDespawnRemove = 5f;
    public bool nutDecay = false;

    public Vector2 pitchRange;
    public Vector2 volumeRange;
    
    public AudioSource bgMusic;
    public AudioSource bushHit;

    [FormerlySerializedAs("particleSystem")] public ParticleSystem particleSys;
    private void Start()
    {
        leafCount = startLeafCount;

        spawnX = nutSpawnPosition.transform.position.x;
        spawnY = nutSpawnPosition.transform.position.y;

        currentTimeAuto = maxTimeAuto;
        
        bgMusic.Play();

    }

    public void OnCrownClick()
    {
        RemoveLeaf();
        float random = Random.Range(0.0f, 1.0f);

        if (random <= nutSpawnChance) spawnNut();
        
        particleSys.Play();

        bushHit.volume = Random.Range(volumeRange.x, volumeRange.y);
        bushHit.pitch = Random.Range(pitchRange.x, pitchRange.y);
        
        bushHit.Play();
    }

    public void spawnNut()
    {
        if (GameObject.FindGameObjectsWithTag("Nut").Length < maxNuts)
        {
            Vector3 spawnVector = new Vector3(spawnX + Random.Range(-spawnRange, spawnRange), spawnY, 0);
            Instantiate(nutObject, spawnVector, Quaternion.identity);
        }
    }


    public void RemoveLeaf()
    {
        leafCount -= removeOnClick;
    }

    

    public void AutoLeafInnit()
    {
        
        autoAmount++;
        currentTimeAuto /= 2;


    }

    public void AddNut()
    {
        nutCount += addNutOnClick;
    }

    public void NutDecayUpgrade()
    {
        nutDecay = true;
        nutDespawnTimer -= nutDespawnRemove;
    }

    private void Update()
    {
        if (leafCount <= 0)
        {
            leafCounterText.text = "0";
        }
        else
        {
            leafCounterText.text = leafCount.ToString();
        }
        
        
        nutCounterText.text = nutCount.ToString();
        

    }
}
