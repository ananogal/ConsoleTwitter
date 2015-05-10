Feature: InteractWithProgram
	In to interact with the program
	As a user
	I want to be able to enter commands

@mytag
Scenario: Post Command
	Given the system is waiting for a command
	When I enter a post command
	Then I should create a post

Scenario: Read Command
	Given the system is waiting for a command
	When I enter a read command
	Then I should see all my posts

Scenario: FollowCommand
	Given the system is waiting for a command
	When I enter a follow command
	Then I should follow the userToFollow

Scenario: WallCommand
	Given the system is waiting for a command
	When I enter a wall command
	Then I should see all my posts and the posts from who I follow
