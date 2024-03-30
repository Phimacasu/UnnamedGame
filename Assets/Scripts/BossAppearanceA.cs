using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppearanceA : MonoBehaviour
{
    public Animation choiceAnimation;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
           
            choiceAnimation.Play("BossEntrance");
        }
    }
}
