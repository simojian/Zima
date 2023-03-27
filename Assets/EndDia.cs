using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndDia : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float textSpeed;

    public Sprite[] profiles;
    public Image imageChange;

    public AudioSource aS;

    private int index;

    void StartDia()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            aS.Play();
            
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
            
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());

            
            if (lines[index].ToCharArray()[0] == 'M')
            {
                imageChange.sprite = profiles[0];
            }
            else
            {
                imageChange.sprite = profiles[1];
            }
        }
        else
        {
            SceneManager.LoadScene("End");
        }
    }

    private void Start()
    {
        textComp.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComp.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
            }
        }
    }
}
