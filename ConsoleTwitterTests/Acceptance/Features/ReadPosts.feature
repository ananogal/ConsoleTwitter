Feature: Read Posts
	In order to see all my posts
	As a user
	I want to be able to enter my username

@mytag
Scenario: Read
	Given I have entered my username
	When I press enter
	Then I sould see all my posts
