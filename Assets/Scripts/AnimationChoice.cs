using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChoice : MonoBehaviour
{
    public AnimationClip _clip1;
    public AnimationClip _clip2;

    public AnimationClip GetClip1() { return _clip1; }
    public AnimationClip GetClip2() { return _clip2; }
}
