using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

 public struct Buffer<T> where T : struct
{
    public int Count { get => _count; }

    int _count;
    int _size;
    T []_datas;

    public static Buffer<T> Init(int size) => new(size);

    public Buffer(int size)
    {
        _size = size;
        _datas = new T[_size];
        _count = 0;
    }

    public void Push(T data)
    {
        if (_count < _size)
            _datas[_count++] = data;
        else
            Utils.LogWarning("Buffer need capacity");
    }

    public T Pop() 
    {
        return _datas[--_count];
    }

    public T Peek()
    {
        return _datas[_count - 1];
    }

    public void Clear()
    {
        _count = 0;
    }

    public bool Contains(T data)
    {
        for(int i = 0; i < _count; i++)
        {
            if(data.Equals(_datas[i])) return true;
        }
        return false;
    }

    public T this[int i]
    {
        get 
        {
            if (i < _count)
                return _datas[i];
            else
                throw new System.Exception("This index not found");
        }
        set 
        {
            if (i < _count)
                _datas[i] = value;
            else
                throw new System.Exception("This index not found");
        }
    }
}
