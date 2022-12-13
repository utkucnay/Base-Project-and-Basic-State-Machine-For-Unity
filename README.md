# Base Project and Basic AI System For Unity
 I made Base Project for all Unity Games

# Observer Setup
The observer setup uses a ReciverMonoBehaviour for listeners. If we disable the MonoBehaviour, the remove event is enabled. Objects that will listen must inherit the ReciverMonoBehaviour. We also have a helper static class called Observer, which registers all event systems for transforms, roots, or all game objects.

# ObjectPool
The object pool system has a basic object pool that can be filled with objects of the ObjectType enum.

# Singleton
The singleton class does what its name suggests.

# Command
The command system allows the creation of commands, such as move or timer, and holds a command queue.

# Basic State Machine (HFSM)
The basic state machine (HFSM) allows the creation of states and transitions, similar to the Unity animation system.

# Unit Test
Unit tests have been implemented and all tests pass.
