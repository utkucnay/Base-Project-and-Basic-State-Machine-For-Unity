using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TwoDimBufferTests
{
    [Test]
    public void TwoDimBufferPushTest()
    {
        TwoDimensionalBuffer<int> buffer = TwoDimensionalBuffer<int>.Init(20, 20);
        buffer.Push(10,0);
        Assert.AreEqual(1, buffer.Count(0));
        buffer.Push(1, 4);
        Assert.AreEqual(1, buffer.Count(4));
        Assert.AreEqual(0, buffer.Count(3));
    }

    [Test]
    public void TwoDimBufferPeekTest()
    {
        TwoDimensionalBuffer<int> buffer = TwoDimensionalBuffer<int>.Init(20, 20);
        buffer.Push(20, 0);
        Assert.AreEqual(20, buffer.Peek(0));
        buffer.Push(10, 3);
        Assert.AreEqual(10, buffer.Peek(3));
    }

    [Test]
    public void TwoDimBufferPopTest()
    {
        TwoDimensionalBuffer<int> buffer = TwoDimensionalBuffer<int>.Init(20, 20);
        buffer.Push(20, 0);
        Assert.AreEqual(20, buffer.Pop(0));
    }

    [Test]
    public void TwoDimBufferCountTest()
    {
        TwoDimensionalBuffer<int> buffer = TwoDimensionalBuffer<int>.Init(20, 20);
        buffer.Push(20, 0);
        buffer.Push(10, 0);
        buffer.Push(30, 1);
        buffer.Pop(0);
        buffer.Peek(1);
        Assert.AreEqual(1, buffer.Count(0));
        Assert.AreEqual(1, buffer.Count(1));
    }

    [Test]
    public void TwoDimBufferClearTest()
    {
        TwoDimensionalBuffer<int> buffer = TwoDimensionalBuffer<int>.Init(20, 20);
        buffer.Push(20, 0);
        buffer.Push(10, 0);
        buffer.Push(30, 0);
        buffer.Clear(0);
        Assert.AreEqual(0, buffer.Count(0));
    }

    //[Test]
    //public void TwoDimBufferContainTest()
    //{
        // TO DO  
    //}

    [Test]
    public void TwoDimGenericBufferTest()
    {
        TwoDimensionalBuffer<int> buffer = TwoDimensionalBuffer<int>.Init(20, 20);
        buffer.Push(0, 0);
        buffer.Push(10, 0);
        buffer.Push(20, 0);
        buffer.Push(0, 1);
        for (int i = 0; i < buffer.Count(0); i++)
        {
            Assert.AreEqual(10 * i, buffer[0,i]);
        }
        for (int i = 0; i < buffer.Count(1); i++)
        {
            Assert.AreEqual(10 * i, buffer[0, i]);
        }
    }
}
