Feature: Tweet
	In order to tweet in my wall
	As a user
	I want to be able to post and read a message

Scenario: Enter a post command 
	Given the system is waiting for a command
	When I enter a post command
	Then I should create a post command

