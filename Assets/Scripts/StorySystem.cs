using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{
    // Butttons: placeholder "up" or "down"
    // disabled at first, enabled when it gets to a "trigger zone"
    // pressing buttons plays specific animations

    public Animation _animation;

    public AnimationClip _clip1;
    public AnimationClip _clip2;
    public Button _Button1;
    public Button _Button2;

    private void Start()
    {
        _Button1.gameObject.SetActive(false);
        _Button2.gameObject.SetActive(false);
        _animation = GameObject.Find("Player").GetComponent<Animation>();
    }

    public void SetClip (AnimationClip p_clip, int p_clipNumber)
    {
        if (p_clipNumber == 1) { _clip1 = p_clip; }
        else if (p_clipNumber == 2) { _clip2 = p_clip; }
    }

    public void SetDefaultClips()
    {
        _clip1 = null;
        _clip2 = null;
    }

    public void SetButtonVisibility(Button p_button, bool p_isVisible)
    {
        p_button.gameObject.SetActive(p_isVisible);
    }

    public void PlayAnimationClip(int p_clipNumber)
    {
        if (p_clipNumber == 1)
        {
            if (_clip1 != null)
            {
                _animation.clip = _clip1;
                _animation.Play();
            }
            else
            {
                Debug.LogError("clip is NOT playing");
            }
        }
        else if (p_clipNumber == 2)
        {
            if (_clip2 != null)
            {
                _animation.clip = _clip2;
                _animation.Play();
            }
            else
            {
                Debug.LogError("clip is NOT playing");
            }
        }
    }
}
