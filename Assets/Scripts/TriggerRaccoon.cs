
using UnityEngine;

public class TriggerRaccoon : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private bool isDisabled = false;
    private static readonly int IsDisabled = Animator.StringToHash("IsDisabled");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.SetBool(IsDisabled, isDisabled);
    }

    public void DisableRaccoonTrigger()
    {
        isDisabled = true;
        _animator.CrossFade("Rac_GetHit Right",.2f);
        _animator.SetBool(IsDisabled, isDisabled);
    }

    public void EnableRaccoonTrigger()
    {
        isDisabled = false;
        _animator.CrossFade("Rac_Jump in Place Baked",.2f);
        _animator.SetBool(IsDisabled, isDisabled);
    }
}