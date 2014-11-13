using UnityEngine;
using System.Collections;

public class EnemyComponent : MonoBehaviour
{
    [HideInInspector] public Color originalColor;
    [HideInInspector] public float life;

    public int maxLife;
    private int animCounter;


    void Start()
    {
        originalColor = gameObject.renderer.material.color;
    }


    void Update ()
    {
        // Counter update
        if (animCounter > 0)
        {
            animCounter--;
            if (animCounter == 0)
                gameObject.renderer.material.color = originalColor;
        }
    }


    public void Damage(float damage)
    {
        // Damage recieved
        life -= damage;
        DamageAnim();

        if (life <= 0)
            Destroy(gameObject);
    }


    private void DamageAnim()
    {
        // Changes the color when damaged
        animCounter = 5;

        gameObject.renderer.material.color = Color.red;
    }
}
