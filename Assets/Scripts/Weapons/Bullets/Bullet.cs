using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private const float Speed = 22f;

    private void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    public abstract void OnTriggerEnter(Collider collision);
}
