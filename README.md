# pluto-apis-unity-demo
Demo of networked application using Pluto APIs for shared spatial system

## Purpose
Pluto's core software offering is the XRChat client. This client can be used to provide a social layer over other XR experiences, complete with avatars and voice chat. As part of this shared spatial experience, the client offers a shared coordinate system for users in the same chat session. This coordinate system can be used to make sure that spatial applications running during an XRChat session appear in the same place for all users. Information about the coordinate system can be accessed via a set of HTTP endpoints that ships with the client and runs locally. While these endpoints can be accessed directly, they can also be accessed in Unity by using some utility libraries, scripts, and prefabs from the [pluto-apis-unity](https://github.com/PlutoVR/pluto-apis-unity). This repo serves as an example of how to use these resources.

Directions on how to integrate the [pluto-apis-unity](https://github.com/PlutoVR/pluto-apis-unity) resources are available in that repo.

## About the app
Before running the app, make sure that you are running the chat client, that you are in a room with other users, and that you have your headset on and a virtual space visible.

This app allows multiple chat users to join the same spatial session and move a sphere around. To move the sphere, point at it with your controller. When the beam pointing forward from your controller turns blue, you are able to grab the sphere with the grab button. At this point, you can move your controller to move the sphere or press up or down on your thumbstick to move the sphere closer to or further from your controller. As you move the sphere, all users should see the sphere's position accurately updated. When you release the grip button, the sphere should remain in place.

Note that there are currently no restrictions on two people attempting to grab the sphere; that case has not been tested. Wackiness may ensue.

## Running the example
This repo is currently built using Unity 2021.3.31f1, but it has been tested in 2022.3.12f1.

### Configuring networking (Croquet)
This example uses [Croquet for Unity](https://github.com/croquet/croquet-for-unity-package). As such, you'll need your own API key to run the demo. A free developer key is available with registration at https://croquet.io/.

Once you have a key, locate the `CroquetSettings` file in `Assets/Settings`. There's an `Api Key` field on that settings asset where you can insert your key.

The `RoomManager` GameObject at the top level of the hierarchy has a field for a Room Name. If you wish to run separate demo sessions of this app, you can make separate builds with different values in this field, but it isn't strictly necessary.

## Files of note
There is a `CroquetReparenter` that is responsible for making sure that the sphere is in the proper place in the hierarchy. Croquet defaults to instantiating view GameObjects for the actors in its data model at the top level of the hierarchy. If this is not a constraint of your networking setup (i.e. you can create objects in the proper part of the hierarchy in the first place), there's no need for an equivalent file in your own project.

Similarly, the `CroquetDraggable` that is on the instantiated sphere is an artifact of the setup of this particular project. It may be of interest if you're also using Croquet, but we make no assertions about it being any kind of best practice for dragging around views in Croquet for Unity projects.
