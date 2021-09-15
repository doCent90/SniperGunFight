using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AttackState _attackState;

    private Quaternion _startPosition;
    private bool _isReadyRotate;

    private const float Distance = 6f;
    private const float Speed = 0.2f;

    private void OnEnable()
    {
        _startPosition = transform.rotation;
        _isReadyRotate = false;

        _attackState.Attacked += OnRotateReady;
    }

    private void OnDisable()
    {
        _attackState.Attacked -= OnRotateReady;
    }

    private void Update()
    {
        Follow();
        Rotate();
    }

    private void Follow()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z - Distance);
    }

    private void Rotate()
    {
        if(_isReadyRotate)
            transform.rotation = new Quaternion(transform.rotation.x, _player.transform.rotation.y * Speed, transform.rotation.z, transform.rotation.w);
        else
            transform.rotation = _startPosition;
    }

    private void OnRotateReady(bool isReady)
    {
        _isReadyRotate = isReady;
    }
}
