using TMPro;
using UnityEngine;


public class Block : MonoBehaviour
{
    private int _hitsRemaining = 5;

    private SpriteRenderer _spriteRenderer;
    private TextMeshPro    _text;


    private void Awake()
    {
        this._text           = GetComponentInChildren<TextMeshPro>();
        this._spriteRenderer = GetComponent<SpriteRenderer>();
        
        this.UpdateVisualState();
    }


    private void UpdateVisualState()
    {
        this._text.SetText(this._hitsRemaining.ToString());
        this._spriteRenderer.color = Color.Lerp(Color.white, Color.red, this._hitsRemaining / 10f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        this._hitsRemaining--;

        if (this._hitsRemaining > 0)
        {
            this.UpdateVisualState();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    internal void SetHits(int hits)
    {
        this._hitsRemaining = hits;

        this.UpdateVisualState();
    }


}   // class Block