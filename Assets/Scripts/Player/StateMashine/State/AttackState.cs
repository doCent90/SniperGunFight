using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AttackState : StatePlayer
{
    [SerializeField] private ParticleSystem _shootFX;
    [SerializeField] private GameObject _laser;
    [SerializeField] private ParticalCollisions _particalCollisions;
    [Header("Settings of Shoot Position")]
    [SerializeField] private float _degrees;
    [SerializeField] private float _speed;
    [Header("Delay between shoot")]

    private Animator _animator;
    private PlayerShooter _playerShooter;

    private float _elapsedTime;
    private int _direction = 1;
    private int _attackCount = 1;

    private const float DelayBetweenShoot = 0.1f;
    private const float TimeScaleNormal = 1f;
    private const float TimeScaleRapid = 0.4f;
    private const string ShootAnimation = "Shoot";
    private const string TargetAnimation = "LockTarget";

    public event UnityAction<bool> Attacked;

    private void OnEnable()
    {
        Attacked?.Invoke(true);

        SetAnglePlayer();

        Time.timeScale = TimeScaleRapid;

        if (_attackCount == 2)
            _direction = -1;
        else
            _direction = 1;

        _laser.SetActive(true);
        _particalCollisions.enabled = true;
        _attackCount++;
    }

    private void OnDisable()
    {
        Attacked?.Invoke(false);

        Time.timeScale = TimeScaleNormal;
        _laser.SetActive(false);
        _animator.SetBool(TargetAnimation, false);
    }

    private void Start()
    {        
        _playerShooter = GetComponent<PlayerShooter>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RotatePlayer();

        _animator.SetBool(TargetAnimation, true);
        _elapsedTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _elapsedTime >= DelayBetweenShoot)
        {
            Attack();
            _elapsedTime = 0;
        }
    }

    private void SetAnglePlayer()
    {
        transform.eulerAngles = Vector3.zero;
    }

    private void RotatePlayer()
    {
        if (_direction == 1)
            transform.Rotate(Vector3.down, _speed * Time.deltaTime);
        else
            transform.Rotate(Vector3.up, _speed * Time.deltaTime);
    }

    private void Attack()
    {
        _animator.SetTrigger(ShootAnimation);
        _playerShooter.Shoot();
        _shootFX.Play();
    }
}
