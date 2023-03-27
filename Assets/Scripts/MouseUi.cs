using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseUi : MonoBehaviour
{
    public GameObject cdObject;
    private CoolDown cdTimer;

    public int timerStage = 12;

    private Animator animator;

    // Update is called once per frame

    void Start()
    {
        cdTimer = cdObject.GetComponent<CoolDown>();

        animator = GetComponent<Animator>();
    }
    void Update()
    {
        transform.position = Input.mousePosition;
        
        timerStage = cdTimer.timerStage;
        
        animator.SetInteger("TimerStage", timerStage);

        
    }
}
