using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _animator;
    private static readonly int DoorClose = Animator.StringToHash("DoorClose");

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        _animator.SetBool(DoorClose, false);
    }

    public void CloseDoor()
    {
        _animator.SetBool(DoorClose , true);
    }
}