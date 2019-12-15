# MightyKingdomProgrammingTest

--Functional Requirements--


● A player character that can:

 / ○ Jump

 / ○ Interact with obstacles

 / ○ Collect items

● A side-scrolling environment

 / ○ Platforms

 / ○ Ground to run on

 / ○ Endless

● Obstacles that trigger an end state

● Items that the player can pick up

● A scoring system

● An end state

● Functionality that can be built directly to mobile



--My Process--


Jump - The first most important piece of functionality was the player movement. Because it is a side scrolling infinite runner, I only need to implement a jump as I would have the level moving instead of the player.

Platforms - Next was the platforms that move to give the illusion of the player moving forward. I had multiple prefabs of platforms and would spawn them at random heights after detecting the previous platform had hit a trigger so that were spawned apart and not rapidly spawning. The platforms would then get destroyed offscreen. We now have an infinite runner, kinda.

End State - I then implemented the end state for when the player falls of the platform. This is a simple box trigger below the camera view. The end state needed a button so that you can play again, so I added a button that simply restarts the scene. 

Obstacles - I could then use the same script to create obstacles. The obstacles where added to some new platform prefabs. I initially had them randomly spawn off screen and fall onto the platforms, but this made some of level impossible. 

Scoring – I wanted to add the item collection but need a way to track them first. So I added a player score and items collected (coins in this case). The score would go every second that you are playing.

Collect items – Now I could create my coins with a trigger that would update amount of coins collected. They would randomly spawn in the air above the offscreen platforms so that they would fall down onto them and the player could collect the coins.

Optimize! – With all the functional requirements now met there was optimizing to do. Object Pooling! Instantiating and deleting is not very efficient. It’s better to have all the objects already in the scene but set to inactive. So when the platforms went off the screen that get set to inactive until they are need again when I will move their transform and set them to active again.

Art, Animations, Sound – The game was just using primitive objects and was not looking nice. Not that that matters in a programming test, but I consider myself a bit of generalist and want things to look nice. Plus, I am changing the art with code! I added a player sprite with animations for when it’s running, jumping and falling. Sprites to everything else (platforms, obstacles, coin). And added a parallax background. Music.

Challenge – It’s an infinite runner but you don’t want to be running infinitely. So, the game needs to get more difficult over time. I did this by speeding up the level over time. I also sped up the music, animations and parallax effect to match.

Android – I had been developing for PC for the sake of playtesting initially as I knew it would be a simple game to port to mobile. All I had to do was change the inputs for the jumping. I later made it so the game could be played on both pc and mobile.

Shop – I had some extra time to work on the project, so I decided it needed a shop. What’s the point of collecting coins if you can’t spend them, right? So, what should the player buy? Well I opened up a donut shop! This was a fun one to make as I made it totally dynamic. You can add and remove items from the store with ease without doing anything else and it will simply work thanks to making the items with scriptable objects.

WebGL – I want the game to be even more accessible so I ported the game to Webgl.
