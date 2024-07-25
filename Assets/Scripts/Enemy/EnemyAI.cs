using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CharacterMovement movement;
    [SerializeField] BoxingMechanics mechanics;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.Instance.IsLevelStarted) 
            return;

        if (mechanics.OnAttack || mechanics.OnDefense)
            return;
    }
}
