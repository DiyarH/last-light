# Last Light
A remake of classic arcade game "Asteroids" as my entry for "Classic Games Remix" Game Jam

## Features:
- [X] Asteroid spawning
Asteroids will constantly spawn off-screen and move towards the screen. Wrapping is implemented for asteroids so over time, their number will increase.
- [X] Player spaceship movement
Player movement is very similar to the original "Asteroids" player movement, with rotation at a constant speed and using acceleration to move forward.
- [X] Player laser shooting
By pressing spacebar, laser will be shoot from the player position. Once the laser hits an asteroid, both get destroyed.
- [X] Asteroid splitting
- [X] Power mechanic
Power is a replacement for original life system of "Asteroids". At the start of the game, there is a energy storage in the middle of the screen, holding power. Collision of asteroids with this storage or the player spaceship itself will decrease power, so the player must protect the storage by shooting down the asteroids. Power will go down with player movement and bullet shooting. It can be replenished by collecting powerups from destroyed asteroids and enemy spaceships. When power reaches zero percent, the player loses.
- [ ] Gameplay HUD
- [ ] Enemy spaceships
  - [ ] Rammer Enemy
  - [ ] Shooter Enemy
- [ ] Emergency mode
Emergency mode happens when power goes below a certain threshold. In this mode, screen becomes black, asteroids and emeny spaceships disappear and a radar gets activated, which can detect position of objects. To restore to normal mode, the player must gather a certain amount of power.
- [ ] Screens
  - [ ] Main Menu
  - [ ] Options
  - [ ] About
  - [ ] Game Over screen
  - [ ] Winning screen
Once the player survives long enough, the game is won.
  - [ ] Leaderboard
- [ ] SFX
- [ ] Music