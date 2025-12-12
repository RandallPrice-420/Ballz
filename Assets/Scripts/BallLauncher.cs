using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallLauncher : MonoBehaviour
{
    [SerializeField]
    private Ball _ballPrefab;

    private Vector3       _startDragPosition;
    private Vector3       _endDragPosition;
    private BlockSpawner  _blockSpawner;
    private LaunchPreview _launchPreview;
    private List<Ball>    _balls = new List<Ball>();
    private int           _ballsReady;


    private void Awake()
    {
        this._blockSpawner  = FindObjectOfType<BlockSpawner>();
        this._launchPreview = GetComponent<LaunchPreview>();
        CreateBall();
    }


    public void ReturnBall()
    {
        this._ballsReady++;

        if (this._ballsReady == this._balls.Count)
        {
            this._blockSpawner.SpawnRowOfBlocks();
            this.CreateBall();
        }
    }


    private void CreateBall()
    {
        var ball = Instantiate(this._ballPrefab);
        ball.gameObject.SetActive(false);
        this._balls.Add(ball);
        this._ballsReady++;
    }


    private void Update()
    {
        if (this._ballsReady != this._balls.Count) // don't let the player launch until all balls are back.
            return;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;

        if (Input.GetMouseButtonDown(0))
        {
            this.StartDrag(worldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            this.ContinueDrag(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            this.EndDrag();
        }
    }


    private void EndDrag()
    {
        StartCoroutine(this.LaunchBalls());
    }


    private IEnumerator LaunchBalls()
    {
        Vector3 direction = this._endDragPosition - this._startDragPosition;
        direction.Normalize();

        foreach (var ball in this._balls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(0.1f);
        }

        this._ballsReady = 0;

    }   // LaunchBalls()


    private void ContinueDrag(Vector3 worldPosition)
    {
        this._endDragPosition = worldPosition;
        Vector3 direction     = this._endDragPosition - this._startDragPosition;

        this._launchPreview.SetEndPoint(transform.position - direction);
    }


    private void StartDrag(Vector3 worldPosition)
    {
        this._startDragPosition = worldPosition;

        this._launchPreview.SetStartPoint(transform.position);
    }


}   // class BallLauncher
