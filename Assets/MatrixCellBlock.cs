using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MatrixCellBlock : MonoBehaviour
{
    private Animator _animator;
    private string _animationDeleteTriggerName = "CellBlock_DeleteTrigger";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Delete()
    {
        if (_animator == null) _animator = GetComponent<Animator>();
        _animator.SetTrigger(_animationDeleteTriggerName);
    }

    public void OnDeleteAnimationEnded()
    {
        //Destroy(gameObject);
    }
}
