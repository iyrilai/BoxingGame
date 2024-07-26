using UnityEngine;

public class PlayerInputHandle : MonoBehaviour
{
    [SerializeField] float rmbHoldTimeLimit = 0.4f;
    [SerializeField] BoxingMechanics mechanics;

    float rmbHoldTime = 0;

    // Update is called once per frame
    void Update()
    {
        HandleAttack();
        HandleDefense();
        HandleBlock();
    }

    void HandleAttack()
    {
        if (mechanics.OnAttack || mechanics.OnDefense)
            return;

        if (!Input.GetMouseButton(0))
            return;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            mechanics.Attack(1);
            return;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            mechanics.Attack(2);
            return;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            mechanics.Attack(3);
            return;
        }

        mechanics.Attack(1);
    }

    void HandleDefense()
    {
        if (mechanics.OnAttack || mechanics.OnDefense)
            return;

        if (Input.GetMouseButton(1))
            rmbHoldTime += Time.deltaTime;

        if (Input.GetMouseButtonUp(1) && rmbHoldTime < rmbHoldTimeLimit)
        {

            if (Input.GetKey(KeyCode.Alpha1))
            {
                mechanics.Defense(1);
                return;
            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                mechanics.Defense(2);
                return;
            }

            mechanics.Defense(2);
            rmbHoldTime = 0f;
        }
    }

    void HandleBlock()
    {
        if (rmbHoldTime < rmbHoldTimeLimit)
            return;

        if (Input.GetMouseButton(1))
        {
            mechanics.Block();
            return;
        }

        if (Input.GetMouseButtonUp(1))
        {
            mechanics.UnBlock();
            rmbHoldTime = 0;
        }
    }
}
