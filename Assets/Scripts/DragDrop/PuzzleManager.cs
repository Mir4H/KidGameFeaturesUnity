using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;
    [SerializeField] private Transform _slotParent, _pieceParent;
    private List<PuzzlePiece> _pieces = new List<PuzzlePiece>();


    private void Start()
    {
        Spawn();
    }

    private void FixedUpdate()
    {
        if (_pieces.All(piece => piece.placed == true))
        {
            Debug.Log("done");
        }
    }

    void Spawn()
    {
        var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(3).ToList();
        for (int i = 0; i < randomSet.Count; i++)
        {
            var spawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity);
            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
            _pieces.Add(spawnedPiece);
            spawnedPiece.Init(spawnedSlot);
        }
    }
}
