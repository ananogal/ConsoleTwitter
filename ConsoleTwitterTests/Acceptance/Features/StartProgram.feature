Feature: StartProgram
	In order start a twitter console
	As a user
	I want to be see the available commands

Scenario: Start Program
		Given I am a user
		When I enter the system 
		Then I see a welcome Message

Scenario: Waiting for commands
		Given I enter the system
		When I see the welcome message
		Then the system will wait for a command

		
