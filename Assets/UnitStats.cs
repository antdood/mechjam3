using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class UnitStats : MonoBehaviour
{
    public enum Team
    {
        One,
        Two
    }

    [SerializeField]
    public Team team;

    [SerializeField]
    public float current_health;
    [SerializeField]
    public float max_health;


    [SerializeField]
    public float speed;

    Material HealthBarMat;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
        Transform t = transform.Find("HealthBar");

        HealthBarMat = t.GetComponent<Renderer>().material;

        HealthBarMat.SetFloat("_SegmentCount", max_health);
        HealthBarMat.SetFloat("_FilledSegments", current_health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float TakeDamage(float incoming_damage)
    {
        float target_health = current_health - incoming_damage;
        return SetCurrentHealth(target_health);
    }

    private float SetCurrentHealth(float health)
    {
        current_health = health;
        HealthBarMat.SetFloat("_FilledSegments", current_health);

        return current_health;
    }

    [Button]
    void boop()
    {
        TakeDamage(1);
    }
}
