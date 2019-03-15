# Unity Platformer

A platformer game designed for Android written in C# with Unity. 

The game has two levels which must be completed in order to win. The first level consists of running around the stage and punching the enemies to kill them. Enemies will die in one hit, but they will periodically shoot bullets. The player starts with 100 damage and if hit by a bullet, will take 10 damage. Bullets can be blocked by holding the shield button. The energy shield must make contact with the bullet, so shots hitting from behind will still deal damage. The player cannot move when shielding but can pivot left and right to block bullets coming from both sides. Once 20 enemies are defeated the right side of the stage becomes reachable and the player's health will go back to 100.

The second level of the game contains meteor barrages which fall in a cluster from the sky at a regular interval. If a meteor makes contact with the player it will deal 10 damage. To win the game, the player must survive for a minute.

The player moves left and right by pressing and holding on either side of the phone screen and can punch, shield, or reset the game by pressing the respective buttons on the UI.

The game has background music, winning/losing screens, sound effects, and animations for running, punching, and shielding.

Sample gameplay: https://streamable.com/svrrn
