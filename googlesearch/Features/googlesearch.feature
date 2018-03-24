Feature: googlesearch
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers
	

Scenario: google search for townsuite
	Given I have navigate to google page
	And I see the google page fully loaded
	When I type key word as
	| Keyword |
	| Townsuite|
	Then i should see a result of the key word
	| Keyword |
	| TownSuite Municipal Software: Home|