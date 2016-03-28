# xplode
basic project for Unity 5.x workshops.
For more informations contact me `@ilwoody`

#### Live link

http://nferruzzi.github.io/xplode/Builds/webgl/

### Abstract
xplode is a classic endless vertical shooter created to demonstrate the power of Unity3D as a fast prototyping tool; no previous knowledges in game programming are required.

### Main goal
the goal of the workshop is building a game from scratch to become familiar with the following concepts:

#### 1st day
1. the workspace: unity editor, layouts, manipulators, C# debugger and sources revision control for Unity with common tools (ie git)
1. GameObject hierarchy, Layers and Tags
1. MonoBehaviour and componets (ie. functions Start, Update, GetComponent, public variables)
1. Transform and Time classes
1. Prefabs and assets management
1. Creations and destruction of objects at runtime
1. Inspector and serialization of custom class
1. Use of gizmos to draw information on screen

#### 2nd day
1. Collisions and rigid bodies
1. C# interfaces
1. Invoke, InvokeRepeating and coroutines
1. Unity editor scripts
1. Game UI and scene management

### The architecture of an endless shooter

TODO.

### How to

The game can be customized in several ways

#### Add a new enemy

See `BaseEnemy.cs` and Prefab `Cubo Nemico`.

1. create a GameObject and call it as you wish
1. set the Layer to "Enemies"
1. add Mesh, Collider, RigidBody
1. tweak your RigidBody properties (e. fix Y)
1. add `WeaponGun` component if it fires from a single weapon or `WeaponController` if it has more than one
1. on its Start method, get a spawning location from the `Spawner` instance.
1. schedule it's behaviour according to your own logic
1. add method `OnCollisionEnter`

```Unity3D
void OnCollisionEnter(Collision collision) {
  Proiettile pro = collision.gameObject.GetComponentInChildren<Proiettile> ();
  if (pro == null) return;
  energy -= pro.damage;

  foreach (ContactPoint contact in collision.contacts) {
    pro.ShowExplosionAt (contact.point, contact.normal);
  }

  if (energy <= 0.0f) {
    Destroy (this.gameObject);
  }
}
```

#### Add a new weapon
See `WeaponGun.cs` and Prefab `PlayerBaseGun`

TODO.

#### Add a new bullet
See `Proiettile.cs` and Prefabs `Bullet` or `EnemyBullet`

TODO.

#### Generate a random level
See `LevelRandomGenerator.cs`

TODO.

### Components

```
Spawner
```

It is used to create a boundary of `MainCamera` visible area so enemies or the game logic can take it in account.

The boundary is formed by 4 `Vector3d`  calculated according to the camera frustum, the camera aspect ration and the player "y" coordinate.

The spawning point are stored in 3 arrays

`spawnLocationsTop`, `spawnLocationsLeft`, `spawnLocationsRight`

and ca be queried at runtime using

`Spawner.GetInstance()`

---

```
WeaponController
```

It is used to store multiple weapons and fire them all together.

---

```
LevelRandomGenerator
```

Very simple level generator, it is used to spawn enemeies with a regular frequency.

### Interfaces

```
IWeaponInterface
```
See `WeaponGun.cs`

---
```
IProjectileInterface
```
See `Proiettile.cs`
