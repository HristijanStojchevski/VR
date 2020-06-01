# VIRTUAL REALITY
 All laboratory work for the course Virtual Reality on the Faculty of Computer Science and Engineering - Skopje.
 
 I will be working in Unity(v. 2017.4.*).
 
 The mini game/VR experience is located in a valley surrounded by mountains. The player needs to generate some balls and push them to different locations in the scene. Once all the balls are succesfully delivered he can enter a house and "win" before the time flies by. 
 I did all the coding myself and when I got stuck somewhere not nowing how all the objects, materials, sounds are build inside classes and their own methods I used the [Unity docs](https://docs.unity3d.com/ScriptReference/index.html), everything is really well documented and there is a big comunity on all the forums.
 
 For those that don't want to buy expensive headsets, you can get yourself [google cardboard](https://arvr.google.com/cardboard/get-cardboard/) or [build your own from home](https://www.youtube.com/watch?v=EHkOnsvpHiA).

## LAB 01 
  I set up Unity to develop for android using the Google Cardboard SDK(included in [Google VR SDK for Unity](https://developers.google.com/vr/develop/unity/get-started-android)). In my scene I included some GoogleVR assets like scripts (GvrEditorEmulator and GvrControllerMain) that help me mock the VR headset movements and controls inside Unity.
  
  I created the virtual environment with a simple scene, one cube object with a rigid body in order to test the gravity and possible user interaction.
  
  I set up a game object with a camera positioned in the height of an average person, then gave the player a character controller that is mocking a human movement. Here I also included a script and a mesh on the Main Camera(the eyes) who emit rays(invisible particles) and allow objects to be detected in the user reach that can be interacted with.
  
  I wrote a [script](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Game%20Play/Scipts/PlayerHeadTiltMovement.cs) on the Player object, which detects when the user head tilts down more than 25 degrees. That triggers the user moving forward in the direction he sees.
  
  There is a ball in the scene that the player can move around. For this to work, I used the reticle pointer, so when the ball is in reach of the player and he is looking at it, he can push the ball with a click on the cardboard control buttons. In code, when the reticle pointer is pointed towards the ball and a click is detected first the ball is rotated in the same position as the player(camera) and then a force is applied in order to move it forward.

References: - [Head movement tutorial](https://www.youtube.com/watch?v=kBTn2pGwZUk) , [Setup and interaction tutorial](https://www.youtube.com/watch?v=EAaoEe9ksyE)

## LAB 02
 I created another 3D scene for a menu. Inside the scene I replicated what I did in the first laboratory, so the player can look around and interact with head movements. I added buttons for entering the game, reading instrucions and exiting the game. The player activates a click on the button when is focusing on it for a couple of seconds. The feedback that the button is being pressed is done with a slider, so as the click "loads" the button background(slider) is filling with a darker toned color. I made that work with some lines of code that you can find in [MainMenu.cs](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Menu/MainMenu.cs).
 
 The start menu, pause menu and Game Over menu are all using the same scene. In the other laboratories I will dynamically change the scene information text, title and options depending on the situation the player is or has been.
 
 The player can pause the game with looking to the sky for 5sec. The pause menu is triggered through code similar as the movement is done. Game over will show up once the time for reaching the goal will pass. 
 
References: - [Creating Menu in Unity, Canvas tricks and tips, Changing scenes.](https://www.youtube.com/watch?v=zc8ac_qUXQY)

## LAB 03
 In these laboratory I added some extra objects in the scene. A ball generator and a portal. Then, after playing around with a couple of ideas, firsty I changed the way to interact with the ball to be with gazing/focusing on it. Now once the player reaches the distance needed for the reticle pointer to interact with the balls mesh renderer I am adding force on the ball so it could travel forward in the direction the player is looking( camera rotation). The force is raising with the time the player is focused on the ball, this helps the player discover different tehniques to overcome different situations and uneven terain. Check out this interesting [ball interaction](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Game%20Play/Scipts/PushAround.cs).
 
 Then, I added a "ball generator" that the player needs to approach so an option, activated with focus, that generates a ball will pop up( the button flashes a couple of times then stopes so the player could know that he succesfully generated a ball). When the first ball is generated a portal shows up on a random location where the player needs to deliver a ball. This ball generation is done with using a prefab that has the PushAround script and all properties so that every ball that gets generated is interactable. (every ball is generated on a random location so the player would need to search for it). The portal has a task to wait for a ball to activate his trigger then destroy that ball and move to a different location. This is the portal [script](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Game%20Play/Scipts/Portal.cs).
 
 Creating a prefab - Just move already build object to the assets area and a prefab will be saved. You can always do changes to the prefab and the material you are using for it.
 
References: - [Using triggers and colliders](https://www.youtube.com/watch?v=WFkbqdo2OI4&t=53s).

## LAB 04
 Adding audio-manager class and creating fully immersive 3D spatial audio.
 
 Firstly I learned the basics for audio in Unity. I played around with sound sources and the audio clips which are the actual sounds that you want to be played inside the app. After I got the idea of how everything works I added this interesting [audio-manager](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Scripts/AudioManager.cs) class which is a component, it holds a list of sounds, you can later use inside Unity and  will help you add sounds with an interface in a single point in your application. 
Every sound that the Audio Manager holds is object from the serializable class [Sound](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Scripts/Sound.cs). Here in a VR application I used this class for sounds that don't need to be 3D spatialized. The way to play a sound at a certain point in your application is calling the AudioManager static instance and just revoke the play method with the name of the sound needed.

Another tehnique I used is adding audio source objects to other game objects that will play sound once an interaction happens. Example of these are the sounds from the ball generator, the portal, the walking of the player. For increasing the player immersion these sound needs to be 3D spatialized. Google CardboardVR has the plugin needed to make this possible, but I used a third-party library because I like the results. In the video below you have the third-party Resonance Audio SDK explained and installed. After changing some audio settings to use the plugin from this SDK I then had the ability to add audio source to the game objects with a script from Resonance.
You need to make the audio source 3D and allow spatialization then you just need to add the clip to the audio source and you are set.
Inside code you have the option to play a sound after interaction or on the beggining of some scene just by creating AudioSource object inside the script, connecting it to your audio source irrelevant if it is done from Unity interface or inside code, then you can call Play and Stop methods from the audio source whenever you like. 

In this app I have resonance audio played all the time from the "ball generator" as the source so the player could always hear and locate the ball generator (You can also notice the Dopler effect happening). Other sound I have is by the player movement, everytime he initiates movement walking steps can be heard. Code example of playing this sound is inside [PlayerMovement script](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Game%20Play/Scipts/PlayerHeadTiltMovement.cs#L39).   

References: - [Making your own audio manager class](https://www.youtube.com/watch?v=6OT43pvUyfY) , [Add 3D audio](https://www.youtube.com/watch?v=M88jDVfu6-Q).

## LAB 05
 Finally for making this laboratory work an application with a start and end I had to add something to challenge the player and make him do some actions. This helps keep the player active and sets a challenge for him that he might invest some time in it, which is good for Ad Revenue if we are at some point adding ads and publishing the application to Google Play Store.
 
 I added a house which the player needs to enter in order to save himself, the idea was a really heavy storm created with a particle system, but I couldn't find time to add the storm to the app. The player has 5 min to enter the house and the timer is counting on the top right area of his eye sight. Once the timer reaches 10sec a creapy sound is played and if he is not in the house once the time reaches 0 he "loses", gets taken to the GameOver menu where he has the option to try again. He might try to enter the house immediately, just to find out that he needs to deliver balls to some locations. He searches for the ball generator and he might need some time to think about what is needed, or just needs to go to the rest room, looks up towards the sky to activate the pause menu and then when he is ready he can continue the experience.
 
 -In order to make this possible I used PlayerPrefs so I can store session data while changing scenes. Also, I created [PlayerPrefsX](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Scripts/PlayerPrefsX.cs) because that way we have the possibility to store Vector3, bools, Quaternions and the most important full Arrays. These classes helped changing the menu dynamically.
 
 -For the time, UI changes, goal checks, door locking/unlocking I created the [GamePlay](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Game%20Play/Scipts/GamePlay.cs) script. Also the "portal" and it's script which I explained in the LAB03 helps with increasing the score once a ball passes through it. When the goal is reached the player is notified that the house is unlocked and he can safely enter.
 
 We continue the story. When the player continues with his game he goes to generate some balls, he pushes the ball to different locations(Portals) and he increases the score. Eventually he reaches the goal, which is currently set to 3. Then he is in a rush to enter the house before the time ends. When he gets there and walks to the door, there is this [HouseManagement](https://github.com/HristijanStojchevski/VR/blob/master/VR-Lab_01/Assets/Game%20Play/Scipts/HouseManagement.cs) script on the house object that checks if the house is unlocked and "let's the player in", which actually takes the player to menu scene when he is appreciated and has the option to go again or exit.
 
References: - [Setting up timer](https://www.youtube.com/watch?v=x-C95TuQtf0), [Adding scoring system](https://www.youtube.com/watch?v=TAGZxRMloyU).
