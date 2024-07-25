using UnityEngine;

internal class CharacterMovement : MonoBehaviour
{
    [SerializeField] BoxingCharacterAnimation animator;
    [SerializeField] BoxingMechanics mechanics;

    public void MoveCharacter(Vector3 pos)
    {
        if (mechanics.OnAttack || mechanics.OnDefense) 
            return;

        transform.Translate(pos);
    }
}
