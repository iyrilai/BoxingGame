using UnityEngine;

internal class BoxingMechanics : MonoBehaviour
{
    [SerializeField] BoxingCharacterAnimation animator;

    public bool OnAttack { get; private set; }
    public bool OnDefense { get; private set; }

    private void Start()
    {
        animator.OnResetCallBack += OnAttackDefenseReset;
    }

    void OnAttackDefenseReset()
    {
        Debug.Log("On Reset");
        OnDefense = false;
        OnAttack = false;
    }

    public void Attack(int type)
    {
        if (OnAttack || OnDefense) return;

        var state = type switch
        {
            1 => BoxingCharacterAnimation.AnimationState.Attack_1,
            2 => BoxingCharacterAnimation.AnimationState.Attack_2,
            3 => BoxingCharacterAnimation.AnimationState.Attack_3,
            _ => BoxingCharacterAnimation.AnimationState.Attack_1,         
        };

        animator.SetAnimationState(state);
        OnAttack = true;
    }

    public void Defense(int type)
    {
        if (OnAttack || OnDefense) return;

        var state = type switch
        {
            1 => BoxingCharacterAnimation.AnimationState.Defense_1,
            2 => BoxingCharacterAnimation.AnimationState.Defense_2,
            _ => BoxingCharacterAnimation.AnimationState.Defense_1,
        };

        animator.SetAnimationState(state);
        OnDefense = true;
    }

    public void Block()
    {
        animator.SetAnimationState(BoxingCharacterAnimation.AnimationState.Blocking);
        OnDefense = true;
    }

    public void UnBlock()
    {
        animator.SetAnimationState(BoxingCharacterAnimation.AnimationState.Idle);
        OnDefense = false;
    }
}
