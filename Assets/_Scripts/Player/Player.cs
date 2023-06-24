using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    private Vector3 pos;
    private Transform movementTransform;
    
    [SerializeField] private float _movementSpeed, _xSpeed, _limitX;

    private float mouseX;

    protected override void Awake()
    {
        base.Awake();
        movementTransform = transform;
        pos = movementTransform.position;
    }
    
    private void OnEnable() => EventManager.OnFinishArea += OnFinishArea;
    private void OnDisable() => EventManager.OnFinishArea -= OnFinishArea;
   
    private void Update()
    {
        if (GameStates.Instance.gameState != State.Play) return;
        SwerveMovement();
    } 

    private void OnFinishArea()
    {
        _xSpeed = 0;
    }

    private void SwerveMovement()
    {
        pos += Vector3.forward * _movementSpeed * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X");
            pos += Vector3.right * mouseX * _xSpeed * Time.deltaTime * 10;
        }

        pos = new Vector3(Mathf.Clamp(pos.x, -_limitX, _limitX), pos.y, pos.z);
        transform.position = pos;
    }
}
