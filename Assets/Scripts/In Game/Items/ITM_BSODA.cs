using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITM_BSODA : ItemBase
{
    public float speed = 4;
    public float lifeSpan = 30;
    [SerializeField] MovementEffect effect;

    List<MovableEntity> entities = new List<MovableEntity>();

    public override bool Use()
    {
        var player = PlayerManager.Instance;

        var spray = Instantiate(this);
        spray.transform.SetPositionAndRotation(player.ctrl.plc.transform.position,
            player.ctrl.plc.transform.rotation);

        player.ApplyGuilt("Drinking", 1);
        return true;
    }

    void Update()
    {
        effect.addend = transform.forward * speed * Time.deltaTime;
        transform.position += effect.addend;

        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0)
        {
            foreach (var e in entities)
                e.allEffects.Remove(effect);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            var e = other.GetComponent<MovableEntity>();
            e.allEffects.Add(effect);
            entities.Add(e);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            var e = other.GetComponent<MovableEntity>();
            e.allEffects.Remove(effect);
            entities.Remove(e);
        }
    }
}