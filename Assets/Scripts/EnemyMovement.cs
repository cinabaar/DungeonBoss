using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Collider2D EnemyCollider;
    public Rigidbody2D EnemyRigidBody;
    public float JumpHeight;
    public float WalkSpeed;

    public Collider2D wall;

    public bool DebugMovement = false;

    public enum MoveDirection
    {
        None = 0,
        Right = 1,
        Left = 2
    }

    private MoveDirection _currentDirection = MoveDirection.None;
    private bool _jumpLocked = false;

    public bool IsGrounded
    {
        // get { return EnemyCollider.IsTouchingLayers(LayerMask.NameToLayer("Wall")) && !_jumpLocked; }
        get { return EnemyCollider.IsTouching(wall) && !_jumpLocked; }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.ToString());
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            EnemyRigidBody.velocity += Vector2.up*JumpHeight;
            _jumpLocked = true;
            StartCoroutine(UnlockJump());
        }
    }

    IEnumerator UnlockJump()
    {
        yield return new WaitForSeconds(0.3f);
        _jumpLocked = false;
    }

    public void Move(MoveDirection direction)
    {
        switch (direction)
        {
            case MoveDirection.None:
            {
                EnemyRigidBody.velocity = new Vector2(0, EnemyRigidBody.velocity.y);
                break;
            }
            case MoveDirection.Right:
            {
                EnemyRigidBody.velocity = new Vector2(WalkSpeed, EnemyRigidBody.velocity.y);
                break;
            }
            case MoveDirection.Left:
            {
                EnemyRigidBody.velocity = new Vector2(-WalkSpeed, EnemyRigidBody.velocity.y);
                break;
            }
        }
        _currentDirection = direction;
    }

    public void Update()
    {
        if (DebugMovement)
        {
            Debug.Log(IsGrounded);
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            if (horizontal > 0)
            {
                Move(MoveDirection.Right);
            }
            else if (horizontal < 0)
            {
                Move(MoveDirection.Left);
            }
            else
            { 
                Move(MoveDirection.None);
            }
            if (vertical > 0)
            {
                Jump();
            }
        }
    }
}
