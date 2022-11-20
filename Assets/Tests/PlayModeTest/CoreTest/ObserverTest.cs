using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;
using static System.Collections.Specialized.BitVector32;

public class ObserverTest 
{
    [UnityTest]
    public IEnumerator ObserverForSameTransformTest()
    {
        var go = new GameObject();
        go.SetActive(false);
        var objObserver = go.AddComponent<TestObserverForTransformClass>();
        objObserver.SetActionWithTransform(Observer.RegisterEventFromTransform<ITest>);
        var objReciver = go.AddComponent<TestReciverClass>();
        yield return null;
        go.SetActive(true);
        yield return null;
        objObserver.RunTestEvent();
        Assert.AreEqual(true, objReciver._run);
        GameObject.Destroy(go);
    }

    [UnityTest]
    public IEnumerator ObserverForSameRootTest()
    {
        var go = new GameObject();
        var goChild = new GameObject();
        goChild.transform.parent = go.transform;

        go.SetActive(false);

        var objObserver = go.AddComponent<TestObserverForTransformClass>();
        objObserver.SetActionWithTransform(Observer.RegisterEventFromRoot<ITest>);
        var objReciver = goChild.AddComponent<TestReciverClass>();
        yield return null;

        go.SetActive(true);

        yield return null;
        objObserver.RunTestEvent();
        Assert.AreEqual(true, objReciver._run);
        GameObject.Destroy(goChild);
        GameObject.Destroy(go);
    }

    [UnityTest]
    public IEnumerator ObserverForDifferentGOTest()
    {
        var goObserver = new GameObject();
        var goReciver = new GameObject();

        goObserver.SetActive(false);
        goReciver.SetActive(false);

        var objObserver = goObserver.AddComponent<TestObserverForTransformClass>();
        objObserver.SetActionWithOutTransform(Observer.RegisterEventFromAllGameObjects<ITest>);
        var objReciver = goReciver.AddComponent<TestReciverClass>();
        yield return null;

        goReciver.SetActive(true);
        goObserver.SetActive(true);

        yield return null;
        objObserver.RunTestEvent();

        Assert.AreEqual(true, objReciver._run);
        GameObject.Destroy(goReciver);
        GameObject.Destroy(goObserver);
    }

    [UnityTest]
    public IEnumerator ObserverForSameTransformWithParamTest()
    {
        var go = new GameObject();
        go.SetActive(false);
        var objObserver = go.AddComponent<TestObserverForTransformWithParamClass>();
        objObserver.SetActionWithTransform(Observer.RegisterEventFromTransform<ITestWithParam, bool>);
        var objReciver = go.AddComponent<TestReciverWithParamClass>();
        yield return null;
        go.SetActive(true);
        yield return null;
        objObserver.RunTestEvent(true);
        Assert.AreEqual(true, objReciver._run);
        GameObject.Destroy(go);
    }

    [UnityTest]
    public IEnumerator ObserverForSameRootWithParamTest()
    {
        var go = new GameObject();
        var goChild = new GameObject();
        goChild.transform.parent = go.transform;

        go.SetActive(false);

        var objObserver = go.AddComponent<TestObserverForTransformWithParamClass>();
        objObserver.SetActionWithTransform(Observer.RegisterEventFromRoot<ITestWithParam, bool>);
        var objReciver = goChild.AddComponent<TestReciverWithParamClass>();
        yield return null;

        go.SetActive(true);

        yield return null;
        objObserver.RunTestEvent(true);
        Assert.AreEqual(true, objReciver._run);
        GameObject.Destroy(goChild);
        GameObject.Destroy(go);
    }

    [UnityTest]
    public IEnumerator ObserverForDifferentGOWithParamTest()
    {
        var goObserver = new GameObject();
        var goReciver = new GameObject();

        goObserver.SetActive(false);
        goReciver.SetActive(false);

        var objObserver = goObserver.AddComponent<TestObserverForTransformWithParamClass>();
        objObserver.SetActionWithOutTransform(Observer.RegisterEventFromAllGameObjects<ITestWithParam, bool>);
        var objReciver = goReciver.AddComponent<TestReciverWithParamClass>();
        yield return null;

        goReciver.SetActive(true);
        goObserver.SetActive(true);

        yield return null;
        objObserver.RunTestEvent(true);

        Assert.AreEqual(true, objReciver._run);
        GameObject.Destroy(goReciver);
        GameObject.Destroy(goObserver);
    }
}

class TestObserverForTransformClass : MonoBehaviour
{
    UnityEvent _testEvent;
    Action<Transform, string, UnityEvent> _actionWithTransform;
    Action<string, UnityEvent> _actionWithOutTransform;

    public void SetActionWithTransform(Action<Transform, string, UnityEvent> action) => _actionWithTransform = action;

    public void SetActionWithOutTransform(Action<string, UnityEvent> action) => _actionWithOutTransform = action;

    private void Awake()
    {
        _testEvent = new();
        _actionWithTransform?.Invoke(this.transform, "Test", _testEvent);
        _actionWithOutTransform?.Invoke("Test", _testEvent);
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

    Action<Transform, string, UnityEvent<bool>> _actionWithTransform;
    Action<string, UnityEvent<bool>> _actionWithOutTransform;

    public void SetActionWithTransform(Action<Transform, string, UnityEvent<bool>> action) => _actionWithTransform = action;

    public void SetActionWithOutTransform(Action<string, UnityEvent<bool>> action) => _actionWithOutTransform = action;

    private void Awake()
    {
        _testEvent = new();
        _actionWithTransform?.Invoke(this.transform, "Test", _testEvent);
        _actionWithOutTransform?.Invoke("Test", _testEvent);
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