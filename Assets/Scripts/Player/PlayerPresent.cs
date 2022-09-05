using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]// Jump01, PlayerInput, ColliderEnterEvent
public class PlayerPresent : NetworkBehaviour, IDamagable
{
    [Header("Global Links")]
    [SerializeField] GameObject PlayerCameraPref;

    [Header("Local Links")]
    [SerializeField] PlayerViewStates _viewStates;
    [Header("Configuration")]//info: change affect only in start, no runtime
    [SerializeField] float _speed;
    [SerializeField] float _longJump;
    [SerializeField] float _timeJump;
    [SerializeField] float _hurtTime;

    private StatesManager _statesManager;
    private ScoreCounter _scoreCounter;
    private PlayerGetDamage _playerGetDamage;

    private GameObject _selfCamera;

    private PlayerMoving _playerMoving;
    private PlayerJump01 _playerJump;
    private PlayerAttackPerJump _attackJump;

    [SyncVar]
    private string _playerName;
    [SyncVar]
    private int _score;
    [SyncVar]
    private int _indexState;
    /*
        NormalState = 0,
        HurtState = 1,
        JumpState = 2
     */
    void Start()
    {
        if (isLocalPlayer)
        {
            _selfCamera = Instantiate(PlayerCameraPref, transform.position, transform.rotation);
            Camera camera = _selfCamera.GetComponentInChildren<Camera>();
            _selfCamera.GetComponent<CameraMove1>().Player = transform;
            PlayerInput playerInput = GetComponent<PlayerInput>();
            playerInput.enabled = true;
            playerInput.Camera = camera;
            playerInput.MoveDirection += NetMoveDirection;
            playerInput.JumpToMoveDir += NetJumpTo;

        }
        
        if (isServer)
        {
            _playerName = "Player" + Random.Range(1, 999);

            _statesManager = new StatesManager();
            _scoreCounter = new ScoreCounter();
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            Moving moving = new Moving(rigidbody, _speed);
            _playerMoving = new PlayerMoving(moving, _statesManager);
            Jump01 jump = GetComponent<Jump01>();
            jump.Init(rigidbody, _longJump, _timeJump);
            _playerJump = new PlayerJump01(jump, rigidbody, _statesManager, _timeJump);
            _attackJump = new PlayerAttackPerJump(_scoreCounter, _statesManager);
            GetComponent<ColliderEnterEvent>().EnterEvent += NetAttack;

            _playerGetDamage = new PlayerGetDamage(_statesManager, _hurtTime);
        }
    }
    [Command]
    private void NetMoveDirection(Vector3 direction)
    {
        _playerMoving.MoveDirection(direction);
    }
    [Command]
    private void NetJumpTo(Vector3 pointClick)
    {
        _playerJump.Jump(pointClick);
    }
   
    private void NetAttack(Collision collision) {
        _attackJump.Attack(collision);
    }
    void Update()
    {
        if (isServer)
        {
            _statesManager.Update();

            if (_statesManager.HaveStateOfType(typeof(HurtState)))
                _indexState = 1;
            else if (_statesManager.HaveStateOfType(typeof(JumpState)))
                _indexState = 2;
            else
                _indexState = 0;

            _score = _scoreCounter.Score;
        }
       
    }
    private void LateUpdate()
    {
        _viewStates.SetStateByIndex(_indexState);
    }

    public bool TryDamage()
    {
        return _playerGetDamage.TryGetDamage();
    }
    private void OnDestroy()
    {
        Destroy(_selfCamera);
    }
    public (string, int) GetPlayerInfo()
    {
        return (_playerName, _score); 
    }
}
