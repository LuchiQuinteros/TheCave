using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs 
{
    Player _player;
    
    public PlayerInputs(Player p)
    {
        _player = p;
    }

    public void MovementInputs()
    {
        float h = (Input.GetAxisRaw("Horizontal"));

        float v = (Input.GetAxisRaw("Vertical"));

        _player.Direction = new Vector2(h, v);
    }
}
