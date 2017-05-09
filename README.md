# Bunker_Warfare
A dual-stick shooter created using Unity3D and C# in under 72 hours for Iowa State University's HackISU.

To play the game:  
-Control the player using the W,S,A,D keys to move  
-Aim the player's weapon using the mouse, and left-click to fire  
-Shoot the enemies and survive earning as much score as you can  

This project was developed in Unity3D, and scripted in C#. Most of the models including the map were designed in Google SketchUp.
Enemies spawn at a constant randomly across several predetermined positions around the map.

The enemies have AI, and will always target and move towards the player's current position. the player's position is global knowledge
to all enemies. The player can combat enemies by shooting their weapon's projectiles at the enemies. Each enemy takes 3-4 hits to be defeated.

The player is damaged by the enemies when they get too close to the player. 
Each time the player takes damage, they lose a portion of their health. When the player's health reaches zero, the game ends.

