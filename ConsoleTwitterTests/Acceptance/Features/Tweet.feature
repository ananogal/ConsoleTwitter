Feature: Tweet
	In order to tweet in my wall
	As a user
	I want to be able to post and read a message

@mytag
Scenario: Tweet a message 
	Given I have enter my username
	And I have entered a message
	When I enter my username
	Then I should see my message

