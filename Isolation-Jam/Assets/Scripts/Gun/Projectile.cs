﻿using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask whatIsSolid;
    public float lifeTime;
    public float rayLength;

    float projSpeed;
    int projDmg;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    void Update()
    {
        Vector3 direction = transform.InverseTransformDirection(transform.forward);
        direction.y = 0f;

        transform.Translate(direction.normalized * projSpeed * Time.deltaTime);

        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position - transform.forward * rayLength, transform.forward, out hitInfo, rayLength, whatIsSolid))
        {
            if (hitInfo.collider.CompareTag("Player"))
                hitInfo.collider.GetComponent<PlayerController>().AddHealth(-projDmg);
            else if (hitInfo.collider.CompareTag("Enemy"))
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(projDmg);

            DestroyProjectile();
        }
        Debug.DrawRay(transform.position - transform.forward * rayLength, transform.forward * rayLength, Color.red);
    }

    public void SetData(float _projSpeed, int _projDmg)
    {
        projSpeed = _projSpeed;
        projDmg = _projDmg;
    }

    void DestroyProjectile()
    {
        AudioManager.Instance.PlaySFX("Proj_Destroy");
        EffectsEmitter.Emit("Proj_Destroy", transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

}
