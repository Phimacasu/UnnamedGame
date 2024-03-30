using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCutscene : MonoBehaviour
{
    public Animation choiceAnimation;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            choiceAnimation.Play("FinalAnimation");
        }
    }
}
