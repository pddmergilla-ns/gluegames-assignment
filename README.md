# gluegames-assignment

Task
Create a lean prototype of a Top Down Shooter.
Development Guidelines
The following guidelines should be implemented in the prototype:
Foundation elements:

1. A single main character in the center of the screen.
2. A joystick to move the character.
3. Another joystick to attack with the character.
4. A rectangular field where the character can move.


Enemies:
1. Create two types of enemies. The only difference between them is their movement
speed.
2. Once spawned, the enemy moves towards the player.
3. The enemy deals damage to the player if it touches him.
4. The enemy has a damage dealing cooldown to avoid a situation where it touches the
player constantly and deals damage every frame.
5. Spawn enemies at random locations around the player. Make sure to never spawn
enemies too close to the player.



Attacking:
1. As long as the player’s attack joystick is pressed, bullets will be spawned from the player
in the direction of the joystick.
2. If the bullet hits an enemy it will despawn and deal damage to that enemy.



UI:
1. Add a Player Health Bar on the top center of the UI.

2. Add an Enemies Kill Count in any other corner in the UI.
Effects:



Add a placeholder effect when:
1. An enemy is killed.
2. The player is killed.
3. An attack hits an enemy.
4. An enemy deals damage to the player.

Ending game:
1. End the game if the player loses all of his health.
2. End the game if the player managed to kill 10 enemies.

General Guidelines
1. Keep in mind that this task is designed to test your development skills and architecture.
2. Do NOT invest time and effort in animations or visuals.
3. Use assets from the unity assets freely but don’t use them to solve architecture
challenges.
