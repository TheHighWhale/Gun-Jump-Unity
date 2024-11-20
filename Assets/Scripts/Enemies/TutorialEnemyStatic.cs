using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyStatic : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        dead = true;
        Debug.Log("dead is true");
        StartCoroutine(DeathDelay());
    }

    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(.1f);
        FindObjectOfType<LevelManager>().EnemyDefeated();
        
    }
}
