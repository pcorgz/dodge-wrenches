using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CamShake : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Shake()
    {
        int rand = Random.Range(1, 4);
        anim.SetTrigger("cam_shake_" + rand);
    }
}
