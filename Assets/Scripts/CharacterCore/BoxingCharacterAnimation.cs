using System.Collections;
using UnityEngine;
using UnityEngine.Events;

internal class BoxingCharacterAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float animationResetOffset = 1.6f;


    string currentState = string.Empty;

    const string IDLE = "character_idle";
    const string WALKING = "character_walking";
    const string ATTACK_1 = "character_attack_1";
    const string ATTACK_2 = "character_attack_2";
    const string ATTACK_3 = "character_attack_3";
    const string DEFENSE_1 = "character_defense_1";
    const string DEFENSE_2 = "character_defense_2";
    const string BLOCKING = "character_blocking";

    public UnityAction OnResetCallBack { get; set; }

    void SetAnimationState(string state)
    {
        if (state == currentState) return;

        currentState = state;
        animator.CrossFade(state, 0.3f);

        if (state is ATTACK_1 or ATTACK_2 or ATTACK_3 or DEFENSE_1 or DEFENSE_2)
        {
            StartCoroutine(ResetAnimation(new(animator.GetCurrentAnimatorStateInfo(0).length - animationResetOffset)));
        }
    }

    public void SetAnimationState(AnimationState state)
    {
        SetAnimationState(GetAnimationID(state));
    }

    string GetAnimationID(AnimationState state)
    {
        return state switch
        {
            AnimationState.Idle => IDLE,
            AnimationState.Walking => WALKING,
            AnimationState.Attack_1 => ATTACK_1,
            AnimationState.Attack_2 => ATTACK_2,
            AnimationState.Attack_3 => ATTACK_3,
            AnimationState.Defense_1 => DEFENSE_1,
            AnimationState.Defense_2 => DEFENSE_2,
            AnimationState.Blocking => BLOCKING,
            _ => string.Empty,
        };
    }

    IEnumerator ResetAnimation(WaitForSeconds wait)
    {
        yield return wait;
        SetAnimationState(AnimationState.Idle);
        OnResetCallBack.Invoke();
    }

    public enum AnimationState
    {
        Idle,
        Walking,
        Attack_1,
        Attack_2,
        Attack_3,
        Defense_1,
        Defense_2,
        Blocking,
    }
}
