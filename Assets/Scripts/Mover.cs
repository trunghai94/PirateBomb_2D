using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float _velocity = 0f;
    float _time = 0f;
    bool _isJumping = false;
    float _prevPosY = 0f;
    bool _isJump = false;

    public void Moving(float speed)
    {
        //Mover.transform.position = new Vector3(Mover.transform.position.x + speed, Mover.transform.position.y, Mover.transform.position.z);
        this.transform.position = this.transform.position + new Vector3(speed, 0, 0);
    }

    public void Jumping(float jump)
    {
        if (_isJump) return;
        _isJump = true;
        _velocity = jump;
        _time = 0f;
        _isJumping = true;
        _prevPosY = this.transform.position.y;
    }

    private void Update()
    {
        if(_isJumping)
        {
            _prevPosY = this.transform.position.y;
            this.transform.position = this.transform.position + new Vector3(0, _velocity * _time + 0.5f*-9.8f*(_time * _time), 0);
            _time += Time.deltaTime;

            if (this.transform.position.y < _prevPosY)
                _isJumping = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJump = false;
        }
    }
}
