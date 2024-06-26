using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Projectile Data")]
public class ProjectileScriptableObject : ScriptableObject
{
    public float damage;
    public float projectileSpeed;
    public float knockBackDuration;
    public float knockBackForce;
}
