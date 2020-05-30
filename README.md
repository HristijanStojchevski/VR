# VR
 All laboratory work for the course Virtual Reality. I will be working in Unity(v. 2017.4.*).
 I did all the coding myself and when I got stuck somewhere not nowing how all the objects, materials, sounds are build inside classes and their own methods I used the [Unity docs](https://docs.unity3d.com/ScriptReference/index.html), everything is really well documented and there is a big comunity on all the forums.  
 For those that don't want to buy expensive headsets, you can get yourself [google cardboard](https://arvr.google.com/cardboard/get-cardboard/) or [build your own from home](https://www.youtube.com/watch?v=EHkOnsvpHiA).

## LAB 01 
  I set up Unity to develop for android using the Google Cardboard SDK(included in [Google VR SDK for Unity](https://developers.google.com/vr/develop/unity/get-started-android)). In my scene I included some GoogleVR assets like scripts (GvrEditorEmulator and GvrControllerMain) that help me mock the VR headset movements and controls inside Unity.
  
  I created the virtual environment with a simple scene, one cube object with a rigid body in order to test the gravity and possible user interaction.
  
  I set up a game object with a camera positioned in the height of an average person, then gave the player a character controller that is mocking a human movement. Here I also included a script and a mesh on the Main Camera(the eyes) who emit rays(invisible particles) and allow objects to be detected in the user reach that can be interacted with.
  
  I wrote a script on the Player object, which detects when the user head tilts down more than 25 degrees. That triggers the user moving forward in the direction he sees.
  
  There is a ball in the scene that the player can move around. For this to work, I used the reticle pointer, so when the ball is in reach of the player and he is looking at it, he can push the ball with a click on the cardboard control buttons. In code, when the reticle pointer is pointed towards the ball and a click is detected first the ball is rotated in the same position as the player(camera) and then a force i applied in order to move it forward.

References: - [Head movement tutorial](https://www.youtube.com/watch?v=kBTn2pGwZUk) , [Setup and interaction tutorial](https://www.youtube.com/watch?v=EAaoEe9ksyE)

## LAB 02
 I created another 3D scene for a menu. Inside the scene I replicated what I did in the first laboratory, so the player can look around and interact with head movements. I added buttons for entering the game, reading instrucions and exiting the game. The player activates a click on the button when is focusing on it for a couple of seconds. The feedback that the button is being pressed is done with a slider, so as the click "loads" the button background(slider) is filling with a darker toned color. I made that work with some lines of code that you can find in [MainMenu.cs](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Menu/MainMenu.cs).
 
References: - [Creating Menu in Unity, Canvas tricks and tips.](https://www.youtube.com/watch?v=zc8ac_qUXQY)

## LAB 03

References: - [Creating Menu in Unity, Canvas tricks and tips.](https://www.youtube.com/watch?v=zc8ac_qUXQY)

## LAB 04

References: - [Making your own audio manager class.](https://www.youtube.com/watch?v=6OT43pvUyfY) , [Add 3D audio.](https://www.youtube.com/watch?v=M88jDVfu6-Q)

## LAB 05

References: - [Creating Menu in Unity, Canvas tricks and tips.](https://www.youtube.com/watch?v=zc8ac_qUXQY)
