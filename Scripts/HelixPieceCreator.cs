using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixPieceCreator : MonoBehaviour
{
    private const int PIECE_COUNT = 12;

    private GameObject _piecePrefab;
    private GameObject _deadPiecePrefab;
    private Transform _downTransform;

    private List<GameObject> _pieceList = new List<GameObject>();

    public bool IsStartPiece;

    private void OnEnable()
    {
        MoveController.Move += Move;
    }

    private void OnDisable()
    {
        MoveController.Move -= Move;
    }

    private void Start()
    {
        _piecePrefab = Resources.Load<GameObject>("PiecePrefab");
        _deadPiecePrefab = Resources.Load<GameObject>("DeadPiecePrefab");
        _downTransform = GameObject.FindGameObjectWithTag("Down").transform;

        if (!IsStartPiece)
        {
            CreatePieces();
            //Random angle for helix
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 180f), 0);
        }
    }

    private void Move()
    {
        if (!Ball.IsGameOver)
        {
            transform.Rotate(Vector3.up, -Input.GetAxis("Mouse X") * 10f, Space.World);
        }
    }

    private void CreatePieces()
    {
        float zAngeValue = 0;

        //Create all piece
        for (int i = 0; i < PIECE_COUNT; i++)
        {
            GameObject piece = Instantiate(_piecePrefab, transform, false);
            piece.transform.rotation = Quaternion.Euler(90f, 0, zAngeValue);
            zAngeValue += 30f;
            _pieceList.Add(piece);
        }
        //Remove extra piece
        RemovePiece(Random.Range(0, 5));
    }

    private void RemovePiece(int value)
    {
        switch (value)
        {
            //Remove 2 piece
            case 0:
                for (int i = 0; i < 2; i++)
                {
                    Destroy(_pieceList[i]);
                }
                break;

            //Remove 4 piece
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    Destroy(_pieceList[i]);
                }
                break;

            //Remove 6 piece
            case 2:
                for (int i = 0; i < 6; i++)
                {
                    Destroy(_pieceList[i]);
                }
                break;

            //Remove "triangle" piece
            case 3:
                Destroy(_pieceList[0]);
                Destroy(_pieceList[1]);
                Destroy(_pieceList[4]);
                Destroy(_pieceList[5]);
                Destroy(_pieceList[8]);
                Destroy(_pieceList[9]);
                break;

            //Remove 3 parallel piece
            case 4:
                Destroy(_pieceList[0]);
                Destroy(_pieceList[1]);
                Destroy(_pieceList[2]);
                Destroy(_pieceList[6]);
                Destroy(_pieceList[7]);
                Destroy(_pieceList[8]);
                break;
        }

        CreateDeadPice();
    }

    private void CreateDeadPice()
    {
        //Create dead piece
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            GameObject deadPiece = Instantiate(_deadPiecePrefab, transform, false);
            deadPiece.transform.rotation = Quaternion.Euler(90f, 0, (Random.Range(0, 12) * 30f));
        }
    }

    private void DestroyAllPieces()
    {
        foreach (Transform child in transform)
        {
            _pieceList.Clear();
            Destroy(child.gameObject);
        }
    }

    public void ResetNewPiece()
    {
        DestroyAllPieces();
        transform.position = _downTransform.position;
        CreatePieces();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Up")
        {
            ResetNewPiece();
        }
    }
}
