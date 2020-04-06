# VR
 All laboratory work for the course Virtual Reality. I will be working in Unity(v. 2017.4.*).

## LAB 01 
  I set up Unity to develop for android using the Google Cardboard SDK(included in [Google VR SDK for Unity](https://developers.google.com/vr/develop/unity/get-started-android)). In my scene I included some GoogleVR assets like scripts (GvrEditorEmulator and GvrControllerMain) that help me mock the VR headset movements and controls inside Unity.
  
  I created the virtual environment with a simple scene, one cube object with a rigid body in order to test the gravity and possible user interaction.
  
  I set up a game object with a camera positioned in the height of an average person, then gave the player a character controller that is mocking a human movement. Here I also included a script and a mesh on the Main Camera(the eyes) who emit rays(invisible particles) and allow objects to be detected in the user reach that later can be interacted with.
  
  I wrote a script on the Player object, which detects when the user head tilts down more than 25 degrees. That triggers the user moving forward in the direction he sees.

References: - [Head movement tutorial](https://www.youtube.com/watch?v=kBTn2pGwZUk) , [Setup and interaction tutorial](https://www.youtube.com/watch?v=EAaoEe9ksyE)
