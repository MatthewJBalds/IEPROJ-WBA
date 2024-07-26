using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager Instance;

    [SerializeField]
    private List<TowerHealth> TowerHealthList;
    [SerializeField]
    private List<TowerHealth> EnemyTowerHealthList;

    public int totalTowerHealth;
    public int totalEnemyTowerHealth;

    private int currentTowerHealth;
    private int currentEnemyTowerHealth;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        EventManager.UpdateState += trackTowers;

    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (TowerHealth health in TowerHealthList)
        {
            totalTowerHealth += health.currentHealth;
        }
        foreach(TowerHealth health in EnemyTowerHealthList)
        {
            totalEnemyTowerHealth += health.currentHealth;
        }
    }

    private void OnDisable()
    {
        EventManager.UpdateState -= trackTowers;
    }

    private void trackTowers(GameState state)
    {
        if (state == GameState.PLAY)
        {
            TowerHealthList = TowerHealthList.Where(tower => tower != null).ToList();
            EnemyTowerHealthList = EnemyTowerHealthList.Where (tower => tower != null).ToList();
            foreach(TowerHealth health in TowerHealthList)
            {
                currentTowerHealth += health.currentHealth;
                totalEnemyTowerHealth = currentTowerHealth;
            }
            foreach(TowerHealth health in EnemyTowerHealthList)
            {
                currentEnemyTowerHealth += health.currentHealth;
                totalEnemyTowerHealth = currentEnemyTowerHealth;
            }

            switch (TowerHealthList.Count, EnemyTowerHealthList.Count)
            {
                case (0, _):
                    GameManager.Instance.UpdateGameState(GameState.LOSE);
                    break;
                case (_, 0):
                    GameManager.Instance.UpdateGameState(GameState.VICTORY);
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
