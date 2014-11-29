using UnityEngine;
using System.Collections;

public class PlayerComponent : MonoBehaviour 
{
    Player player;

    // Damage relative
    public Color originalColor;
    private int animCounter;


    public void Init(Player player)
    {
        this.player = player;
    }


    void Start()
    {
        // Damage relative
        player.currentLife = player.maxLife;
        // originalColor = gameObject.renderer.material.color;
        animCounter = 0;
    }


    void Update()
    {
        // Hit animation
        //if (animCounter > 0)
        //{
        //    animCounter--;
        //    if (animCounter == 0)
        //        gameObject.renderer.material.color = originalColor;
        //}
    }


    public void Damage(float damage)
    {
        player.currentLife -= damage;
        DamageAnim();

        // Player dead
        if (player.currentLife <= 0)
            Object.Destroy(gameObject);
    }


    private void DamageAnim()
    {
        animCounter = player.damageAnimTime;

        // gameObject.renderer.material.color = Color.red;
    }
}
