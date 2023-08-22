using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/SuperEnemy")]
public class SuperEnemy : Enemy {

    public Transform m_rocket;

    protected float m_fireTimer = 2;

    protected Transform m_player;

    void Awake()
    {
        GameObject obj=GameObject.FindGameObjectWithTag("Player");
        if ( obj!=null )
        {
            m_player=obj.transform;
        }
    }

    protected override void UpdateMove()
    {

        m_fireTimer -= Time.deltaTime;
        if (m_fireTimer <= 0)
        {
            m_fireTimer = 2;

            if ( m_player!=null )
            {
                Vector3 relativePos = m_transform.position-m_player.position;
                Instantiate( m_rocket, m_transform.position, Quaternion.LookRotation(relativePos) );
				//Instantiate( m_rocket, m_transform.position, Quaternion.identity );
            }
        }
        
        // Ç°½ø
        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
}
