using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSlimes : MonoBehaviour
{
    public GameObject _slime;
    public Animator _anim;
    void Start()
    {
        if (_slime.name == "Slime_Background") {
            _anim = _slime.GetComponent<Animator>();
            _anim.Play("Jump");
        } else {
            _anim = _slime.GetComponent<Animator>();
            _anim.Play("Idle");
        }
    }
}
