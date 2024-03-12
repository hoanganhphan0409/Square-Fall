using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] BadSquare badSquareObjectToPool;
    [SerializeField] int amountBadSquareToPool;
    [SerializeField] GoodSquare goodSquareObjectToPool;
    [SerializeField] int amountGoodSquareToPool;
    private List<BadSquare> _badSquarePooledObjects; 
    private List<GoodSquare> _goodSquarePooledObjects; 
    void Start()
    {
        SetupPool();
    }

    void SetupPool()
    {
        _badSquarePooledObjects = new List<BadSquare>();
        for(int i = 0; i < amountBadSquareToPool; i++)
        {
            var tmp = Instantiate(badSquareObjectToPool);
            tmp.gameObject.SetActive(false);
            _badSquarePooledObjects.Add(tmp);
        }
        _goodSquarePooledObjects = new List<GoodSquare>();
        for(int i = 0; i < amountGoodSquareToPool; i++)
        {
            var tmp = Instantiate(goodSquareObjectToPool);
            tmp.gameObject.SetActive(false);
            _goodSquarePooledObjects.Add(tmp);
        }
    }
    public BadSquare GetPooledBadSquare()
    {
        for(int i = 0; i < amountBadSquareToPool; i++)
        {
            if(!_badSquarePooledObjects[i].gameObject.activeInHierarchy)
            {
                _badSquarePooledObjects[i].gameObject.SetActive(true);
                return _badSquarePooledObjects[i];
            }
        }
        var tmp = Instantiate(badSquareObjectToPool);
        tmp.gameObject.SetActive(true);
        _badSquarePooledObjects.Add(tmp);
        amountBadSquareToPool++;
        return tmp;
    }
    public GoodSquare GetPooledGoodSquare()
    {
        for(int i = 0; i < amountGoodSquareToPool; i++)
        {
            if(!_goodSquarePooledObjects[i].gameObject.activeInHierarchy)
            {
                _goodSquarePooledObjects[i].gameObject.SetActive(true);
                return _goodSquarePooledObjects[i];
            }
        }
        var tmp = Instantiate(goodSquareObjectToPool);
        tmp.gameObject.SetActive(true);
        _goodSquarePooledObjects.Add(tmp);
        amountGoodSquareToPool++;
        return tmp;
    }

    public void OnLoseGame()
    {
        foreach (var square in _badSquarePooledObjects)
        {
            square.DOKill();
            square.gameObject.SetActive(false);
        }
        foreach (var square in _goodSquarePooledObjects)
        {
            square.DOKill();
            square.gameObject.SetActive(false);
        }
    }
}
