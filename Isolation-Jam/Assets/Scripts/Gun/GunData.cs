﻿using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Scriptable Objects/Create Gun")]
public class GunData : ScriptableObject
{
    [Header("For Spawning")]
    public GameObject prefab;
    public Sprite gunIcon;
    [Space]
    public Vector3 offsetPosition;
    public Vector3 offsetRotation;
    [Space]
    public int upperAnimationState;

    [Header("General")]
    public bool isAutomatic;
    public bool isEndlessAmmo;
    public int ammoCount;
    public float delayBtwShots;
    public string shootSFX;

    [Header("Projectile")]
    public GameObject projectile;
    public float projSpeed;
    public int projDmg;
}
