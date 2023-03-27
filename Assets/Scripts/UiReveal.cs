using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiReveal : MonoBehaviour
{
    public GameObject showUi;

    public void Reveal()
    {
        showUi.SetActive(true);
    }
}
