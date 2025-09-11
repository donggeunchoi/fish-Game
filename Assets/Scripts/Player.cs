using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform spriteRoot;
    [SerializeField] private bool useFlipX = true;

    private Rigidbody2D rigidbody;
    private Vector2 input;
    private SpriteRenderer sprite;
    private float baseScalsX = 1f;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        var target = spriteRoot ? spriteRoot : transform;

        sprite = target.GetComponent<SpriteRenderer>();
        if (sprite == null && !useFlipX)
        {
            baseScalsX = target.localScale.x;
        }
        else if (sprite == null && useFlipX)
        {
            Debug.Log("스프라이트가 없습니다.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;

        if (Mathf.Abs(input.x) > 0.01f)
        {
            ApplyFlip(input.x);
        }
    }

    void FixedUpdate()
    {
        rigidbody.velocity = input * moveSpeed;
    }

    void ApplyFlip(float xdir)
    {
        var target = spriteRoot ? spriteRoot : transform;

        if (useFlipX && sprite != null)
        {
            sprite.flipX = xdir < 0f;
        }
        else
        {
            var s = target.localScale;
            s.x = Mathf.Sign(xdir) * Mathf.Abs(baseScalsX);
            target.localScale = s;
        }
    }
}
