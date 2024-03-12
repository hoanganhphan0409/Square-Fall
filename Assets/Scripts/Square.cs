using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Square : MonoBehaviour
{
    [SerializeField] private float maxRangeXToSpawn;
    [SerializeField] private float minRangeXToSpawn;
    [SerializeField] private float valueYToSpawn;
    [SerializeField] private float valueYToDissapear;
    [SerializeField] private float maxRangeXToMove;
    [SerializeField] private float minRangeXToMove;
    [SerializeField] private float durationMove;
    private Vector2 _startPos;
    private Vector3 _startScale = new Vector3(1,1,1);

    void SetupStartPos()
    {
        float startPosX = Random.Range(minRangeXToSpawn, maxRangeXToSpawn);
        transform.position = new Vector2(startPosX, valueYToSpawn);
        _startPos = transform.position;
    }

    public void StartFall()
    { 
        SetupStartPos();
        transform.localScale = _startScale;
        float posXToFall = Random.Range(minRangeXToMove, maxRangeXToMove);
        Vector2 posToFallOnSlider = new Vector2(posXToFall, 0);
        Vector2 endPos = FindPointCOnLine(_startPos, posToFallOnSlider, valueYToDissapear);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(endPos, durationMove).OnComplete(
            () => transform.DOScale(new Vector3(0, 0, 0), .5f)
                .OnComplete(() => gameObject.SetActive(false))));
        sequence.Join(transform.DORotate(new Vector3(0f, 0, 360f), durationMove, RotateMode.FastBeyond360)
            .SetSpeedBased(true)
            .SetLoops(-1));
    }
    Vector2 FindPointCOnLine(Vector2 point1, Vector2 point2, float yCoordinate)
    {
        float slopeAB = (point2.y - point1.y) / (point2.x - point1.x);
        float xCoordinateC = (yCoordinate - point1.y) / slopeAB + point1.x;
        return new Vector2(xCoordinateC, yCoordinate);
    }
}




