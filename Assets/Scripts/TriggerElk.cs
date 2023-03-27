using UnityEngine;

public class TriggerElk : MonoBehaviour
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

    public void DisableElkTrigger()
    {
        isDisabled = true;
        _animator.CrossFade("DAttack Horns 1", .2f);
        _animator.SetBool(IsDisabled, isDisabled);
    }

    public void EnableElkTrigger()
    {
        isDisabled = false;
        _animator.CrossFade("DAttackFrontLegs", .2f);
        _animator.SetBool(IsDisabled, isDisabled);
    }

    public void DestroyElkTrigger()
    {
        _animator.CrossFade("DDeath Side", .2f);
    }
}