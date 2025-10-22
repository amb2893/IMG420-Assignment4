# IMG420 - Assignment 4 Operation Save Lemmy 

A small but refined 2d platformer built with **Godot**.  
Your goal: Reach your pet mouse Lemmy without falling or hitting the evil fly  



## How to Play  
- **Movement** Use the **Arrow Keys** (← →) to move .  
- **Jumping**  Press **Spacebar** to jump, you can move while jumping.  
- **Avoid Collisions and the Pits**  Touching the Fly kills you or falling into a pit 

## Installation  
1. Download or clone this repository.  
2. Open **Godot**.  
3. Import the project:  
   - Either select the **project.godot** file  
   - Or import directly from the downloaded ZIP.  
4. Run the project to start playing.  


## Goal  
- Platform your way to saving your precious rat friend Lemmy!  
- Test your reflexes and survive the fly defending Lemmy!  

## Assignment goals 
### Main Goals
- [x] Functionality - 2 pts Does the game run without errors? Are all required features implemented
(tilemap, player movement, navigation, animation, particles, physics)? Yes it has a tilemap, the player moves, there is navigation for the enemy patrol, animation for the enemy and the player, particles when you successfully collect your friend Lemmy and physics based movement for the player.
- [x] C# code quality - 2pts Are classes and methods well‑structured and documented? Does the code
make good use of object‑oriented principles? Yes the code is well structured and documented, while also using the full extent of the C# language and object oriented principle
- [x] Use of Godot features - 2 pts Appropriate use of TileMap/TileSet, NavigationAgent2D, AnimatedSprite2D, Particles2D, CollisionShape2D and CharacterBody2D (with move_and_slide() , gravity and input) Uses the tilemap and tileset to create the platforms the player moves on, NavigationAgent2D is used to move the fly and make sure he flies faster around the player, AnimatedSprite2D is used for the enemy and player animations, Particles2D is used to show the player picking up Lemmy and succeeding in saving him, CollisionShape2D is used for the player the enemy and the pickup (Lemmy) to see if they touch, and I use CharacterBody2D with move_and_slide to move both the player and the enemy with gravity and input for the player 
- [x] Documentation & submission - 2 pts Presence of README, clear instructions for running the game, and proper packaging of the project. See above

##Video of Game

## Credits  
Developed as part of **IMG420 - Assignment 4**.  
Built with the [Godot Engine](https://godotengine.org/).  
