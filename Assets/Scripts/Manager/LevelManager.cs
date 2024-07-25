using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool IsLevelStarted { get; set; }
    
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        IsLevelStarted = true;
    }
}
