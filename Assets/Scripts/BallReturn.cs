using UnityEngine;


public class BallReturn : MonoBehaviour
{
    private BallLauncher _ballLauncher;


    private void Awake()
    {
        this._ballLauncher = FindObjectOfType<BallLauncher>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        this._ballLauncher.ReturnBall();
        collision.collider.gameObject.SetActive(false);
    }


}   // class BallReturn