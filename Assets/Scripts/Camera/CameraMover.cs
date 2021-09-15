using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _distance;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z - _distance);
    }
}
