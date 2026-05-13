using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int[] upgrades=new int[2];
    public float basespeed=5f;
    public float speedMultiplier=1.5f;
    public int money=0;
    public TextMeshProUGUI moneyText;

    private Vector2 moveDirection=Vector2.right;
    public GameObject eye;
    public GameObject eyes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateMoneyUI();
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed=(basespeed+upgrades[0])*speedMultiplier;
        transform.Translate(moveDirection*currentSpeed*Time.deltaTime,Space.World);
        HandleInput();
        UpdateEyePosition();
    }
    void HandleInput()
    {
        int controlLevel=upgrades[0];
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection=RotateVector(moveDirection,90f);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection=RotateVector(moveDirection,-90f);
        }
        if(controlLevel>=1)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveDirection=-moveDirection;
            }
        }
        if(controlLevel>=2)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))   moveDirection=Vector2.up;
            if(Input.GetKeyDown(KeyCode.DownArrow)) moveDirection=Vector2.down;
            if(Input.GetKeyDown(KeyCode.LeftArrow)) moveDirection=Vector2.left;
            if(Input.GetKeyDown(KeyCode.RightArrow))   moveDirection=Vector2.right;
        }
    }
    Vector2 RotateVector(Vector2 v,float degrees)
    {
        float sin=Mathf.Sin(degrees*Mathf.Deg2Rad);
        float cos=Mathf.Cos(degrees*Mathf.Deg2Rad);
        float tx=v.x;
        float ty=v.y;
        v.x=(cos*tx)-(sin*ty);
        v.y=(sin*tx)+(cos*ty);
        return v;
    }
    void UpdateEyePosition()
    {
        eye.SetActive(false);
        eyes.SetActive(false);
        if(moveDirection==Vector2.right)
        {
            eye.SetActive(true);
            eye.transform.localPosition=new Vector3(0.25f,0.18f,0);
        }
        if(moveDirection==Vector2.left)
        {
            eye.SetActive(true);
            eye.transform.localPosition=new Vector3(-0.25f,0.18f,0);
        }
        if(moveDirection==Vector2.up)
        {
            eyes.SetActive(true);
            eyes.transform.localPosition=new Vector3(0,0.3f,0);
        }
        if (moveDirection==Vector2.down)
        {
            eyes.SetActive(true);
            eyes.transform.localPosition=new Vector3(0,-0.3f,0);
        }
    }
    public void addMoney(int amount)
    {
        money+=amount;
        Debug.Log("現在のお金:"+money);
        UpdateMoneyUI();
    }
    void UpdateMoneyUI()
    {
        moneyText.text="money:"+money;
    }
    public void OnAffected(EffectData data)
    {
        //ぽわわあ    
    }
}
