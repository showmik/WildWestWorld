# Wild West World
 
**Wild West World** is a game AI project based on the concepts explained in the book "**Programming Game AI by Example**" by Matt Buckland. This project demonstrates the implementation of a Finite State Machine (FSM) for game AI. The original project was written in C++, but this version has been implemented using a C# console application.

## Introduction

The **Wild West World** is a simulation of the daily routine and interactions of two characters, Bob (a miner) and Elsa (Bob's wife). The project showcases how a Finite State Machine can be used to model the behavior of individual characters as well as their interactions with each other and the environment.

In this scenario, Bob can be in different states, such as "EnterMineAndDigForNugget", "GoHomeAndSleepTilRested", "QuenchThirst", "VisitBankAndDepositGold", and "EatStew". Elsa also has her own states, including "CookStew", "DoHouseWork", "VisitBathroom", and "WifesGlobalState".

The FSM governs the transitions between these states based on the current needs and desires of the characters. Bob and Elsa respond dynamically to changes in their environment, such as hunger, fatigue, and social interactions.

The purpose of this project is to provide a practical example of how to implement a game AI using FSMs, offering insights into the design and development process for character behavior and interactions.

## Installation

To run the Wild West World project, you will need:

-   [Microsoft Visual Studio](https://visualstudio.microsoft.com/downloads/) or any other C# development environment.

To install and run the project, follow these steps:

1. Clone the repository to your local machine.

	```bash
	 git clone https://github.com/showmik/wild-west-world.git
	```

2. Open the solution file `WildWestWorld.sln` in Microsoft Visual Studio.
3.  Build the solution.
4. Run the application by pressing F5 or selecting the "Start" button in the toolbar.
