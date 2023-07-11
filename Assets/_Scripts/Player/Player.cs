using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Singleton<Player>
{
    private Vector3 pos;
    private Transform movementTransform;
    [SerializeField] private Animator _animator;

    [SerializeField] private Image _fillImage;
    
    private float _percentageOfFill;
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

    private void OnFinishArea() => _xSpeed = 0;

    private void SwerveMovement()
    {
        _animator.SetBool("isRunning", true);
        pos += Vector3.forward * _movementSpeed * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X");
            pos += Vector3.right * mouseX * _xSpeed * Time.deltaTime * 10;
        }

        pos = new Vector3(Mathf.Clamp(pos.x, -_limitX, _limitX), pos.y, pos.z);
        transform.position = pos;
    }

    public void ModifyPercentage(float value)
    {
        _percentageOfFill += value;
        UpdateFillImage();
    }

    private void UpdateFillImage()
    {
        _percentageOfFill = Mathf.Clamp(_percentageOfFill, 0f, 100f);
        float fillAmount = _percentageOfFill / 100f;
        _fillImage.fillAmount = fillAmount;
    }
}
