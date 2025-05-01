# Escape to Psyche
Escape to Psyche is a virtual reality escape room set during a futuristic mission to the asteroid Psyche. Developed for play at public Psyche events, it immerses players in a fun and interactive space environment while they explore and learn more about the original Psyche mission. The game uses simple and intuitive controls to introduce players of all ages and familiarity to the world of virtual reality.

The gameplay has a countdown of three minutes and starts players off in a Psyche-inspired futuristic spaceship, and they must initiate the landing sequence in order to succeed. To do this, the player navigates through a series of puzzles, interacts with models, and finds a code in order to fix the malfunctioning electricity and hit the land button. This project was developed using Unity, C#, and Blender for custom assets.

## Team
This game was created for VCU's capstone project CS 25-321.
Team members:
* Ava Shilling
* Akshara Rajesh
* Peter Nguyen
* Quinton Jones

## Installation
There are a few options for downloading the game onto your VR headset.

### Download apk file
For Meta Quest:
Download the apk file "EscapeToPsycheFinal.apk" from the Builds folder, then use SideQuest to transfer the file onto your headset. 

> SideQuest can be downloaded from [this site](https://sidequestvr.com/setup-howto). Your headset must be in developer mode, as explained [here](https://developers.meta.com/horizon/documentation/native/android/mobile-device-setup/), and then you must plug in your device and allow USB debugging in the headset when prompted. After all this is setup, you can use SideQuest to download the APK

 Once the apk file is downloaded, navigate to the "unknown sources" tab in your VR app section, and find the game. Click on it to play!

 ### Build and Run from Unity Editor

 If you don't have sidequest or want to edit the game before playing, you can also build the game and run it yourself. This is only easier if you already have Unity version 2022.3.42f1 downloaded, so we'll assume that's set up already. Make sure to also have downloaded the Android Build Module for this version of Unity.
 > Once the project is open in Unity Editor, navigate to the Build settings (CTRL-Shift-b), make sure the android tab is selected, and do the same steps listed above (developer mode enabled and USB debugging allowed), then hit "Refresh" and select your device under "Run Device". Then, click "Build And Run" and wait for the project to build, it should automatically download and run on your headset as well

## Changing timer settings

To change the gameplay time for different settings, open the project and navigate to the "Assets/Game Scripts" folder. Inside "Countdown" there is a variable called "totalTime", currently set to 180f, as in 180 seconds or 3 minutes. To give more or less time, change this number to the amount of seconds you'd prefer.

