using UnityEngine;
using TMPro;

public class gamemanager : MonoBehaviour
{
    public int currentLevel=1;
    public float remainingTime;
    private bool isLevelRunning=false;
    public float baseTime=10f;
    public float extraTime=0f;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timerText;
    public bool isPlaying=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartNewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLevelRunning)
        {
            UpdateTimer();
        }
    }
    public void StartNewLevel()
    {
        isLevelRunning=true;
        float totalBase=baseTime+extraTime;
        if(currentLevel%5==0)
        {
            remainingTime=totalBase*2f;
        }
        else
        {
            remainingTime=totalBase;
        }
        UpdateUI();
        CheckLevelEvents();
    }
    void UpdateTimer()
    {
        remainingTime-=Time.deltaTime;
        if(remainingTime<=0)
        {
            remainingTime=0;
            isLevelRunning=false;
            LevelClear();
        }
        if(timerText.text!=null)
        {
            timerText.text="Time:"+remainingTime.ToString("F1");
        }
    }
    void LevelClear()
    {
        Debug.Log($"Level{currentLevel}Clear!");
        currentLevel++;
        StartNewLevel();
    }
    void UpdateUI()
    {
        if(levelText!=null) levelText.text="Level:"+currentLevel;
    }
    void CheckLevelEvents()
    {
        Debug.Log($"---Level{currentLevel}Events---");
        if(currentLevel%2==1)
        {
            Debug.Log("追加する敵を選択してください");
        }
        if(currentLevel%2==0)
        {
            Debug.Log("敵のバフを選んでください");
        }
        if(currentLevel%3==0)
        {
            OpenShop();
        }
    }
    void OpenShop()
    {
        isLevelRunning=false;
        Debug.Log("ショップ");
    }
}
