﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Weapon : MonoBehaviour
{

    #region Vars
    public int weaponID;        // ID of Weapon.
    public float damage;        // Damage of the weapon.
    public float range;         // Range of the weapon.         // This is for the shop.
    public float attackSpeed;   // Attackspeed of the weapon.   
    public float cost;          // Cost of the weapon.          // This is for the shop.

    private Animator _controller;       // Animator Component.
    private BoxCollider2D _collider;    // Collider Component.

    private bool colliderEnabled = false;
    #endregion

    void Start()
    {
        _controller = gameObject.GetComponent<Animator>();      // Get the Animator Component.
        _collider = gameObject.GetComponent<BoxCollider2D>();   // Get the Collider Component.
    }

    public void Attack()
    {
        _controller.SetTrigger(Constants.ANIMATOR_PARAMETER_ATTACK);    // Play the animation.
    }

    /* This script is for the Animator. */
    public void EnableCollider()
    {
        _collider.enabled = true; // Enable Collider;
        colliderEnabled = true;
    }

    /* This script is for the Animator. */
    public void DisableCollider()
    {
        _collider.enabled = false;  // Disable the Collider.
        colliderEnabled = false;
    }

    void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.gameObject.tag == Constants.TAG_ENEMY || _other.gameObject.tag == Constants.TAG_PLAYER) // Check if target is the enemy or the player.
        {
            if (_other.gameObject.tag != gameObject.tag && colliderEnabled == true) // If he doesn't have collision with himself or his friends.
            {
                _other.gameObject.GetComponent<Health>().health = -damage;  // Deal damage.
                GameObject.Find(Constants.NAME_SOUND).transform.Find("Attack Sound").GetComponent<PlayAudio>().PlayRandomWeaponSound();
                GameObject.FindGameObjectWithTag(Constants.TAG_CAMERA).GetComponent<CameraMovementScript>().ShakeAngle(2.5f);
            }
        }
    }
}
