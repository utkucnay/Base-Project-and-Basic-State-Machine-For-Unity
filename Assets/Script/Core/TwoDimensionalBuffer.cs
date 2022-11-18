using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public struct TwoDimensionalBuffer<T> where T: struct
{
    public int Count { get => _columnSize; }

    int []_count;
    int _size;
    int _columnSize;
    int _rowSize;
    T[] _datas;

    public static TwoDimensionalBuffer<T> Init(int rowSize, int columnSize) => new(rowSize, columnSize);

    public TwoDimensionalBuffer(int rowSize, int columnSize)
    {
        _size = rowSize * columnSize;
        _columnSize = columnSize;
        _rowSize = rowSize;
        _datas = new T[_size];
        _count = new int[_columnSize];
    }

    public void Push(T data, int column)
    {
        if (_count[column] < _size)
            _datas[_count[column]++] = data;
        else
            Utils.LogWarning("Buffer need capacity");
    }

    public T Pop(int column)
    {
        return _datas[_count[column]--];
    }

    public T Peek(int column)
    {
        return _datas[_count[column]];
    }

    public void Clear(int column)
    {
        _count[column] = 0;
    }

    public void ClearAll()
    {
        for (int i = 0; i < _columnSize; i++)
        {
            _count[_columnSize] = 0;
        }
    }

    public T this[int column, int row]
    {
        get
        {
            if (row < _count[column])
                return _datas[column * _rowSize + row];
            else
                throw new System.Exception("This index not found");
        }
    }
}
