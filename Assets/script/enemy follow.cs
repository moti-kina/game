using UnityEngine;

public class enemyfollow : MonoBehaviour
{
    public float movespeed=2f;
    private Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player=GameObject.FindGameObjectWithTag("Player");
        if(player!=null)
        {
            playerTransform=player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform!=null)
        {
            Vector2 direction=(playerTransform.position-transform.position).normalized;
            transform.Translate(direction*movespeed*Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            EffectData effectScript=GetComponent<EffectData>();
            if(effectScript!=null)
            {
                var player=collision.gameObject.GetComponent<PlayerController>();
                if(player!=null)
                {
                    player.OnAffected(effectScript.myEffect);
                }
            }
        }
    }
}
