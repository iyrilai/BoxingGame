using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] GameObject player;
    [SerializeField] BoxingMechanics mechanics;

    [Header("Setting")]
    [SerializeField] float playerRange;
    [SerializeField] float speed;

    BoxingMechanics playerMechanics;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.Find("Player");

        playerMechanics = player.GetComponent<BoxingMechanics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.Instance.IsLevelStarted)
            return;

        if (!playerMechanics.IsBlocking && mechanics.IsBlocking)
            mechanics.UnBlock();

        if (mechanics.OnAttack || mechanics.OnDefense)
            return;

        transform.LookAt(player.transform);

        if (!IsPlayerInRange())
        {
            MoveTowardsPlayer();
            return;
        }

        EnemyAttackAI();
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += speed * Time.deltaTime * direction;
    }

    bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= playerRange;
    }

    void EnemyAttackAI()
    {
        if (playerMechanics.IsBlocking && !mechanics.IsBlocking)
            mechanics.Block();

        if (playerMechanics.OnAttack)
        {
            mechanics.Defense(2);
            return;
        }

        mechanics.Attack(Random.Range(1, 4));
    }
}
