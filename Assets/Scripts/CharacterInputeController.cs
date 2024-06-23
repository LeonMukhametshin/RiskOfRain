using System;
using TMPro;
using UnityEngine;

public class CharacterInputeController : MonoBehaviour
{
    private IControllable _controllable;

    private void Awake()
    {
        _controllable = GetComponent<IControllable>();

        if ( _controllable != null )
        {
            throw new Exception($"There is no IControllable component on the object: {gameObject.name}");
        }    
    }

    private void Update()
    {
        ReadMove();
        ReadJump();
    }

    private void ReadMove()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var directiont = new Vector3(horizontal, 0f, vertical);

        _controllable.Move(directiont);
    }

    private void ReadJump()
    {
        if (Input.GetButton("Jump"))
        {
            _controllable.Jump();
        }
    }
}
