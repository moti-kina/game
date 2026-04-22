using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerController script=collision.GetComponent<PlayerController>();
            Debug.Log("コインをゲット");
            Destroy(gameObject);
            script.addMoney(1);
        }
    }
}
