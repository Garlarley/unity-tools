# unity-tools
It contains some useful tools for unity that I think could be re-used. 

# Global/MDSingleton

The MDSingleton class is a Unity framework utility designed to facilitate the creation and management of Singleton objects within a Unity scene. A Singleton is a design pattern that ensures there is only one instance of a particular class in the application at any given time. This pattern is often used for manager or controller classes to ensure they have a single point of access throughout the application's lifecycle.

Key Features and Usage:
Singleton Pattern Implementation: The MDSingleton class enforces the Singleton pattern for Unity components by restricting the instantiation of more than one instance of a specified component type (T) within the Unity scene.
Instance Access: The class provides a static property called Instance, which allows easy access to the Singleton instance of the specified type. If an instance does not exist and the CreateIfNone property is set to true, it will create an instance when requested.
Control Over Instance Creation: The CreateIfNone property is a boolean toggle that determines whether an instance should be automatically created when accessed via the Instance property. If set to true, an instance is created if none exists; if set to false, it behaves as a traditional Singleton, only allowing access to an existing instance.
Instance Destruction: The class also provides a DestroyInstance method, allowing you to explicitly destroy the Singleton instance when it's no longer needed.
Lifecycle Events: Developers can override two virtual methods, OnInstanceCreated and OnInstanceDestroyed, to execute custom code when the Singleton instance is created or destroyed, respectively.

Overall, the MDSingleton class simplifies the management of Singleton objects within Unity projects, offering flexibility in instance creation while adhering to best practices in design patterns. It is particularly useful for ensuring the uniqueness and controlled access of critical components within a Unity application.
