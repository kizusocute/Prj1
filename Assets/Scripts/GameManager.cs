using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int currentEnergy;
    [SerializeField] public int energyThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpawn;
    private bool bossCalled = false;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private AudioManger audioManger;
    

    
    // Start is called before the first frame update
    void Start()
    {
        boss.SetActive(false);
        audioManger.StopAudioGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEnergy()
    {
        if (bossCalled)
        {
            return;
        }
        currentEnergy += 1;
        uiManager.UpdateEnergyBar();
        if (currentEnergy == energyThreshold)
        {
            CallBoss();
        }
    }
    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        audioManger.PlayBossAudio();
        enemySpawn.SetActive(false);
        uiManager.energyBar.SetActive(false);
        uiManager.fightBoss.SetActive(true);
    }
    
}
