using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData")]
public class Player : ScriptableObject
{
    public float velocity;
    public float tuckVelocity;
    public float jumpForce;
    public float rotationSpeed;
}
