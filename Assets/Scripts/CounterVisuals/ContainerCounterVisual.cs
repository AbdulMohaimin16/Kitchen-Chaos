using UnityEngine;
using System;

public class ContainerCounterVisual : MonoBehaviour
{   
    private const string IS_OPEN = "OpenClose";


    [SerializeField] private ContainerCounter containerCounter;

    private Animator containerCounterAniamtor;


    void Awake()
    {
        containerCounterAniamtor = GetComponent<Animator>();
    }

    private void Start()
    {
        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject;
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object sender, EventArgs e)
    {
        containerCounterAniamtor.SetTrigger(IS_OPEN);
    }

}
