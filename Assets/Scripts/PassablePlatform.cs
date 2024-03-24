using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassablePlatform : MonoBehaviour
{
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone.");
            SetPlatformPassable(true);
        }
    }

    private void OnTriggerExit(Collider p_other)
    {
        if (p_other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger zone.");
            SetPlatformPassable(false);
        }
    }

    private void SetPlatformPassable(bool passable)
    {
        _collider.isTrigger = passable;
    }
}
