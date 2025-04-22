using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs 
{
    private PlayerMovement _playerMovement;

    private PlayerView _playerView;

    private Vector2 _dir;

    public bool input = true;

    public PlayerInputs(PlayerMovement pMove, PlayerView pView) 
    {
        _playerMovement = pMove;
        _playerView = pView;
        
    }

    public void InputsUpdate(bool grounded)
    {
        if (!input)
        {
            return;
        }

        MovementInputs();
        
        
        DuckInput();

        if (grounded)
        {
            JumpInput();
        }     
    }

    private void MovementInputs()
    {
        float h = (Input.GetAxisRaw("Horizontal"));

        float v = (Input.GetAxisRaw("Vertical"));

        _dir = new Vector2(h, v);

        if (_dir.sqrMagnitude != 0)
        {
            _playerView.MovementPressed();
            _playerMovement.Movement(_dir);
        }
        else _playerView.MovementStatic();


    }

    private void JumpInput()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                _playerView.JumpPressed();
                _playerMovement.Jump();
            }
            else _playerView.JumpEnd();   
    }

    public void DuckInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Me agaché");
            _playerMovement.Duck();
            _playerView.DuckStart();

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _playerMovement.Standing();
            _playerView.DuckEnd();
        }
        
    }

}
