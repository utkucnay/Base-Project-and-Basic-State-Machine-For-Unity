using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;

public class ObserverTest 
{
    [UnityTest]
    public IEnumerator ObserverForSameTransformTest()
    {
        var go = new GameObject();
        go.SetActive(false);
        var objObserver = go.AddComponent<TestObserverForTransformClass>();
        var objReciver = go.AddComponent<TestReciverClass>();
        yield return null;
        go.SetActive(true);
        yield return null;
        objObserver.RunTestEvent();
        Assert.AreEqual(true, objReciver._run);
        GameObject.Destroy(go);
    }

    [UnityTest]
    public IEnumerator ObserverForSameTransformWithParamTest()
    {
        var go = new GameObject();
        go.SetActive(false);
        var objObserver = go.AddComponent<TestObserverForTransformWithParamClass>();
        var objReciver = go.AddComponent<TestReciverWithParamClass>();
        yield return null;
        go.SetActive(true);
        yield return null;
        objObserver.RunTestEvent(true);
        Assert.AreEqual(true, objReciver._run);
        GameObject.Destroy(go);
    }
}

class TestObserverForTransformClass : MonoBehaviour
{
    UnityEvent _testEvent;

    private void Awake()
    {
        _testEvent = new();
        Observer.RegisterEventFromTransform<ITest>(this.transform, "Test", _testEvent);
    }

    public void RunTestEvent() => _testEvent.Invoke(); 
}

class TestReciverClass : ReciverMonoBehaviour, ITest
{
    internal bool _run = false;
    public void Test()
    {
        _run = true;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }
}

interface ITest : IEvent
{
    public void Test();
}


class TestObserverForTransformWithParamClass : MonoBehaviour
{
    UnityEvent<bool> _testEvent;

    private void Awake()
    {
        _testEvent = new();
        Observer.RegisterEventFromTransform<ITestWithParam, bool>(this.transform, "Test", _testEvent);
    }

    public void RunTestEvent(bool test) => _testEvent.Invoke(test);
}

class TestReciverWithParamClass : ReciverMonoBehaviour, ITestWithParam
{
    internal bool _run = false;
    public void Test(bool test)
    {
        _run = test;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }
}

interface ITestWithParam : IEventWithParam
{
    public void Test(bool test);
}