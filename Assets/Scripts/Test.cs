using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] BoxingMechanics mech;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopBlock());        
    }

    IEnumerator StopBlock()
    {
        yield return new WaitForSeconds(1);
        mech.Block();
        mech.Attack(1);
        yield return new WaitForSeconds(3);
        mech.UnBlock();
        yield return new WaitForSeconds(3);
        mech.Attack(1);
        yield return new WaitForSeconds(4);
        mech.Attack(2);
        yield return new WaitForSeconds(4);
        mech.Defense(1);
        yield return new WaitForSeconds(4);
        mech.Block();
        yield return new WaitForSeconds(3);
        mech.UnBlock();
    }
}
