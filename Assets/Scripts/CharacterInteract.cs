using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    public StorySystem _storySystem;
    public AnimationChoice _choice;

    private void Start()
    {
        _storySystem = FindObjectOfType<StorySystem>();
        _choice = FindObjectOfType<AnimationChoice>();
    }

    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.CompareTag("Interactable"))
        {
            _storySystem.SetClip(_choice.GetClip1(), 1);
            _storySystem.SetClip(_choice.GetClip2(), 2);
            _storySystem.SetButtonVisibility(_storySystem._Button1, true);
            _storySystem.SetButtonVisibility(_storySystem._Button2, true);
        }
    }

    private void OnTriggerExit(Collider p_other)
    {
        if (p_other.CompareTag("Interactable"))
        {
            _storySystem.SetDefaultClips();
            _storySystem.SetButtonVisibility(_storySystem._Button1, false);
            _storySystem.SetButtonVisibility(_storySystem._Button2, false);
        }
    }
}
