using UnityEngine;

internal class CharacterMovement : MonoBehaviour
{
    [SerializeField] BoxingCharacterAnimation animator;
    [SerializeField] BoxingMechanics mechanics;

    public void MoveCharacter()
    {
        if (mechanics.OnAttack || mechanics.OnDefense) 
            return;
        
        //Move Animation
    }
}
