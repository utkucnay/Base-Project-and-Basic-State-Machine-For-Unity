using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BufferTests
{
    [Test]
    public void BufferPushTest()
    {
        Buffer<int> buffer = Buffer<int>.Init(20);
        buffer.Push(20);
        Assert.AreEqual(1, buffer.Count);
    }

    [Test]
    public void BufferPeekTest()
    {
        Buffer<int> buffer = Buffer<int>.Init(20);
        buffer.Push(20);
        Assert.AreEqual(20, buffer.Peek());
    }

    [Test]
    public void BufferPopTest()
    {
        Buffer<int> buffer = Buffer<int>.Init(20);
        buffer.Push(20);
        Assert.AreEqual(20, buffer.Pop());
    }

    [Test]
    public void BufferCountTest()
    {
        Buffer<int> buffer = Buffer<int>.Init(20);
        buffer.Push(20);
        buffer.Push(10);
        buffer.Push(30);
        buffer.Pop();
        buffer.Peek();
        Assert.AreEqual(2, buffer.Count);
    }

    [Test]
    public void BufferClearTest()
    {
        Buffer<int> buffer = Buffer<int>.Init(20);
        buffer.Push(20);
        buffer.Push(10);
        buffer.Push(30);
        buffer.Clear();
        Assert.AreEqual(0, buffer.Count);
    }

    [Test]
    public void BufferContainTest()
    {
        Buffer<int> buffer = Buffer<int>.Init(20);
        buffer.Push(20);
        buffer.Push(10);
        buffer.Push(30);
        Assert.AreEqual(true, buffer.Contains(10));
        Assert.AreEqual(false, buffer.Contains(11));
    }

    [Test]
    public void GenericBufferTest()
    {
        Buffer<int> buffer = Buffer<int>.Init(20);
        buffer.Push(0);
        buffer.Push(10);
        buffer.Push(20);
        for (int i = 0; i < buffer.Count; i++)
        {
            Assert.AreEqual(10 * i, buffer[i]);
        }
    }
}
